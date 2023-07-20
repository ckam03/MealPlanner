import "../styles/globals.css"
import type { AppProps } from "next/app"
import { Inter } from "@next/font/google"
import Layout from "../Shared/Layout"

const inter = Inter({
  subsets: [],
  weight: "400",
})

function MyApp({ Component, pageProps }: AppProps) {
  return (
    <div className={inter.className}>
      <Layout>
        <Component {...pageProps} />
      </Layout>
    </div>
  )
}

export default MyApp
