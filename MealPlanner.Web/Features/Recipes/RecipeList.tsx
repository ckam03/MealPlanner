import { useQuery } from "react-query"
import { getRecipes } from "./RecipesService"

interface recipeProps {
  recipes: any
}
//needs to take in a prop for the ingredient to search
export default function RecipeList({ recipes }: recipeProps) {
    console.log(recipes)
  return (
    <>
      <div className="grid grid-cols-5">
        
        {/* {recipes.map((recipe: Recipe, index: number) => {
          return <div key={index.toString()}>{recipe.label}</div>
        })} */}
      </div>
    </>
  )
}
