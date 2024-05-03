import { useState } from 'react';

function MovieForm({movies, setMovies }) {
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
            <form onSubmit={handleSubmit} >
                <div className="row justify-content-center">
                    <div className="col-2">
                        <label>Movie Name:</label>
                        <input value={name}
                            onChange={(e) => setName(e.target.value)} />
                    </div>
                    <div className="col-2">
                        <label>Movie Plot:</label>
                        <input value={plot}
                            onChange={(e) => setPlot(e.target.value)} />
                    </div>
                </div>
                <div className="row justify-content-center">
                    <button type="submit" className="col-2 btn btn-primary">Add movie</button>
                </div>
            </form>
        </>
    );
}

export default MovieForm;