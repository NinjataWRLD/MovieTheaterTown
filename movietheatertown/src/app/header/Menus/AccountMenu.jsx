function AccountMenu({ username, onLogout}) {
    return (
        <ul className="flex space-x-4">
            <p className="text-white">Hello, {username}!</p>
            <button className="text-white hover:text-gray-300" onClick={onLogout}>Log out</button>
        </ul>
    );
}

export default AccountMenu;