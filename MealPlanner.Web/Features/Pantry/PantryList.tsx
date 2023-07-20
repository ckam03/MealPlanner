import { getIngredients } from "./IngredientService"
import Ingredient from "./Ingredient"
import { useQuery } from "react-query"
import Spinner from "../../Shared/Spinner"

interface ingredient {
  id: number
  name: string
}

const PantryList = () => {
  const { status, data, error } = useQuery("pantry", getIngredients)

  if (status === "loading") {
    return <Spinner />
  }
  console.log(data);
  
  return (
    <div className="w-96 border-2 shadow-md rounded-lg">
      <h1 className="text-center text-xl py-4">Pantry</h1>
      <ul className="divide-y-2">
        {data.map((ingredient: ingredient, index: number) => {
          return (
            <li key={index.toString()}>
              <Ingredient id={ingredient.id} name={ingredient.name} />
            </li>
          )
        })}
      </ul>
    </div>
  )
}

export default PantryList
