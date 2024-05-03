import { useState } from 'react';

function MovieForm({ movies, setMovies }) {
    const [name, setName] = useState('');
    const [plot, setPlot] = useState('');

    const addMovie = (movie) => {
        fetch("movies", {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(movie)
        })
            .then(response => response.json())
            .then(data => setMovies([...movies, data]))
            .catch(error => console.error('Error:', error));
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        if (!name.trim() || !plot.trim()) return;

        const movie = { name: name, plot: plot, cast: [], crew: [], reviews: [] };
        addMovie(movie);

        setName('');
        setPlot('');
    };

    return (
        <>
            <form onSubmit={handleSubmit} className="w-1/2 mx-auto mt-8" >
                <div className="mb-4">
                    <label className="block text-gray-200">Movie Name:</label>
                    <input value={name}
                        onChange={(e) => setName(e.target.value)}
                        className="text-gray-900 w-full border border-gray-300 rounded-md px-3 py-2 mt-1 focus:outline-none focus:ring-indigo-500 focus:border-indigo-500"
                        placeholder="Enter the name of movie:"
                    />
                </div>
                <div className="mb-4">
                    <label className="block text-gray-200">Movie Plot:</label>
                    <textarea value={plot}
                        onChange={(e) => setPlot(e.target.value)}
                        className="text-gray-900 w-full border border-gray-300 rounded-md px-3 py-2 mt-1 focus:outline-none focus:ring-indigo-500 focus:border-indigo-500"
                        placeholder="Summarize its plot:"
                        rows="4"
                    >
                    </textarea>
                </div>
                <div className="flex justify-center">
                    <button type="submit" className=" bg-sky-900 text-white px-4 py-3 rounded-md hover:bg-sky-700 focus:outline-none focus:bg-sky-500">Add movie</button>
                </div>
            </form>
        </>
    );
}

export default MovieForm;