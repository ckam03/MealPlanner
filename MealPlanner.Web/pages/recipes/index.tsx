import Navbar from "../../Shared/Navbar"
import RecipeList from "../../Features/Recipes/RecipeList"
import { QueryClient, QueryClientProvider } from "react-query"
import { getRecipes } from "../../Features/Recipes/RecipesService"
import { useState } from "react"
import RecipeBuilder from "../../Features/Recipes/RecipeBuilder"

const queryClient = new QueryClient()

type RecipeData = {
  from: string
  to: string
  hits: string
}

export default function RecipeSearch() {
  const [recipes, setRecipes] = useState<Recipe>()

  const [isOpen, setIsOpen] = useState<boolean>(false)

  function handleSearch() {}

  return (
    <div>
      <QueryClientProvider client={queryClient}>
        <div className="flex justify-center mt-20">

            <RecipeBuilder />
        </div>
      </QueryClientProvider>
    </div>
  )
}
