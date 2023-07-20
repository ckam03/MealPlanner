import { Icon } from "@iconify/react"
import { useMutation } from "react-query"
import { deleteIngredient } from "./IngredientService"

interface ingredientProps {
  id: number
  name: string
}

const Ingredient = ({ name, id }: ingredientProps) => {

 const mutation = useMutation({
  mutationFn: deleteIngredient
 });
  return (
    <div className="w-full rounded-lg p-3 flex items-center justify-between space-x-4">
      <div className="flex items-center">
        <input type="checkbox" className="rounded" />
        <div>{name}</div>
      </div>
      <button onClick={() => mutation.mutate(id)}>
        <Icon icon="heroicons:trash" className="h-7 w-7" />
      </button>
    </div>
  )
}

export default Ingredient
