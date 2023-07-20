import { Inter } from "@next/font/google"
import ShoppingList from "../../Features/ShoppingList/components/ShoppingList"

const inter = Inter({
  subsets: [],
  weight: "400",
})

const ShoppingListPage = () => {
  return (
    <div className={inter.className}>
      <div className="flex justify-center">
        <ShoppingList />
      </div>
    </div>
  )
}

export default ShoppingListPage
