using QuickCompare.Application.Common;
using QuickCompare.Application.Dto;
using QuickCompare.Domain.Entity;

namespace QuickCompare.Application.Interfaces
{
    public interface INotebookService
    {
        Task<Resposta<NotebookEntity>> AdicionarNotebook(NotebookDto notebookDto);
        Task<Resposta<NotebookEntity>> BuscarNotebookId(int id);
        Task<Resposta<List<NotebookEntity>>> BuscarTodosNotebooks();
        Task<Resposta<NotebookEntity>> ExcluirNotebook(int id);
        Task<Resposta<NotebookDto>> AtualizarNotebook(int id, NotebookDto notebookDto);
    }
}