using QuickCompare.Domain.Entity;

namespace QuickCompare.Application.Interfaces
{
    public interface IBuscarDispositivosService
    {
        Task<List<CelularEntity>> BuscarCelularPorMarcaOuModelo(string termo);
        Task<List<NotebookEntity>> BuscarNotebookPorMarcaOuModelo(string termo);
    }
}