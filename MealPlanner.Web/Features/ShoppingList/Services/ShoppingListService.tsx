export async function getShoppingLists() {
  const url = "http://localhost:5088/api/ShoppingList"
  try {
    const response = await fetch(url, {
      method: "GET",
      mode: "cors",
    })
    return await response.json()
  } catch (e) {
    console.log(e)
  }
}

export async function getShoppingList(id: string) {
  const url = `http://localhost:5088/api/ShoppingList/id/${id}`
  try {
    const response = await fetch(url, {
      method: "GET",
      mode: "cors",
    })
    return await response.json()
  } catch (e) {
    console.log(e)
  }
}

export async function createShoppingList(name: string) {
  const url = `http://localhost:5088/api/ShoppingList`
  try {
    const response = await fetch(url, {
      method: "POST",
      mode: "cors",
      body: JSON.stringify(name),
      headers: {
        "Content-Type": "application/json",
      },
    })
    return await response.json()
  } catch (e) {
    console.log(e)
  }
}

export async function AddToShoppingList(request: any) {
  const url = `http://localhost:5088/api/ShoppingList/AddIngredient`
  try {
    const response = await fetch(url, {
      method: "POST",
      mode: "cors",
      body: JSON.stringify(request),
      headers: {
        "Content-Type": "application/json",
      },
    })
    return await response.json()
  } catch (e) {
    console.log(e)
  }
}

export async function updateShoppingList(id: string) {
  const url = `http://localhost:5088/api/ShoppingList/id/${id}`
  try {
    const response = await fetch(url, {
      method: "GET",
      mode: "cors",
    })
    return await response.json()
  } catch (e) {
    console.log(e)
  }
}

export async function deleteShoppingList(id: string) {
  const url = `http://localhost:5088/api/ShoppingList/${id}`
  try {
    const response = await fetch(url, {
      method: "DELETE",
      mode: "cors",
    })
    return await response.json()
  } catch (e) {
    console.log(e)
  }
}
