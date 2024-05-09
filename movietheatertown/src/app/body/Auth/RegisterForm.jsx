import { useState } from 'react'

function RegisterForm({ onSubmit }) {
    const [username, setUsername] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [confirmPassword, setConfirmPassword] = useState('');

    const handleSubmit = (event) => {
        event.preventDefault();
        if (password != confirmPassword) {
            console.log('passwords do not match bro');
        }
        else {
            onSubmit({ username, email, password });
        }
    };

    return (
        <form onSubmit={handleSubmit} className="w-1/2">
            <div className="mb-4">
                <label htmlFor="text" className="block text-gray-200">Username</label>
                <input
                    type="text"
                    id="username"
                    value={username}
                    onChange={(e) => setUsername(e.target.value)}
                    className="text-gray-900 w-full  mt-1 p-2 px-4 border border-gray-300 rounded focus:outline-none focus:ring-indigo-500 focus:border-indigo-500"
                    placeholder="Your_Username123"
                    required
                />
            </div>
            <div className="mb-4">
                <label htmlFor="email" className="block text-gray-200">Email</label>
                <input
                    type="email"
                    id="email"
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                    className="text-gray-900 w-full  mt-1 p-2 px-4 border border-gray-300 rounded focus:outline-none focus:ring-indigo-500 focus:border-indigo-500"
                    placeholder="your@email.com"
                    required
                />
            </div>
            <div className="mb-4">
                <label htmlFor="password" className="block text-gray-200">Password</label>
                <input
                    type="password"
                    id="password"
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                    className="text-gray-900 w-full  mt-1 p-2 px-4 border border-gray-300 rounded focus:outline-none focus:ring-indigo-500 focus:border-indigo-500"
                    required
                    placeholder="my_sercret_password_123"
                />
            </div>
            <div className="mb-4">
                <label htmlFor="confirmPassword" className="block text-gray-200">Confirm Password</label>
                <input
                    type="password"
                    id="confirmPassword"
                    value={confirmPassword}
                    onChange={(e) => setConfirmPassword(e.target.value)}
                    className="text-gray-900 w-full  mt-1 p-2 px-4 border border-gray-300 rounded focus:outline-none focus:ring-indigo-500 focus:border-indigo-500"
                    required
                    placeholder="my_sercret_password_123"
                />
            </div>
            <div className="pt-5 flex justify-center">
                <button
                    type="submit"
                    className="bg-blue-500 text-white py-2 px-4 rounded hover:bg-blue-600 focus:outline-none"
                >
                    Register
                </button>
            </div>
        </form>
    );
}

export default RegisterForm;