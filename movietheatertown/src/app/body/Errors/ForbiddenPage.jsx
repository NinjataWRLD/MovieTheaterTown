import { Link } from 'react-router-dom'

function ForbiddenPage() {
    return (
        <div className="container mt-10">
            <h1 className="text-3xl text-center">
                Sorry, you don't have access to the place you're looking for.
            </h1>
            <br />
            <p className="text-xl text-center">
                Want to add movies? 
                <Link to="/becomecontributor" className="text-blue-500"> Become a contributor</Link>! 
            </p>
        </div>
    );
}

export default ForbiddenPage;