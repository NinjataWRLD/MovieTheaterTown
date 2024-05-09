import NavbarLink from '../NavbarLink'

function SignInMenu() {
    return (
        <ul className="flex space-x-4">
            <NavbarLink to="/signin" text="Sign in" />
        </ul>
    );
}

export default SignInMenu;