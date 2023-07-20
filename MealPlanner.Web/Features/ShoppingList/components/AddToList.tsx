import React, { useState } from "react"
import { AddToShoppingList } from "../Services/ShoppingListService"

interface addIngredientProps {
  shoppingListId?: string
}

export default function AddToList({ shoppingListId }: addIngredientProps) {
  const [ingredientName, setIngredientName] = useState<string>("")

  const [request, setRequest] = useState<shoppingListItem>()

  // const mutation = useMutation<newIngredient>( AddToShoppingList=> {
  //   onSuccess: () => {
  //     queryClient.invalidateQueries('')
  //   }
  // })
  const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setIngredientName(event.target.value)
  }

  const handleSubmit = (event: { preventDefault: () => void }) => {
    event.preventDefault()

    const newIngredient: ingredient = {
      name: ingredientName,
      amount: 0,
      unit: "grams",
      shoppingListId: shoppingListId,
    }
    //mutation.mutate(request)
    AddToShoppingList(newIngredient).then((x) => console.log(x))
  }
  return (
    <>
      <form onSubmit={handleSubmit}>
        <input
          type="text"
          onChange={handleChange}
          value={ingredientName}
          placeholder="Add Ingredient"
          className="w-full h-12 rounded-lg border-2 border-gray-300"
        />
      </form>
    </>
  )
}
