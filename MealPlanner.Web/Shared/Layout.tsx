import Navbar from "./Navbar"

interface LayoutProps {
  children: any
}

export default function Layout({ children }: LayoutProps) {
  return (
    <div className="w-screen h-screen relative">
      <main className="h-full bg-gray-100">
        <Navbar />
        {children}
      </main>
    </div>
  )
}
