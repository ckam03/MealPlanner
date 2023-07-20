import ShoppingListItem from "./ShoppingListItem";

interface shoppingListItemsProps {
  items: shoppingListItem[]
}

export default function ShoppingListItems({ items }: shoppingListItemsProps) {
    console.log(items);
    
  return (
    <div className="space-y-3">
      {items.map((item: shoppingListItem) => {
        return <ShoppingListItem item={item} />
      })}
    </div>
  )
}
