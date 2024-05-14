import NavbarLink from '../../NavbarLink'

function ClientNavbar() {
    return (
        <ul className="flex space-x-4">
            <NavbarLink to="/" text="Home"></NavbarLink>
            <NavbarLink to="/movies" text="All Movies"></NavbarLink>
            <NavbarLink to="/watchlist" text="Your Watchlist"></NavbarLink>
        </ul>
    );
}

export default ClientNavbar;