using QuickCompare.Domain.Entity;

namespace QuickCompare.Domain.Interfaces
{
    public interface INotebookRepository
    {
        Task<NotebookEntity> AdicionarNotebook(NotebookEntity notebook);
        Task<NotebookEntity> BuscarNotebookId(int id);
        Task<List<NotebookEntity>> BuscarTodosNotebooks();
        Task<NotebookEntity> ExcluirNotebook(int id);
        Task<NotebookEntity> AtualizarNotebook(int id, NotebookEntity notebook);
    }
}