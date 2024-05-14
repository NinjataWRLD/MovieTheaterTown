import { Link } from 'react-router-dom'

function UnauthorizedPage() {
    return (
        <div className="container mt-10">
            <h1 className="text-3xl text-center">
                Sorry, you don't have access to the place you're looking for.
            </h1>
            <br />
            <p className="text-xl text-center">Want to add movies to your watchlist or view their details?</p>
            <p className="text-xl text-center">
                Try <Link to="/signin" className="text-blue-500">signing in</Link>!
            </p>
        </div>
    );
}

export default UnauthorizedPage;