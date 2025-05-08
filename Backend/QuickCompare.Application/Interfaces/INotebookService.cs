using QuickCompare.Application.Dto;
using QuickCompare.Domain.Entity;

namespace QuickCompare.Application.Interfaces
{
    public interface INotebookService
    {
        Task<NotebookEntity> AdicionarNotebook(NotebookDto notebookDto);
        Task<NotebookEntity> BuscarNotebookId(int id);
        Task<List<NotebookEntity>> BuscarTodosNotebooks();
        Task<NotebookEntity> ExcluirNotebook(int id);
        Task<NotebookDto> AtualizarNotebook(int id, NotebookDto notebookDto);
    }
}