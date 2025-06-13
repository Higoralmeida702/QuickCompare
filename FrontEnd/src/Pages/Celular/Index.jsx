import { useState, useEffect } from 'react';
import './Celular.css';
import CelularApi from '../../Services/CelularApi';

const Celular = () => {
  const [products, setProducts] = useState([]);
  const [selectMarca, setSelectMarca] = useState("Todas");
  const [selectedPolegadas, setSelectedPolegadas] = useState("Todas");
  const [selectedMemoryRam, setSelectedMemoryRam] = useState("Todas");
  const [selectedCapacidadeArmazenamento, setSelectedCapacidadeArmazenamento] = useState("Todas");

  useEffect(() => {
    async function LoadProducts() {
      const response = await CelularApi("/ObterTodosCelulares");
      console.log(response.data);
      setProducts(response.data.dados);
    }
    LoadProducts();
  }, []);

  const filteredProducts = products.filter(product => {
    const marcaOk = selectMarca === "Todas" || product.marca === selectMarca;
    const polegadasOk =
      selectedPolegadas === "Todas" ||
      product.tela.polegadas.toString() === selectedPolegadas;

    const memoriaRamFormatada = product.memoriaRam.replace("MemoriaRam", "");

    const memoriaOk = selectedMemoryRam === "Todas" || memoriaRamFormatada === selectedMemoryRam;

    const armazenamentoFormatado = product.capacidadeArmazenamento.replace("Armazenamento", "");
    const armazenamentoOk = selectedCapacidadeArmazenamento === "Todas" || armazenamentoFormatado === selectedCapacidadeArmazenamento;
    return marcaOk && polegadasOk && memoriaOk && armazenamentoOk;

  });

  return (
    <div className='container-celular'>
      <aside className='aside-layout'>
        <h2>Filtros</h2>

        <label>
          Marca:
          <select value={selectMarca} onChange={(e) => setSelectMarca(e.target.value)}>
            <option value="Todas">Todas</option>
            <option value="Apple">Apple</option>
            <option value="Samsung">Samsung</option>
          </select>
        </label>

        <label>
          Polegadas:
          <select value={selectedPolegadas} onChange={(e) => setSelectedPolegadas(e.target.value)}>
            <option value="Todas">Todas</option>
            <option value="6">6"</option>
            <option value="6.5">6.5"</option>
            <option value="6.7">6.7"</option>
          </select>
        </label>
        <label>
          Memória RAM:
          <select value={selectedMemoryRam} onChange={(e) => setSelectedMemoryRam(e.target.value)}>
            <option value="Todas">Todas</option>
            <option value="2GB">2 GB</option>
            <option value="4GB">4 GB</option>
            <option value="6GB">6 GB</option>
            <option value="8GB">8 GB</option>
            <option value="12GB">12 GB</option>
            <option value="16GB">16 GB</option>
            <option value="32GB">32 GB</option>
            <option value="64GB">64 GB</option>
          </select>
        </label>
        <label>
          Armazenamento:
          <select value={selectedCapacidadeArmazenamento} onChange={(e) => setSelectedCapacidadeArmazenamento(e.target.value)}>
            <option value="Todas">Todas</option>
            <option value="32GB">32 GB</option>
            <option value="64GB">64 GB</option>
            <option value="128GB">128 GB</option>
            <option value="256GB">256 GB</option>
            <option value="480GB">480 GB</option>
            <option value="512GB">512 GB</option>
            <option value="1TB">1 TB</option>
          </select>
        </label>
      </aside>

      <section className='celular-section'>
        <div className='celular-lista'>
          {filteredProducts.map(product => (
            <div key={product.id}>
              <img className="celular-imagem" src="./Images/Iphone/Celular/Apple-iPhone-14-Pro-iPhone-14-Pro-Max-space-black-220907-geo-Photoroom.png" alt="" />
              <div className='celular-detalhes'>
                <h1>{product.modelo}</h1>
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
