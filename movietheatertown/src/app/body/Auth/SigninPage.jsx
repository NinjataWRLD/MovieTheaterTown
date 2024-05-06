import { useState } from 'react'
import LoginForm from './LoginForm'
import RegisterForm from './RegisterForm'

function SigninPage() {
    const [isLogin, setIsLogin] = useState(false);

    const toggleForm = () => {
        setIsLogin(!isLogin);
    };

    return (
        <div className="my-16 flex justify-center">
            <div className="w-3/6 bg-gray-900 rounded-md shadow-2xl">
                <h2 className="pt-12 text-4xl text-center">{isLogin ? "Login" : "Register"}</h2>
                <div className="pt-12 pb-8 flex justify-center">
                    {isLogin ? <LoginForm /> : <RegisterForm />}
                </div>
                <p className="pb-8 text-center">
                    {isLogin ? "Don't have an account yet?" : "Already have an account?"}{' '}
                    <button
                        className="text-blue-500 hover:underline focus:outline-none"
                        onClick={toggleForm}
                    >
                        {isLogin ? 'Register' : 'Login'}
                    </button>
                </p>
            </div>
        </div>
    );
}

export default SigninPage;