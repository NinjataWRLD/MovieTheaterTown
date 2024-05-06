function MoviePropForm({ prop, setProp, saveChanges, placeholder }) {
    return (
        <>
            <input value={prop}
                onChange={(e) => setProp(e.target.value)}
                className="text-sm italic ms-3 text-gray-900 border border-gray-300 rounded-md px-3 py-1 mt-1 focus:outline-none focus:ring-indigo-500 focus:border-indigo-500"
                placeholder={placeholder}
            />
            <button className="ms-3 mt-4 bg-orange-900 text-white px-4 py-2 rounded-md hover:bg-orange-700 focus:bg-orange-500"
                onClick={() => saveChanges('add', prop)}>Add</button>
        </>
    );
}

export default MoviePropForm;