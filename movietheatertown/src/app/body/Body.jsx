import { useState } from 'react'
import { Routes, Route } from 'react-router-dom'
import MovieForm from './Create/MovieForm'
import Home from './Home'
import Movies from './Read/Movies'
import MovieDetails from './Read/Update, Delete/MovieDetails'
import SigninPage from './Auth/SigninPage'
import NotFoundPage from './Errors/NotFoundPage'
import ForbiddenPage from './Errors/ForbiddenPage'
import UnauthorizedPage from './Errors/UnauthorizedPage'

function Body({ isInRole, isAuthenticated, setIsAuthenticated }) {
    const [movies, setMovies] = useState([]);

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

        localStorage.setItem('token', user.token);
        localStorage.setItem('username', user.username);
        localStorage.setItem('role', user.role);

                <Route path="/add"
                    element={isInRole('Contributor') ?
                        <MovieForm movies={movies} setMovies={setMovies} /> :
                        <ForbiddenPage />} />

                <Route path="/*"
                    element={<NotFoundPage />} />
            </Routes>
        </div>
    );
}

export default Body;