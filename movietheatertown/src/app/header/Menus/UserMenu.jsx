import NavbarLink from '../NavbarLink'

function UserNavbar() {
    return (
        <ul className="flex space-x-4">
            <NavbarLink to="/" text="Home" />
            <NavbarLink to="/add" text="Add Movie" />
        </ul>
    );
}

export default UserNavbar;