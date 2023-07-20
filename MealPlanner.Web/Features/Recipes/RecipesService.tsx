export async function getRecipes(ingredient: string) {
    const url = `http://localhost:5088/api/Recipe/${ingredient}`
    try {
      const response = await fetch(url, {
        method: "GET",
        mode: "cors",
      })
      const result = await response.json()
      return result
      
    } catch (e) {
      console.log(e)
    }
}