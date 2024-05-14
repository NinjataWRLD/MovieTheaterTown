import Movie from './MovieCard'
import { useState, useEffect } from 'react'

function Watchlist({ movies }) { 
    const [watchlist, setWatchlist] = useState([]);

    const moviesFilter = m =>
        m.saved.some(username => username == localStorage.getItem('username'));

    useEffect(() => {
        setWatchlist(movies.filter(moviesFilter));
    }, [movies]);

    return (
        <>
            <h1 className="text-3xl font-bold my-6 text-center">Watchlist</h1>
            <ul className="flex flex-wrap justify-between">
                {watchlist.map(movie => (
                    <li key={movie.id} className="w-1/3 p-4">
                        <Movie movie={movie} />
                    </li>
                ))}
            </ul>
        </>
    );
}

export default Watchlist;