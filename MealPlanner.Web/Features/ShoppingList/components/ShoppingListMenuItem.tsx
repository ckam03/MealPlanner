import { useState } from "react"
import ShoppingListItems from "./ShoppingListItems"
import Dropdown from "./Dropdown"

interface shoppingListMenuItemProps {
  shoppingList: shoppingList
}

export default function ShoppingListMenuItem({
  shoppingList,
}: shoppingListMenuItemProps) {
  let text: string

  return (
    <div className="flex justify-between items-center">
      <div className="h-16 w-full rounded-lg flex flex-col justify-center">
        <h1 className="font-medium">{shoppingList.name}</h1>
        <span className="text-sm">
          {shoppingList.shoppingListItems.length +
            (text =
              shoppingList.shoppingListItems.length > 1 ||
              shoppingList.shoppingListItems.length === 0
                ? " items"
                : " item")}
        </span>
      </div>
      <Dropdown id={shoppingList.id} />   
    </div>
  )
}
