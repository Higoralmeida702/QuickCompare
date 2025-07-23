using QuickCompare.Application.Dto;
using QuickCompare.Domain.Entity;

namespace QuickCompare.Application.Interfaces
{
    public interface ICompararNotebooks
    {
        ComparacaoResultadosDto CompararNotebook (NotebookEntity notebookA, NotebookEntity notebookB);
    }
}