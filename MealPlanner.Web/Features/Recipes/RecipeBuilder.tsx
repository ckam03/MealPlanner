export default function RecipeBuilder() {
  return (
    <div className="w-[40rem] bg-white rounded-md shadow py-10">
      <div className="space-y-6 flex flex-col justify-center items-center">
        <span className="text-2xl">Add Recipe</span>
        <div className="space-y-2">
          <h1 className="text-lg font-semibold">Title</h1>
          <input type="text" className="rounded-md w-[28rem] border-gray-300" />
        </div>
        <input type="file" />
        <div className="space-y-2">
          <h2 className="text-lg font-semibold">Description</h2>
          <input type="text" className="rounded-md w-[28rem] border-gray-300" />
        </div>
        <div className="space-y-2">
          <h3 className="text-lg font-semibold">Ingredients</h3>
          <input type="text" className="rounded-md w-[28rem] border-gray-300" />
        </div>
        <div className="space-y-2">
          <h4 className="text-lg font-semibold">Instructions</h4>
          <input type="text" className="rounded-md w-[28rem] border-gray-300" />
        </div>
        <div className="space-y-2">
          <h5 className="text-lg font-semibold"># of Servings</h5>
          <input type="text" className="rounded-md w-[28rem] border-gray-300" />
        </div>
        <button className="border bg-blue-500 text-blue-100 h-12 w-32 rounded-lg">Save Recipe</button>
      </div>
    </div>
  )
}
