using QuickCompare.Application.Common;
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

        public async Task<Resposta<NotebookEntity>> AdicionarNotebook(NotebookDto notebookDto)
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

            await _repository.AdicionarNotebook(notebook);
            return RespostaPadrao<NotebookEntity>(notebook, "Notebook adicionado com sucesso");
        }

        public async Task<Resposta<NotebookDto>> AtualizarNotebook(int id, NotebookDto notebookDto)
        {
            var notebookExistente = await _repository.BuscarNotebookId(id);
            if (notebookExistente == null)
            {
                return RespostaPadrao<NotebookDto>(null, "Notebook não encontrado", false);
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

            var notebookAtualizado = new NotebookDto
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

            return RespostaPadrao<NotebookDto>(notebookAtualizado, "Informações do notebook atualizadas com sucesso");
        }

        public async Task<Resposta<NotebookEntity>> BuscarNotebookId(int id)
        {
            var notebook = await _repository.BuscarNotebookId(id);
            if (notebook == null)
            {
                return RespostaPadrao<NotebookEntity>(null, "Notebook não localizado", false);
            }

            return RespostaPadrao<NotebookEntity>(notebook, "Notebook encontrado com sucesso");
        }

        public async Task<Resposta<List<NotebookEntity>>> BuscarTodosNotebooks()
        {
            var notebook = await _repository.BuscarTodosNotebooks();
            return RespostaPadrao<List<NotebookEntity>>(notebook, "Lista de notebook obtida com sucesso");
        }

        public async Task<Resposta<NotebookEntity>> ExcluirNotebook(int id)
        {
            var noteobokId = await _repository.BuscarNotebookId(id);

            if (noteobokId == null)
            {
                return RespostaPadrao<NotebookEntity>(null, "Notebook não localizado", false);
            }

            await _repository.ExcluirNotebook(id);
            return RespostaPadrao<NotebookEntity>(noteobokId, "Notebook excluido com sucesso");
        }

        private static Resposta<T> RespostaPadrao<T>(T? dados, string mensagem, bool status = true)
        {
            return new Resposta<T>
            {
                Dados = dados,
                Mensagem = mensagem,
                Status = status
            };
        }
    }
}