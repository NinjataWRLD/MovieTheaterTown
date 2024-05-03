
function Movie({ movie, movies, setMovies }) {
    const patchMovie = () => {
        const body = [
            {
                "path": "string",
                "op": "replace",
                "value": "string"
            }
        ];
    };

    const deleteMovie = (id) => {
        fetch(`movies/${id}`, {
            method: 'DELETE'
        })
            .then(() => setMovies(movies.filter(m => m.id != id)));
    }

    return (
        <>
            <p>Name: {movie.name}</p>
            <p>Plot: {movie.plot}</p>
            <button onClick={() => deleteMovie(movie.id)}>Delete?</button>
        </>
    );
}

export default Movie;