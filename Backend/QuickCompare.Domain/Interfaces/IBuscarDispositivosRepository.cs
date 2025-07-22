using QuickCompare.Domain.Entity;

namespace QuickCompare.Domain.Interfaces
{
    public interface IBuscarDispositivosRepository
    {
        Task<List<CelularEntity>> BuscarCelularPorMarcaOuModelo(string termo);
        Task<List<NotebookEntity>> BuscarNotebookPorMarcaOuModelo(string termo);
    }
}