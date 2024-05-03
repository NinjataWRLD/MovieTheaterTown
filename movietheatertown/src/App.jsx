import Movies from './Movies.jsx'
import MovieForm from './MovieForm.jsx'
import './App.css';
import { useState } from 'react';

function App() {
    const [movies, setMovies] = useState([]);

    return (
        <div className="container">
            <h1 className="text-center">Movies:</h1>
            <MovieForm movies={movies} setMovies={setMovies} />
            <Movies movies={movies} setMovies={setMovies} />
        </div>
    );
}

export default App;