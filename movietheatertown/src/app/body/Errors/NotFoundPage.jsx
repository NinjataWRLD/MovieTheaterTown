import { Link } from 'react-router-dom'

function NotFoundPage() {
    return (
        <div className="container mt-10">
            <h1 className="text-3xl text-center">
                Sorry, the place you're looking for doesn't exist.
            </h1>
            <br />
            <p className="text-xl text-center">
                Go back <Link to="/" className="text-blue-500">Home</Link>?
            </p>
        </div>
    );
}

export default NotFoundPage;