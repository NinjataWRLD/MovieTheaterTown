import Movies from './Movies'
import MovieForm from './MovieForm'
import { useState } from 'react';

function Body() {
    const [movies, setMovies] = useState([]);

    return (
        <div  className="container text-white m-0">
            {/*<Routes>*/}
            {/*<Route exact path="/">*/}
            <h1 className="text-3xl font-bold py-6 text-center">Movies</h1>
            <Movies movies={movies} setMovies={setMovies} />
            {/*</Route>*/}
            {/*<Route exact path="/add">*/}
            <MovieForm movies={movies} setMovies={setMovies} />
            {/*</Route>*/}
            {/*</Routes>*/}
        </div>
    );
}

export default Body;