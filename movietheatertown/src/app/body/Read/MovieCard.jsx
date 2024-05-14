import { Link } from 'react-router-dom'
import { useState, useEffect } from 'react'
import axios from 'axios'

function MovieCard({ movie }) {
    const username = localStorage.getItem('username');

    const [isSaved, setIsSaved] = useState(false);
    useEffect(() => {
        setIsSaved(movie.saved.some(u => u == username));
        
    }, []);

    const handleClick = async () => {
        const operation = isSaved ? 'remove' : 'add';
        const headers = {
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + localStorage.getItem('token')
        };

        await axios.put(`https://localhost:7237/movies/${operation}/${movie.id}`, username, { headers })
            .then(response => console.log(response))
            .catch(error => console.error(error));

        setIsSaved(!isSaved);
    };

    return (
        <div className="bg-gray-900 p-4 rounded-lg shadow-md">
            <div className="flex justify-between align-center mb-2">
                <span className="text-xl font-semibold">{movie.name}</span>
                <button onClick={handleClick}
                    className={"text-white px-4 py-1 rounded-md " +
                        (isSaved ?
                            "bg-rose-600 hover:bg-rose-400" :
                            "bg-green-600 hover:bg-green-400")}
                >
                    {isSaved ? "Remove" : "Save"}
                </button>
            </div>
            <p>{movie.plot}</p>
            <div className="flex justify-center">
                <Link to={`/movie/${movie.id}`}>
                    <button className="mt-4 bg-zinc-600 text-white px-4 py-2 rounded-md hover:bg-zinc-400 focus:bg-zinc-200">
                        Details
                    </button>
                </Link>
            </div>
        </div>
    );
}

export default MovieCard;