import { useState, useEffect } from 'react'
import { Routes, Route } from 'react-router-dom'
import MovieForm from './Create/MovieForm'
import Home from './Home'
import Movies from './Read/Movies'
import Watchlist from './Read/Watchlist'
import MovieDetails from './Read/Update, Delete/MovieDetails'
import SigninPage from './Auth/SigninPage'
import NotFoundPage from './Errors/NotFoundPage'
import ForbiddenPage from './Errors/ForbiddenPage'
import UnauthorizedPage from './Errors/UnauthorizedPage'
import axios from 'axios'

function Body({ isInRole, isAuthenticated, setIsAuthenticated }) {
    const [movies, setMovies] = useState([]);

    useEffect(() => {
        populateData();
    }, []);

    return (
        <div className="container text-white m-0">
            <Routes>
                <Route path="/"
                    element={<Home />} />

                <Route path="/movies"
                    element={<Movies movies={movies} setMovies={setMovies} />} />

                <Route path="/signin"
                    element={<SigninPage setIsAuthenticated={setIsAuthenticated} />} />

                <Route path="/movie/:id"
                    element={isAuthenticated ?
                        <MovieDetails movies={movies} setMovies={setMovies} /> :
                        <UnauthorizedPage />} />

                <Route path="/watchlist"
                    element={(isInRole('Client') || isInRole('Contributor')) ?
                        <Watchlist movies={movies} /> :
                        <UnauthorizedPage />} />

                <Route path="/add"
                    element={isInRole('Contributor') ?
                        <MovieForm movies={movies} setMovies={setMovies} /> :
                        <ForbiddenPage />} />

                <Route path="/*"
                    element={<NotFoundPage />} />
            </Routes>
        </div>
    );

    async function populateData() {
        const apiMovies = await axios.get('https://localhost:7237/movies').then(response => response.data);
        setMovies(apiMovies);
    }
}

export default Body;