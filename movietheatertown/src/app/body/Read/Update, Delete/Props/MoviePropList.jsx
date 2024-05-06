function MoviePropList({ props, saveChanges }) {
    return (
        <ul className="font-normal italic">
            {props.map((prop, id) => {
                return (
                    <li key={id}>
                        <span>{prop}</span>
                        <button className="ms-3 mt-4 bg-red-900 text-white px-4 py-2 rounded-md hover:bg-red-700 focus:bg-red-500"
                            onClick={() => saveChanges('remove', prop)}>Remove</button>
                        <br />
                    </li>
                );
            })}
        </ul>
    );
}

export default MoviePropList;