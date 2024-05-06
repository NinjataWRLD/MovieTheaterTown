import { useParams, useNavigate } from 'react-router-dom'
import { useState, useEffect } from 'react'
import MoviePropForm from './Props/MoviePropForm'
import MoviePropList from './Props/MoviePropList'

function MovieDetails({ movies, setMovies }) {
    const { id } = useParams();
    const navigate = useNavigate();

    const [movie, setMovie] = useState({ cast: [], crew: [], reviews: [] });
    const [castMember, setCastMember] = useState('');
    const [crewMember, setCrewMember] = useState('');
    const [review, setReview] = useState('');

    useEffect(() => {
        getMovie(id);
    }, []);

    const updateDb = (data) => fetch(`/movies/${id}`, {
        method: 'PATCH',
        headers: { 'CONTENT-TYPE': 'application/json' },
        body: JSON.stringify([data])
    });

    function editMovieCast(operation, value) {
        const patchInfo = {
            "path": '/cast/-',
            "op": operation,
            "value": { "name": value }
        };
        updateDb(patchInfo);
    }

    function editMovieCrew(operation, value) {
        const patchInfo = {
            "path": '/crew/-',
            "op": operation,
            "value": { "name": value }
        };
        updateDb(patchInfo);
    }

    function editMovieReviews(operation, value) {
        const patchInfo = {
            "path": '/reviews/-',
            "op": operation,
            "value": { "message": value }
        };
        updateDb(patchInfo);
    }

    function deleteMovie(id) {
        fetch(`/movies/${id}`, { method: 'DELETE', })
            .then(() => setMovies(movies.filter(m => m.id != id)));
        navigate('/');
    }

    return (
        <div className="my-8">
            <h1 className="text-3xl font-semibold text-center mb-6">"{movie.name}"</h1>
            <div className=" bg-gray-900 mx-28 p-4 rounded-3xl shadow-md">
                <p className="text-lg text-center mt-3 mb-5">{movie.plot}</p>
                <div className="flex justify-between">
                    <div className="w-1/3">
                        <span className="font-bold">Cast:</span>
                        <MoviePropForm prop={castMember} setProp={setCastMember} saveChanges={editMovieCast} placeholder="Cast Member name" />
                        <MoviePropList props={movie.cast} saveChanges={editMovieCast} />
                    </div>
                    <div className="w-1/3">
                        <span className="font-bold">Crew:</span>
                        <MoviePropForm prop={crewMember} setProp={setCrewMember} saveChanges={editMovieCrew} placeholder="Crew Member name" />
                        <MoviePropList props={movie.crew} saveChanges={editMovieCrew} />
                    </div>
                    <div className="w-1/3">
                        <span className="font-bold">Reviews: </span>
                        <MoviePropForm prop={review} setProp={setReview} saveChanges={editMovieReviews} placeholder="Review" />
                        <MoviePropList props={movie.reviews} saveChanges={editMovieReviews} />
                    </div>
                </div>
                <div className="mt-5 mb-4s flex justify-evenly">
                    <button className="mt-4 bg-rose-900 text-white px-4 py-2 rounded-md hover:bg-rose-700 focus:bg-rose-500"
                        onClick={() => deleteMovie(movie.id)}>Delete movie</button>
                </div>
            </div>
        </div>
    );

    async function getMovie(id) {
        const response = await fetch(`/movies/${id}`);
        const data = await response.json();
        setMovie(data);
    }
}

export default MovieDetails;