import Header from './header/Header'
import Body from './body/Body'
import Footer from './footer/Footer'
import './App.css'
import { BrowserRouter as Router } from 'react-router-dom'

function App() {
    return (
        <Router>
            <div className="bg-gray-800 ">
                <Header />
                <Body />
                <hr className="mt-10 mb-1 bg-black" />
                <Footer />
            </div>
        </Router>
    );
}
export default App;