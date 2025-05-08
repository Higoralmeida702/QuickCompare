using QuickCompare.Application.Dto;
using QuickCompare.Application.Interfaces;
using QuickCompare.Domain.Entity;
using QuickCompare.Domain.Interfaces;

namespace QuickCompare.Application.Services
{
    public class NotebookService : INotebookService
    {
        private readonly INotebookRepository _repository;

        public NotebookService(INotebookRepository repository)
        {
            _repository = repository;
        }

        public async Task<NotebookEntity> AdicionarNotebook(NotebookDto notebookDto)
        {
            var notebook = new NotebookEntity
            (
                notebookDto.Marca,
                notebookDto.Modelo,
                notebookDto.Espessura,
                notebookDto.Peso,
                notebookDto.Mah,
                notebookDto.DuracaoBateriaAproximada,
                notebookDto.CapacidadeArmazenamento,
                notebookDto.MemoriaRam,
                notebookDto.TipoAparelho,
                notebookDto.Tela,
                notebookDto.Processador,
                notebookDto.PlacaDeVideo,
                notebookDto.QuantidadePortasUsb20,
                notebookDto.QuantidadePortasUsb32,
                notebookDto.EntradaC,
                notebookDto.MemoriaRamExpansivel,
                notebookDto.CapacidadeArmazenamentoExpansivel,
                notebookDto.WebCam,
                notebookDto.GeracaoMemoriaRam,
                notebookDto.FrequenciaMemoriaRam
            );

            return await _repository.AdicionarNotebook(notebook);
        }

        public async Task<NotebookDto> AtualizarNotebook(int id, NotebookDto notebookDto)
        {
            var notebookExistente = await _repository.BuscarNotebookId(id);
            if (notebookExistente == null)
            {
                throw new Exception("Notebook não encontrado");
            }

            notebookExistente.Update
            (
                notebookDto.Marca,
                notebookDto.Modelo,
                notebookDto.Espessura,
                notebookDto.Peso,
                notebookDto.Mah,
                notebookDto.DuracaoBateriaAproximada,
                notebookDto.CapacidadeArmazenamento,
                notebookDto.MemoriaRam,
                notebookDto.TipoAparelho,
                notebookDto.Tela,
                notebookDto.Processador,
                notebookDto.PlacaDeVideo,
                notebookDto.QuantidadePortasUsb20,
                notebookDto.QuantidadePortasUsb32,
                notebookDto.EntradaC,
                notebookDto.MemoriaRamExpansivel,
                notebookDto.CapacidadeArmazenamentoExpansivel,
                notebookDto.WebCam,
                notebookDto.GeracaoMemoriaRam,
                notebookDto.FrequenciaMemoriaRam
            );

            await _repository.AtualizarNotebook(id, notebookExistente);

            return new NotebookDto
            {
                Marca = notebookExistente.Marca,
                Modelo = notebookExistente.Modelo,
                Espessura = notebookExistente.Espessura,
                Peso = notebookExistente.Peso,
                Mah = notebookExistente.Mah,
                DuracaoBateriaAproximada = notebookExistente.DuracaoBateriaAproximada,
                CapacidadeArmazenamento = notebookExistente.CapacidadeArmazenamento,
                MemoriaRam = notebookExistente.MemoriaRam,
                TipoAparelho = notebookExistente.TipoAparelho,
                Tela = notebookExistente.Tela,
                Processador = notebookExistente.Processador,
                PlacaDeVideo = notebookExistente.PlacaDeVideo,
                QuantidadePortasUsb20 = notebookExistente.QuantidadePortasUsb20,
                QuantidadePortasUsb32 = notebookExistente.QuantidadePortasUsb32,
                EntradaC = notebookExistente.EntradaC,
                MemoriaRamExpansivel = notebookExistente.MemoriaRamExpansivel,
                CapacidadeArmazenamentoExpansivel = notebookExistente.CapacidadeArmazenamentoExpansivel,
                WebCam = notebookExistente.WebCam,
                GeracaoMemoriaRam = notebookExistente.GeracaoMemoriaRam,
                FrequenciaMemoriaRam = notebookExistente.FrequenciaMemoriaRam
            };
        }

        public async Task<NotebookEntity> BuscarNotebookId(int id)
        {
            return await _repository.BuscarNotebookId(id);
        }

        public Task<List<NotebookEntity>> BuscarTodosNotebooks()
        {
            throw new NotImplementedException();
        }

        public Task<NotebookEntity> ExcluirNotebook(int id)
        {
            throw new NotImplementedException();
        }
    }
}