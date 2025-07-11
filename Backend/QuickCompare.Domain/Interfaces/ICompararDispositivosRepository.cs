using QuickCompare.Domain.Entity;

namespace QuickCompare.Domain.Interfaces
{
    public interface ICompararDispositivosRepository
    {
        Task<List<CelularEntity>> BuscarCelularPorMarcaOuModelo(string termo);
        Task<List<NotebookEntity>> BuscarNotebookPorMarcaOuModelo(string termo);
    }
}