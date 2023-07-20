import { useQuery } from "react-query"
import Spinner from "../../../Shared/Spinner"
import { getShoppingLists } from "../Services/ShoppingListService"
import ShoppingListMenuItem from "./ShoppingListMenuItem"
import { PlusIcon } from "@heroicons/react/24/outline"
import { useState } from "react"
import CreateList from "./CreateList"

interface shoppingListMenuProps {
  handleShoppingList: any
}

export default function ShoppingListMenu({
  handleShoppingList,
}: shoppingListMenuProps) {
  const [open, setOpen] = useState<boolean>(false)
  const { status, data, error } = useQuery("ShoppingLists", getShoppingLists)

  return (
    <div className="w-80 h-full border-r-2 border-gray-200">
      <ul className="py-2 px-3 space-y-2 w-full">
        <h1 className="text-xl font-semibold py-2">Shopping Lists</h1>
        {status === "loading" 
          ? <Spinner /> 
          : data.map((shoppingList: shoppingList) => {
          return (
            <div
              key={shoppingList.id}
              onClick={() => {
                handleShoppingList(shoppingList)
                console.log(shoppingList.name)
              }}
            >
              <ShoppingListMenuItem shoppingList={shoppingList} />
            </div>
          )
        })}
        <div className="flex justify-center">
          <button
            onClick={() => setOpen(!open)}
            className="flex h-12 w-32 justify-center items-center border rounded-lg bg-blue-500 text-blue-100"
          >
            <PlusIcon className="h-6 w-6" />
            Create List
          </button>
        </div>
        {open && <CreateList isOpen={open} />}
      </ul>
    </div>
  )
}
