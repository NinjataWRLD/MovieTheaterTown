import NavbarLink from '../NavbarLink'

function SignInMenu() {
    return (
        <ul className="text-white flex space-x-4">
            <NavbarLink to="/signin" text="Log in or Register" />
        </ul>
    );
}

export default SignInMenu;