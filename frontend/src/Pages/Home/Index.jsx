import './Home.css'

const Home = () => {
    return (
        <div className='container'>
            <div>
                <h1 className='tituloCard tituloDestaque'>Ficha técnica clara.<br />Comparação inteligente.</h1>
            </div>
            <div className="card-grid primeiro-card">
                <div className="card-item">
                    <img src="./Images/Icons/document-add-svgrepo-com.png" alt="Especificações completas" className="icon" />
                    <p className='textoIcone'>Especificações completas</p>
                </div>
                <div className="card-item">
                    <img src="./Images/Icons/data-line-svgrepo-com.png" alt="Dados que importam" className="icon" />
                    <p className='textoIcone'>Dados que importam</p>
                </div>
                <div className="card-item">
                    <img src="./Images/Icons/compare-svgrepo-com.png" alt="Compare item por item" className="icon" />
                    <p className='textoIcone'>Compare item por item</p>
                </div>
                <div className="card-item">
                    <img src="./Images/Icons/scissor-svgrepo-com.png" alt="Ficha técnica sem enrolação" className="icon" />
                    <p className='textoIcone'>Ficha técnica sem enrolação</p>
                </div>
                <div className="card-item">
                    <img src="./Images/Icons/processor-svgrepo-com.png" alt="Do processador à bateria" className="icon" />
                    <p className='textoIcone'> Do processador à bateria</p>
                </div>
            </div>

            <section>

            <h1 className='tituloCard titulosSegundarios'>Simplicidade e poder.</h1>
            <div>
                <div className="card-grid segundo-card">
                    <div className="card-sub-item">
                        <img src="./Images/Iphone/Ipad/apple_ipad-pro-spring21_hero_04202021.jpg" alt="" className='imagem' />
                    </div>
                    <div className="card-sub-item">
                        <img src="./Images/Samsung/Celulares/Galaxy_S23_Series_02.jpg" alt="" className='imagem' />
                    </div>
                    <div className="card-sub-item">
                        <img src="./Images/Iphone/Ipad/Apple-iPad-Pro-Magic-Keyboard-M2-hero-2up-221018.jpg" alt="" className='imagem' />
                    </div>
                    <div className="card-sub-item">
                        <img src="./Images/Samsung/Celulares/0_bkpT44GsUf2l5XER.jpg" alt="" className='imagem img3' />
                    </div>

                </div>
            </div>
            </section>
        </div>
    )
}

export default Home