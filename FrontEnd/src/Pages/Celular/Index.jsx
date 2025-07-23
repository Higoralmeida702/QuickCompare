import { useState, useEffect } from 'react';
import './Celular.css';
import CelularApi from '../../Services/CelularApi';
import axios from 'axios';

const Celular = () => {
  const [products, setProducts] = useState([]);
  const [selectMarca, setSelectMarca] = useState("Todas");
  const [selectedPolegadas, setSelectedPolegadas] = useState("Todas");
  const [selectedMemoryRam, setSelectedMemoryRam] = useState("Todas");
  const [selectedCapacidadeArmazenamento, setSelectedCapacidadeArmazenamento] = useState("Todas");

  const [selecionadoA, setSelecionadoA] = useState(null);
  const [selecionadoB, setSelecionadoB] = useState(null);
  const [comparando, setComparando] = useState(false);
  const [resultadoComparacao, setResultadoComparacao] = useState(null);

  useEffect(() => {
    async function LoadProducts() {
      const response = await CelularApi("/ObterTodosCelulares");
      setProducts(response.data.dados);
    }
    LoadProducts();
  }, []);

  const filteredProducts = products.filter(product => {
    const marcaOk = selectMarca === "Todas" || product.marca === selectMarca;
    const polegadasOk = selectedPolegadas === "Todas" || product.tela.polegadas.toFixed(1) === parseFloat(selectedPolegadas).toFixed(1);
    const memoriaRamFormatada = product.memoriaRam.replace("MemoriaRam", "");
    const memoriaOk = selectedMemoryRam === "Todas" || memoriaRamFormatada === selectedMemoryRam;
    const armazenamentoFormatado = product.capacidadeArmazenamento.replace("Armazenamento", "");
    const armazenamentoOk = selectedCapacidadeArmazenamento === "Todas" || armazenamentoFormatado === selectedCapacidadeArmazenamento;
    return marcaOk && polegadasOk && memoriaOk && armazenamentoOk;
  });

  const selecionarParaComparar = (celular) => {
    if (!selecionadoA) {
      setSelecionadoA(celular);
    } else if (!selecionadoB && celular.id !== selecionadoA.id) {
      setSelecionadoB(celular);
    } else if (celular.id === selecionadoA.id) {
      setSelecionadoA(null);
    } else if (celular.id === selecionadoB?.id) {
      setSelecionadoB(null);
    }
    setResultadoComparacao(null);
  };

  const comparar = async () => {
    if (!selecionadoA || !selecionadoB) return;
    setComparando(true);
    try {
      const res = await axios.get(`http://localhost:5236/api/comparacao/celular/${selecionadoA.id}/${selecionadoB.id}`);
      setResultadoComparacao(res.data.resultado);
    } catch (error) {
      console.error('Erro na comparação', error);
      setResultadoComparacao({ resultado: 'Erro na comparação' });
    }
    setComparando(false);
  };

  const fecharPopup = () => {
    setResultadoComparacao(null);
  };

  return (
    <div className='container-celular'>
      <aside className='aside-layout'>
        <h2>Filtros</h2>
        <label>
          Marca:
          <select value={selectMarca} onChange={(e) => setSelectMarca(e.target.value)}>
            <option value="Todas">Todas</option>
            <option value="Apple">Apple</option>
            <option value="Motorola">Motorola</option>
            <option value="Xiaomi">Xiaomi</option>
            <option value="Realme">Realme</option>
            <option value="Asus">Asus</option>
            <option value="Infinix">Infinix</option>
            <option value="Huawei">Huawei</option>
            <option value="OnePlus">OnePlus</option>
            <option value="Lenovo">Lenovo</option>
            <option value="Nokia">Nokia</option>
            <option value="Samsung">Samsung</option>
          </select>
        </label>

        <label>
          Polegadas:
          <select value={selectedPolegadas} onChange={(e) => setSelectedPolegadas(e.target.value)}>
            <option value="Todas">Todas</option>
            <option value="6.1">6.1"</option>
            <option value="6.2">6.2"</option>
            <option value="6.3">6.3"</option>
            <option value="6.4">6.4"</option>
            <option value="6.6">6.6"</option>
            <option value="6.67">6.67"</option>
            <option value="6.74">6.74"</option>
            <option value="6.8">6.8"</option>
            <option value="6.9">6.9"</option>
            <option value="7">7"</option>
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
            <div
              key={product.id}
              onClick={() => selecionarParaComparar(product)}
              className={selecionadoA?.id === product.id || selecionadoB?.id === product.id ? 'selecionado' : ''}
            >
              <div className='celular-detalhes'>
                <h1>
                  <span style={{ color: '#007BFF' }}>{product.marca}</span><br />
                  {product.modelo}
                </h1>
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

      {selecionadoA && selecionadoB && (
        <button
          onClick={comparar}
          className="botao-comparar-flutuante"
          disabled={comparando}
        >
          {comparando ? 'Comparando...' : 'Comparar'}
        </button>
      )}

      {resultadoComparacao && (
        <div className="popup-comparacao-backdrop" onClick={fecharPopup}>
          <div className="popup-comparacao" onClick={e => e.stopPropagation()}>
            <h2>Resultado da Comparação</h2>
            <p>{resultadoComparacao.resultado}</p>
            <ul>
              {resultadoComparacao.pontos?.map((ponto, idx) => (
                <li key={idx}>{ponto}</li>
              ))}
            </ul>
            <button onClick={fecharPopup} className="popup-close-btn">Fechar</button>
          </div>
        </div>
      )}
    </div>
  );
};

export default Celular;