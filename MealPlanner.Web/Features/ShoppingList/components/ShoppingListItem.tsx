interface shoppingListItemProps {
  item: shoppingListItem
}

export default function ShoppingListItem({ item }: shoppingListItemProps) {
  return (
    <div className="w-full rounded bg-gray-50 py-2 px-4 shadow-md flex justify-between">
      {item.name}
      <input type="checkbox" className="rounded h-5 w-5" />
    </div>
  )
}
