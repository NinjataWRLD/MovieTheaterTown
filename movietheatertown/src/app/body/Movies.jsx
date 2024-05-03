import { useState, useEffect } from 'react';
import Movie from './Movie.jsx'

function Movies({ movies, setMovies }) {
    useEffect(() => {
        populateData();
    }, []);

    return (
        <ul className="flex flex-wrap justify-between">
            {movies.map(movie => (
                <li key={movie.id} className="w-1/4 p-4">
                    <Movie movie={movie} movies={movies} setMovies={setMovies} />
                </li>
            ))}
        </ul>
    );

    async function populateData() {
        const response = await fetch('movies');
        const data = await response.json();
        setMovies(data);
    }

}

export default Movies;