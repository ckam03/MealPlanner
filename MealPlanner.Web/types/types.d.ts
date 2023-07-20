type shoppingList = {
    id: string,
    name: string,
    shoppingListItems: []
}

type shoppingListItem = {
    id: string,
    name: string,
    amount: number,
    unit: string
    shoppingListId: string
}

type ingredient = {
    name: string,
    amount: number,
    unit: string,
    shoppingListId?: string
}

type Recipe = {
    image: string, 
    label: string,
    shareAs: string,
    source: string
}