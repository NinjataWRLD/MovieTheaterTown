import Movies from './Read/Movies'
import MovieDetails from './Read/Update, Delete/MovieDetails'
import MovieForm from './Create/MovieForm'
import { useState } from 'react'
import { Routes, Route } from 'react-router-dom'

function Body() {
    const [movies, setMovies] = useState([]);

    return (
        <div className="container text-white m-0">
            <Routes>
                <Route path="/" element={<Movies movies={movies} setMovies={setMovies} /> } />
                <Route path="/add" element={<MovieForm movies={movies} setMovies={setMovies} /> } />
                <Route path={'/moviedetails/:id'} element={<MovieDetails movies={movies} setMovies={setMovies} /> } />
            </Routes>
        </div>
    );
}

export default Body;