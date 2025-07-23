import { useState, useEffect, useMemo } from 'react';
import './Notebook.css';
import NotebookApi from '../../Services/NotebookApi';
import axios from 'axios';

const Notebook = () => {
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
    async function loadNotebooks() {
      const response = await NotebookApi.get("/ObterTodosNotebooks");
      setProducts(response.data.dados);
    }
    loadNotebooks();
  }, []);

  const formatarMemoria = mem => mem.replace("MemoriaRam", "");
  const formatarArmazenamento = arm => arm.replace("Armazenamento", "");

  const filteredProducts = useMemo(() => {
    return products.filter(prod => {
      const marcaOk = selectMarca === "Todas" || prod.marca === selectMarca;
      const polegadasOk = selectedPolegadas === "Todas" || prod.tela.polegadas.toString() === selectedPolegadas;
      const memoriaOk = selectedMemoryRam === "Todas" || formatarMemoria(prod.memoriaRam) === selectedMemoryRam;
      const armazenamentoOk = selectedCapacidadeArmazenamento === "Todas" || formatarArmazenamento(prod.capacidadeArmazenamento) === selectedCapacidadeArmazenamento;
      return marcaOk && polegadasOk && memoriaOk && armazenamentoOk;
    });
  }, [products, selectMarca, selectedPolegadas, selectedMemoryRam, selectedCapacidadeArmazenamento]);

  const selecionarParaComparar = (item) => {
    if (!selecionadoA || item.id === selecionadoA.id) {
      setSelecionadoA(selecionadoA?.id === item.id ? null : item);
    } else if (!selecionadoB || item.id === selecionadoB.id) {
      setSelecionadoB(selecionadoB?.id === item.id ? null : item);
    }
    setResultadoComparacao(null);
  };

  const comparar = async () => {
    if (!selecionadoA || !selecionadoB) return;
    setComparando(true);
    try {
      const res = await axios.get(
        `http://localhost:5236/api/comparacao/notebook/${selecionadoA.id}/${selecionadoB.id}`
      );
      const data = res.data.resultado || res.data;
      setResultadoComparacao(data);
    } catch (error) {
      console.error('Erro na comparação', error);
      setResultadoComparacao({ Resultado: 'Erro na comparação', Pontos: [] });
    }
    setComparando(false);
  };

  const fecharPopup = () => setResultadoComparacao(null);

  return (
    <div className='container-notebook'>
      <aside className='aside-layout'>
        <h2>Filtros</h2>

        <label>
          Marca:
          <select value={selectMarca} onChange={e => setSelectMarca(e.target.value)}>
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
          <select value={selectedPolegadas} onChange={e => setSelectedPolegadas(e.target.value)}>
            <option value="Todas">Todas</option>
            <option value="13">13"</option>
            <option value="14">14"</option>
            <option value="15.6">15.6"</option>
            <option value="17">17"</option>
          </select>
        </label>

        <label>
          Memória RAM:
          <select value={selectedMemoryRam} onChange={e => setSelectedMemoryRam(e.target.value)}>
            <option value="Todas">Todas</option>
            {["4GB", "8GB", "16GB", "32GB", "64GB"].map(mem => (
              <option key={mem} value={mem}>{mem}</option>
            ))}
          </select>
        </label>

        <label>
          Armazenamento:
          <select value={selectedCapacidadeArmazenamento} onChange={e => setSelectedCapacidadeArmazenamento(e.target.value)}>
            <option value="Todas">Todas</option>
            {["256GB", "480GB", "512GB", "1TB", "2TB"].map(arm => (
              <option key={arm} value={arm}>{arm}</option>
            ))}
          </select>
        </label>
      </aside>

      <section className='notebook-section'>
        <div className='notebook-lista'>
          {filteredProducts.map(prod => (
            <div
              key={prod.id}
              onClick={() => selecionarParaComparar(prod)}
              className={(selecionadoA?.id === prod.id || selecionadoB?.id === prod.id) ? 'selecionado' : ''}
            >
              <div className='notebook-detalhes'>
                <h1>{prod.modelo} - {prod.processador}</h1>
                <div className='notebook-especificacoes'>
                  <div className="especificacoes-item">
                    <img className="especificacao-icone" src="./Images/Icons/processor-svgrepo-com.svg" alt="Processador"/>
                    <p>{prod.processador}</p>
                  </div>
                  <div className="especificacoes-item">
                    <img className="especificacao-icone" src="./Images/Icons/video-card-svgrepo-com.svg" alt="Vídeo"/>
                    <p>{prod.placaDeVideo}</p>
                  </div>
                  <div className="especificacoes-item">
                    <img className="especificacao-icone" src="./Images/Icons/ram-memory-svgrepo-com.svg" alt="RAM"/>
                    <p>{formatarMemoria(prod.memoriaRam)} RAM</p>
                  </div>
                  <div className="especificacoes-item">
                    <img className="especificacao-icone" src="./Images/Icons/ssd-square-svgrepo-com.svg" alt="Armazenamento"/>
                    <p>{formatarArmazenamento(prod.capacidadeArmazenamento)}</p>
                  </div>
                  <div className="especificacoes-item">
                    <img className="especificacao-icone" src="./Images/Icons/monitor-screen-rectangle-svgrepo-com.svg" alt="Tela"/>
                    <p>{prod.tela.polegadas} Pol</p>
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
            <p>{resultadoComparacao.Resultado || resultadoComparacao.resultado}</p>
            <ul>
              {(resultadoComparacao.Pontos || resultadoComparacao.pontos || []).map((p, idx) => (
                <li key={idx}>{p}</li>
              ))}
            </ul>
            <button onClick={fecharPopup} className="popup-close-btn">Fechar</button>
          </div>
        </div>
      )}
    </div>
  );
};

export default Notebook;
