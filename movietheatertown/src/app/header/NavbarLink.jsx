import React from 'react';
import { Link } from 'react-router-dom';

function NavbarLink({ to, text }) {
    return (
        <li>
            <Link to={to} className="text-white hover:text-gray-300">{text}</Link>
        </li>
    );
}

export default NavbarLink;