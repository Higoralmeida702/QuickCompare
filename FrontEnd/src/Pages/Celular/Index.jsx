import { useState, useEffect } from 'react';
import './Celular.css';
import CelularApi from '../../Services/CelularApi';

const Celular = () => {
  const [products, setProducts] = useState([]);

  useEffect(() => {
    async function LoadProducts() {
      const response = await CelularApi("/ObterTodosCelulares");
      console.log(response.data);
      setProducts(response.data.dados);
    }
    LoadProducts();
  }, []);

  return (
    <div className='container'>
      <div className='layout'>
        </div>
        <section className='celular-section'>
          <div className='celular-lista'>
            {products.map(product => (
              <div key={product.id}>
                <img className="celular-imagem" src="./Images/Iphone/Celular/Apple-iPhone-14-Pro-iPhone-14-Pro-Max-space-black-220907-geo-Photoroom.png" alt="" />
                <div className='celular-detalhes'>
                  <h1>{product.modelo} </h1>
                  <div className='celular-especificacoes'>
                    <div className="especificacoes-item">
                      <img className="especificacao-icone" src="./Images/Icons/hour-svgrepo-com.svg" alt="" />
                      <p>{product.duracaoBateriaAproximada}Hr Aproximada de bateria</p>
                    </div>
                    <div className="especificacoes-item">
                      <img className="especificacao-icone" src="./Images/Icons/ram-memory-svgrepo-com.svg" alt="" />
                      <p>{product.memoriaRam.replace("MemoriaRam", "")} RAM</p>
                    </div>
                    <div className="especificacoes-item">
                      <img className="especificacao-icone" src="./Images/Icons/battery-full-svgrepo-com.svg" alt="" />
                      <p>{product.mah} mAh</p>
                    </div>
                    <div className="especificacoes-item">
                      <img className="especificacao-icone" src="./Images/Icons/screen-share-svgrepo-com.svg" alt="" />
                      <p>{product.tela.polegadas} Pol</p>
                    </div>
                  </div>
                </div>
              </div>
            ))}
          </div>
        </section>
      </div>
      );
};

      export default Celular;
