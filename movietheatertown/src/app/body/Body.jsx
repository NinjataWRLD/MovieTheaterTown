import { useState } from 'react'
import { Routes, Route, useNavigate } from 'react-router-dom'
import MovieForm from './Create/MovieForm'
import Movies from './Read/Movies'
import MovieDetails from './Read/Update, Delete/MovieDetails'
import SigninPage from './Auth/SigninPage'
import axios from 'axios'

function Body({ isAuthenticated, setIsAuthenticated }) {
    const navigate = useNavigate();

    const [movies, setMovies] = useState([]);

    const registerUser = async (userData) => {
        try {
            const user = await axios.post('https://localhost:7237/account/register', userData)
                .then(response => response.data); // object with token, role and username

            localStorage.setItem('token', user.token);
            localStorage.setItem('username', user.username);
            localStorage.setItem('role', user.role);

            setIsAuthenticated(true);
            navigate("/");
        } catch (e) {
            console.error(e)
        }
    };

    const loginUser = async (credentials) => {
        try {
        const user = await axios.post('https://localhost:7237/account/login', credentials)
            .then(response => response.data); // object with token, role and username

        localStorage.setItem('token', user.token);
        localStorage.setItem('username', user.username);
        localStorage.setItem('role', user.role);

        setIsAuthenticated(true);
            navigate("/");
        } catch (e) {
            console.error(e)
        }
    };

    return (
        <div className="container text-white m-0">
            <Routes>
                <Route path="/" element={<Movies movies={movies} setMovies={setMovies} />} />
                <Route path="/movies" element={<Movies movies={movies} setMovies={setMovies} />} />
                <Route path="/moviedetails/:id" element={<MovieDetails movies={movies} setMovies={setMovies} />} />
                <Route path="/signin" element={<SigninPage onLogin={loginUser} onRegister={registerUser} />} />
                <Route path="/add" element={isAuthenticated ? <MovieForm movies={movies} setMovies={setMovies} /> : null} />
            </Routes>
        </div>
    );
}

export default Body;