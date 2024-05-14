function Home() {
    return (
        <div className="container space-y-8 mt-5">
            <h1 className="text-4xl text-center">Hi!</h1>
            <h3 className="text-2xl text-center">Have a passion for movies?</h3>
            <div>
                <div className="flex flex-row justify-center">
                    <img src="kitty.jpg" className="w-80 h-80" />
                </div>
                <p className="text-center">you?</p>
            </div>
            <h2 className="text-3xl text-center">You're at the right place!</h2>
        </div>
    );
}

export default Home;