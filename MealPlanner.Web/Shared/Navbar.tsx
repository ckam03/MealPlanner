import Link from "next/link";
import { Icon } from "@iconify/react";

export default function Navbar() {
    return (
        <>
            <nav className="shadow-md h-14 flex items-center justify-around">
                <ul className="h-full flex items-center space-x-8">
                    <h1 className="text-2xl">Mealie</h1>
                    <Link href={"/"} className="hover:text-blue-500">
                        Home
                    </Link>
                    <Link href={"/recipes"} className="hover:text-blue-500">
                        Recipes
                    </Link>
                    <Link href={"/pantry"} className="hover:text-blue-500">
                        Pantry
                    </Link>
                    <Link href={"/shopping-list"} className="hover:text-blue-500">
                        Shopping List
                    </Link>
                </ul>
                <Icon icon="heroicons:user-circle-solid" className="h-8 w-8 hover:text-blue-500" />
            </nav>
        </>
    )
}