import { Link, useNavigate } from 'react-router-dom'
import GuestMenu from './Menus/UserMenus/GuestMenu'
import ClientMenu from './Menus/UserMenus/ClientMenu'
import ContributorMenu from './Menus/UserMenus/ContributorMenu'
import AdministratorMenu from './Menus/UserMenus/AdministratorMenu'
import SignInMenu from './Menus/SignInMenu'
import AccountMenu from './Menus/AccountMenu'
import axios from 'axios'

function Header({ isAuthenticated, setIsAuthenticated }) {
    const navigate = useNavigate();
    
    const handleLogout = async () => {
        try {
            await axios.post('https://localhost:7237/account/logout');

            localStorage.removeItem('token');
            localStorage.removeItem('username');
            localStorage.removeItem('role');

            setIsAuthenticated(false);
        } catch (error) {
            console.error('Error logging out user:', error);
        }
        navigate("/");
    };

    let UserMenu;
    switch (localStorage.getItem('role')) {
        case 'Client': UserMenu = ClientMenu; break;
        case 'Contributor': UserMenu = ContributorMenu; break;
        case 'Administrator': UserMenu = AdministratorMenu; break;
        default: UserMenu = GuestMenu; break;
    }

    return (
        <nav className="bg-gray-900 p-5">
            <div className="container mx-auto flex justify-between items-center">
                <div className="flex text-white space-x-8 items-center">
                    <Link to="/" className="text-white text-xl font-bold">MovieTheaterTown</Link>
                    <UserMenu />
                </div>
                <div>
                    {
                        !isAuthenticated ? <SignInMenu />
                        :
                        <AccountMenu
                            username={localStorage.getItem('username')}
                            onLogout={handleLogout}
                        /> 
                    }
                </div>
            </div>
        </nav>
    );
}

export default Header;