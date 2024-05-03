import React from 'react'
import { createRoot } from 'react-dom/client'
/*import { BrowserRouter } from 'react-router-dom';*/
import App from './app/App.jsx'
import './index.css'
import 'tailwindcss/tailwind.css'

createRoot(document.getElementById('root')).render(
    <React.StrictMode>
        {/*<BrowserRouter>*/}
        <App />
        {/*</BrowserRouter>*/}
    </React.StrictMode>
)
