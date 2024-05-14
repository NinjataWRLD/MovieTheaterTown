import NavbarLink from '../../NavbarLink'

function GuestNavbar() {
    return (
        <ul className="flex space-x-4">
            <NavbarLink to="/" text="Home" />
            <NavbarLink to="/movies" text="All Movies" />
        </ul>
    );
}

export default GuestNavbar;