import NavbarLink from '../NavbarLink'

function GuestNavbar() {
    return (
        <ul className="flex space-x-4">
            <NavbarLink to="/" text="Home" />
        </ul>
    );
}

export default GuestNavbar;