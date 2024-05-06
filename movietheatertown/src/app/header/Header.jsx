import { Link } from 'react-router-dom';
import NavbarLink from './NavbarLink';

function Header() {
    return (
        <nav className="bg-gray-900 p-5">
            <div className="container mx-auto flex justify-between items-center">
                <div className="flex space-x-8 items-center">
                    <Link to="/" className="text-white text-xl font-bold">MovieTheaterTown</Link>
                    <ul className="flex space-x-4">
                        <NavbarLink to="/" text="Home" />
                        <NavbarLink to="/add" text="Add Movie" />
                    </ul>
                </div>
                <div>
                    <ul className="flex space-x-4">
                        <NavbarLink to="/signin" text="Sign in" />
                    </ul>
                </div>
            </div>
        </nav>
    );
}

export default Header;