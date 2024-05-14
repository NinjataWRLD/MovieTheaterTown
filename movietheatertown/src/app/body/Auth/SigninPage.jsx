import { useState } from 'react'
import { useNavigate } from 'react-router-dom'
import LoginForm from './LoginForm'
import RegisterForm from './RegisterForm'
import axios from 'axios'

function SigninPage({ setIsAuthenticated }) {
    const navigate = useNavigate();

    const [isLogin, setIsLogin] = useState(true);

    const toggleForm = () => {
        setIsLogin(!isLogin);
    };

    const handleRegister = async (userData) => {
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

    const handleLogin = async (credentials) => {
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
        <div className="my-16 flex justify-center">
            <div className="w-3/6 bg-gray-900 rounded-md shadow-2xl">
                <h2 className="pt-12 text-4xl text-center">{isLogin ? "Login" : "Register"}</h2>
                <div className="pt-12 pb-8 flex justify-center">
                    {isLogin ? <LoginForm onSubmit={handleLogin} /> : <RegisterForm onSubmit={handleRegister} />}
                </div>
                <p className="pb-8 text-center">
                    {isLogin ? "Don't have an account yet?" : "Already have an account?"}{' '}
                    <button
                        className="text-blue-500 hover:underline focus:outline-none"
                        onClick={toggleForm}
                    >
                        {isLogin ? 'Register' : 'Login'}
                    </button>
                </p>
            </div>
        </div>
    );
}

export default SigninPage;