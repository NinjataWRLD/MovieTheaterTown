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
        await axios.post('https://localhost:7237/account/register', userData)
            .then(response => response.data) // the token as a string
            .then(token => localStorage.setItem('token', token))
            .catch(error => console.error(error));

        localStorage.setItem('username', userData.username);
        setIsAuthenticated(true);
        navigate("/");
    };

    const loginUser = async (credentials) => {
        await axios.post("https://localhost:7237/account/login", credentials)
            .then(response => response.data) // the token as a string
            .then(token => localStorage.setItem('token', token))
            .catch(error => console.error('Error - ' + error));

        localStorage.setItem('username', credentials.username);
        setIsAuthenticated(true);
        navigate("/");
    };

    return (
        <div className="container text-white m-0">
            <Routes>
                <Route path="/" element={<Movies movies={movies} setMovies={setMovies} />} />
                <Route path="/signin" element={<SigninPage onLogin={loginUser} onRegister={registerUser} />} />
                {isAuthenticated && <Route path="/add" element={<MovieForm movies={movies} setMovies={setMovies} />} />}
                {isAuthenticated && <Route path="/moviedetails/:id" element={<MovieDetails movies={movies} setMovies={setMovies} />} />}
            </Routes>
        </div>
    );
}

export default Body;