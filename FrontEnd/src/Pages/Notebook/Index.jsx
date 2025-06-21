import { useState, useEffect } from 'react';
import './Notebook.css';
import NotebookApi from '../../Services/NotebookApi';

const Notebook = () => {
  const [products, setProducts] = useState([]);
  const [selectMarca, setSelectMarca] = useState("Todas");
  const [selectedPolegadas, setSelectedPolegadas] = useState("Todas");
  const [selectedMemoryRam, setSelectedMemoryRam] = useState("Todas");
  const [selectedCapacidadeArmazenamento, setSelectedCapacidadeArmazenamento] = useState("Todas");

  useEffect(() => {
    async function LoadProducts() {
      const response = await NotebookApi.get("/ObterTodosNotebooks");
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
    <div className='container-notebook'>
      <aside className='aside-layout'>
        <h2>Filtros</h2>

        <label>
          Marca:
          <select value={selectMarca} onChange={(e) => setSelectMarca(e.target.value)}>
            <option value="Todas">Todas</option>
            <option value="Acer">Acer</option>
            <option value="Asus">Asus</option>
            <option value="Dell">Dell</option>
            <option value="HP">HP</option>
            <option value="Lenovo">Lenovo</option>
            <option value="Apple">Apple</option>
          </select>
        </label>

        <label>
          Polegadas:
          <select value={selectedPolegadas} onChange={(e) => setSelectedPolegadas(e.target.value)}>
            <option value="Todas">Todas</option>
            <option value="13">13"</option>
            <option value="14">14"</option>
            <option value="15.6">15.6"</option>
            <option value="17">17"</option>
          </select>
        </label>
        <label>
          Memória RAM:
          <select value={selectedMemoryRam} onChange={(e) => setSelectedMemoryRam(e.target.value)}>
            <option value="Todas">Todas</option>
            <option value="4GB">4 GB</option>
            <option value="8GB">8 GB</option>
            <option value="16GB">16 GB</option>
            <option value="32GB">32 GB</option>
            <option value="64GB">64 GB</option>
          </select>
        </label>
        <label>
          Armazenamento:
          <select value={selectedCapacidadeArmazenamento} onChange={(e) => setSelectedCapacidadeArmazenamento(e.target.value)}>
            <option value="Todas">Todas</option>
            <option value="256GB">256 GB</option>
            <option value="480GB">480 GB</option>
            <option value="512GB">512 GB</option>
            <option value="1TB">1 TB</option>
            <option value="2TB">2 TB</option>
          </select>
        </label>
      </aside>

      <section className='notebook-section'>
        <div className='notebook-lista'>
          {filteredProducts.map(product => (
            <div key={product.id}>
             {/* <img className="notebook-imagem" src="./Images/Notebook/NotebookPadrao.png" alt="" /> */}
              <div className='notebook-detalhes'>
                <h1>{product.modelo} - {product.processador} </h1>
                <div className='notebook-especificacoes'>
                  <div className="especificacoes-item">
                    <img className="especificacao-icone" src="./Images/Icons/processor-svgrepo-com.png" alt="" />
                    <p>{product.placaDeVideo}</p>
                  </div>
                  <div className="especificacoes-item">
                    <img className="especificacao-icone" src="./Images/Icons/ram-memory-svgrepo-com.svg" alt="" />
                    <p>{product.memoriaRam.replace("MemoriaRam", "")} RAM</p>
                  </div>
                  <div className="especificacoes-item">
                    <img className="especificacao-icone" src="./Images/Icons/ssd-round-svgrepo-com.svg" alt="" />
                    <p>{product.capacidadeArmazenamento.replace("Armazenamento", "")} SSD</p>
                  </div>
                  <div className="especificacoes-item">
                    <img className="especificacao-icone" src="./Images/Icons/monitor-screen-rectangle-svgrepo-com.svg" alt="" />
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

export default Notebook;
