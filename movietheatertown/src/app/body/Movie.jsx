
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
        <div className="bg-gray-900 p-4 rounded-lg shadow-md">
            <p className="text-xl text-center font-semibold mb-2">{movie.name}</p>
            <p>{movie.plot}</p>
            <div className="flex justify-center">
                <button className="mt-4 bg-rose-900 text-white px-4 py-2 rounded-md hover:bg-rose-700 focus:bg-rose-500"
                    onClick={() => deleteMovie(movie.id)}>Delete</button>
            </div>
        </div>
    );
}

export default Movie;