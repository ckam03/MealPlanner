import PantryList from "../Features/Pantry/PantryList"
import { QueryClient, QueryClientProvider } from "react-query"

export default function Pantry() {
  const queryClient = new QueryClient()
  return (
    <>
      <div className="flex w-screen">
        <div className="flex justify-center w-screen py-10">
          <QueryClientProvider client={queryClient}>
            <PantryList />
          </QueryClientProvider>
        </div>
      </div>
    </>
  )
}
