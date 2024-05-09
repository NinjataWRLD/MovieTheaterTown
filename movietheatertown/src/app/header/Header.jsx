import { Link, useNavigate } from 'react-router-dom'
import GuestMenu from './Menus/GuestMenu'
import UserMenu from './Menus/UserMenu'
import SignInMenu from './Menus/SignInMenu'
import AccountMenu from './Menus/AccountMenu'
import axios from 'axios'

function Header({ isAuthenticated, setIsAuthenticated, token }) {
    const navigate = useNavigate();

    const logoutUser = async () => {
        try {
            await axios.post('https://localhost:7237/account/logout');
            localStorage.removeItem('token');
            localStorage.removeItem('username');
            setIsAuthenticated(false);
        } catch (error) {
            console.error('Error logging out user:', error);
        }
        navigate("/");
    };

    return (
        <nav className="bg-gray-900 p-5">
            <div className="container mx-auto flex justify-between items-center">
                <div className="flex space-x-8 items-center">
                    <Link to="/" className="text-white text-xl font-bold">MovieTheaterTown</Link>
                    {isAuthenticated ? <UserMenu /> : <GuestMenu />}
                </div>
                <div>
                    {isAuthenticated ? <AccountMenu username={token} onLogout={logoutUser} /> : <SignInMenu />}
                </div>
            </div>
        </nav>
    );
}

export default Header;