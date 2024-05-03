import { Link } from 'react-router-dom';
import NavbarLink from './NavbarLink';

function Header() {
    return (
        <nav className="bg-gray-900 p-5">
            <div className="container mx-auto flex justify-between items-center">
                <div className="flex space-x-8 items-center">
                    <div to="/" className="text-white text-xl font-bold">MovieTownCinema</div>
                    <ul className="flex space-x-4">
                        <div className="text-white hover:text-gray-300">Home</div>
                        <div className="text-white hover:text-gray-300">Add Movie</div>
                    </ul>
                </div>
                <div>
                    <ul className="flex space-x-4">
                        <div className="text-white hover:text-gray-300">Sign in</div>
                        <div className="text-white hover:text-gray-300">Sign up</div>
                    </ul>
                </div>
            </div>
        </nav>
    );
}

export default Header;