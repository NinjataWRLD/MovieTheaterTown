import Header from './header/Header'
import Body from './body/Body'
import Footer from './footer/Footer'
import { useState, useEffect } from 'react'
import { BrowserRouter as Router } from 'react-router-dom'
import './App.css'

function App() {
    const [isAuthenticated, setIsAuthenticated] = useState(false);

    useEffect(() => {
        checkIfAuthenticated();
    }, [isAuthenticated]);

    return (
        <Router>
            <div className="bg-gray-800 ">
                <Header isAuthenticated={isAuthenticated} setIsAuthenticated={setIsAuthenticated} token={localStorage.getItem('username')} />
                <Body isAuthenticated={isAuthenticated} setIsAuthenticated={setIsAuthenticated} />
                <hr className="mt-10 mb-1 bg-black" />
                <Footer />
            </div>
        </Router>
    );

    async function checkIfAuthenticated() {
        const token = (localStorage.getItem('token'));
        if (token != undefined) {
            setIsAuthenticated(true);
        }
    }
}
export default App;