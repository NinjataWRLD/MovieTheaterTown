import { useEffect } from 'react';
import Movie from './MovieCard'
import axios from 'axios'

function Movies({ movies, setMovies }) {
    return (
        <>
            <h1 className="text-3xl font-bold my-6 text-center">Movies</h1>
            <ul className="flex flex-wrap justify-between">
                {movies.map(movie => (
                    <li key={movie.id} className="w-1/3 p-4">
                        <Movie movie={movie} />
                    </li>
                ))}
            </ul>
        </>
    );
}

export default Movies;