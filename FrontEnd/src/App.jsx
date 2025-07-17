import './DefaultStyles.css'
import { BrowserRouter, Route, Routes, Link } from 'react-router-dom'
import Home from './Pages/Home/Index'
import Celular from './Pages/Celular/Index'
import Notebook from './Pages/Notebook/Index'
import Navbar from './Components/Navbar/Index'

function App() {
  return (
    <>
      <BrowserRouter>
      <Navbar/>
        <Routes>
          <Route path="/" element={<Home />}></Route>
          <Route path="/celular" element={<Celular />}></Route>
          <Route path="/notebook" element={<Notebook />}></Route>
        </Routes>
      </BrowserRouter>
    </>
  )
}

export default App
