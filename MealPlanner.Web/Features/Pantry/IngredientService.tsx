export async function getIngredients() {
  const url = "https://localhost:7017/api/pantry"
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

export async function createIngredient(name: string) {
  const url = "https://localhost:7017/api/pantry"
  try {
    const response = await fetch(url, {
      method: "POST",
      mode: "cors",
      body: JSON.stringify(name),
      headers: {
        "Content-Type": "application/json",
      },
    })
    const result = await response.json()
    return result
  } catch (e) {
    console.log(e)
  } 
}

export async function deleteIngredient(id: number) {
  const url = "https://localhost:7017/api/pantry"
  try {
    const response = await fetch(url, {
      method: "DELETE",
      mode: "cors",
      body: JSON.stringify(id),
      headers: {
        "Content-Type": "application/json",
      },
    })
    const result = await response.json()
    return result
  } catch (e) {
    console.log(e)
  } 
}
