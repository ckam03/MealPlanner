import { QueryClient, QueryClientProvider } from "react-query"
import ShoppingListMenu from "./ShoppingListMenu"
import ShoppingListItems from "./ShoppingListItems"
import { useState } from "react"
import AddToList from "./AddToList";

const queryClient = new QueryClient()

export default function ShoppingList() {
  const [items, setItems] = useState<shoppingListItem[]>([])

  const [shoppingList, setShoppingList] = useState<shoppingList>()
    
  function handleShoppingListItems(shoppingList: shoppingList) {
    setItems(shoppingList.shoppingListItems)
    setShoppingList(shoppingList)
  }

  return (
    <div className="shadow-md w-[48rem] min-h-[36rem] rounded-lg flex mt-20 bg-white">
      <QueryClientProvider client={queryClient}>       
      <ShoppingListMenu handleShoppingList={handleShoppingListItems}/>
      <div className="w-full p-3 space-y-3">
        <h1 className="font-medium py-2 text-lg">{shoppingList?.name}</h1>
        <AddToList shoppingListId={shoppingList?.id} />
        <ShoppingListItems items={items} />
      </div>
      </QueryClientProvider>
    </div>
  )
}

