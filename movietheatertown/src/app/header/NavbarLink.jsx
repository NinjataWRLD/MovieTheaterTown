import React from 'react';
import { Link } from 'react-router-dom';

function NavbarLink({ to, text }) {
    return (
        <li>
            <Link to={to} className="hover:text-gray-400">{text}</Link>
        </li>
    );
}

export default NavbarLink;