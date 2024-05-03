import Header from './header/Header';
import Body from './body/Body';
import Footer from './footer/Footer';
import './App.css';
/*import { Route, Routes } from 'react-router-dom';*/

function App() {
    return (
        <div className="bg-gray-800 ">
            <Header />
            <Body />
            <hr className="mt-10 mb-1 bg-black" />
            <Footer />
        </div>
    );
}
export default App;