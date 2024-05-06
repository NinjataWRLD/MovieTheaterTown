import { Link } from 'react-router-dom'

function MovieCard({ movie, movies, setMovies }) {
    return (
        <div className="bg-gray-900 p-4 rounded-lg shadow-md">
            <p className="text-xl text-center font-semibold mb-2">{movie.name}</p>
            <p>{movie.plot}</p>
            <div className="flex justify-center">
                <button className="mt-4 bg-zinc-600 text-white px-4 py-2 rounded-md hover:bg-zinc-400 focus:bg-zinc-200"
                >
                    <Link to={`/moviedetails/${movie.id}`}>Details</Link>
                </button>
            </div>
        </div>
    );
}

export default MovieCard;