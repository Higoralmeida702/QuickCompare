import './Home.css'

const Home = () => {
    return (
        <div className='container'>
            <div>
                <h1 className='tituloCard tituloDestaque'>Ficha técnica clara.<br />Comparação inteligente.</h1>
            </div>
            <div className="card-grid primeiro-card">
                <div className="card-item"></div>
                <div className="card-item"></div>
                <div className="card-item"></div>
                <div className="card-item"></div>
                <div className="card-item"></div>
                <div className="card-item"></div>
                <div className="card-item"></div>
                <div className="card-item"></div>
            </div>
            <div>
                <h1 className='tituloCard titulosSegundarios'>Simplicidade e poder.</h1>
                <div className="card-grid segundo-card">
                    <div className="card-sub-item"></div>
                    <div className="card-sub-item"></div>
                    <div className="card-sub-item"></div>
                    <div className="card-sub-item"></div>
                </div>
            </div>
            <div>
                <h1 className='tituloCard titulosSegundarios'>Detalhes que fazem a diferença.</h1>
                <div className="card-grid terceiro-card">
                    <div className="card-sub-item card-sub-item--terceiro"></div>
                    <div className="card-sub-item card-sub-item--terceiro"></div>
                    <div className="card-sub-item card-sub-item--terceiro"></div>
                </div>
            </div>
        </div>
    )
}

export default Home
