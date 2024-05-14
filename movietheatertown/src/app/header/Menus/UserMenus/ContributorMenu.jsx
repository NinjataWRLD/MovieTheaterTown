import NavbarLink from '../../NavbarLink'

function ContributorNavbar() {
    return (
        <ul className="flex space-x-4">
            <NavbarLink to="/" text="Home"></NavbarLink>
            <NavbarLink to="/movies" text="All Movies"></NavbarLink>
            <NavbarLink to="/watchlist" text="Your Watchlist"></NavbarLink>
            <NavbarLink to="/add" text="Add Movie" />
        </ul>
    );
}

export default ContributorNavbar;