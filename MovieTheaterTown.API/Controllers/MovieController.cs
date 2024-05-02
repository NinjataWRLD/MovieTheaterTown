using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieTheaterTown.Core.Contracts;
using MovieTheaterTown.Core.Models;
using Microsoft.AspNetCore.JsonPatch;
using MovieTheaterTown.Core.Profiles;
using MovieTheaterTown.Core.Profiles.DTOs;

namespace MovieTheaterTown.API.Controllers
{
    using static StatusCodes;

    [ApiController]
    [Route("/movies")]
    public class MovieController(IMovieService movieService) : ControllerBase
    {
        private readonly IMapper mapper = new MapperConfiguration(cfg
                => cfg.AddProfile<MovieDTOProfile>())
            .CreateMapper();

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(Status200OK)]
        [ProducesResponseType(Status400BadRequest)]
        public async Task<ActionResult<MovieExportDTO[]>> GetAsync()
        {
            try
            {
                IEnumerable<MovieModel> models = await movieService.GetAllAsync();
                return mapper.Map<MovieExportDTO[]>(models);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(Status200OK)]
        [ProducesResponseType(Status404NotFound)]
        public async Task<ActionResult<MovieExportDTO>> GetSingleAsync(int id)
        {
            try
            {
                MovieModel model = await movieService.GetByIdAsync(id);
                return mapper.Map<MovieExportDTO>(model);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(Status201Created)]
        [ProducesResponseType(Status400BadRequest)]
        public async Task<ActionResult<MovieExportDTO>> PostAsync(MovieImportDTO import)
        {
            MovieModel model = mapper.Map<MovieModel>(import);
            try
            {
                int id = await movieService.CreateAsync(model);

                model = await movieService.GetByIdAsync(id);
                MovieExportDTO export = mapper.Map<MovieExportDTO>(model);

                return CreatedAtAction(null, new { id }, export);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        [Consumes("application/json")]
        [ProducesResponseType(Status204NoContent)]
        [ProducesResponseType(Status403Forbidden)]
        [ProducesResponseType(Status404NotFound)]
        public async Task<ActionResult> PutAsync(int id, MovieImportDTO import)
        {
            try
            {
                MovieModel model = await movieService.GetByIdAsync(id);

                model.Name = import.Name;
                model.Plot = import.Plot;
                model.Cast = import.Cast;
                model.Crew = import.Crew;
                model.Reviews = import.Reviews;
                await movieService.EditAsync(id, model);

                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPatch("{id}")]
        [Consumes("application/json")]
        [ProducesResponseType(Status204NoContent)]
        [ProducesResponseType(Status400BadRequest)]
        [ProducesResponseType(Status404NotFound)]
        public async Task<ActionResult> PatchAsync(int id, [FromBody] JsonPatchDocument<MovieModel> patchMovie)
        {
            try
            {
                MovieModel model = await movieService.GetByIdAsync(id);
                patchMovie.ApplyTo(model);

                IList<string> errors = movieService.ValidateEntity(model);
                if (errors.Any())
                {
                    return BadRequest(string.Join("; ", errors));
                }

                await movieService.EditAsync(id, model);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict();
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }
            catch
            {
                return StatusCode(Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(Status204NoContent)]
        [ProducesResponseType(Status404NotFound)]
        [ProducesResponseType(Status400BadRequest)]
        public async Task<ActionResult<MovieModel>> DeleteAsync(int id)
        {
            try
            {
                if (await movieService.ExistsByIdAsync(id))
                {
                    await movieService.DeleteAsync(id);
                    return NoContent();
                }
                else return NotFound();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
