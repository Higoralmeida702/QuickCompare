import { Link } from 'react-router-dom'
import './Navbar.css'

const Navbar = () => {
    return (
        <div className="navbar-container">
            <header className="navbar-header">
                <nav className="navbar-nav">
                    <ul className="navbar-list">
                        <li className="navbar-item"><Link to="/" className="navbar-link">Home</Link></li>
                        <li className="navbar-item"><Link to="/celular" className="navbar-link">Celular</Link></li>
                        <li className="navbar-item"><Link to="/notebook" className="navbar-link">Notebook</Link></li>
                    </ul>
                </nav>
            </header>
        </div>
    )
}

export default Navbar
