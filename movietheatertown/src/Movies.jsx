import { useState, useEffect } from 'react';
import Movie from './Movie.jsx'

function Movies({ movies, setMovies }) {
    useEffect(() => {
        populateData();
    }, []);

    return (
        <ul className="row">
            {
                movies.map(movie => (
                    <li key={movie.id}>
                        <Movie movie={movie} movies={movies} setMovies={setMovies} />
                    </li>
                ))
            }
        </ul>
    );

    async function populateData() {
        const response = await fetch('movies');
        const data = await response.json();
        setMovies(data);
    }

}

export default Movies;