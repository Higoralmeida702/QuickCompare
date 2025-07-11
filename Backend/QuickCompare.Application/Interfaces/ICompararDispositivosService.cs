using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuickCompare.Domain.Entity;

namespace QuickCompare.Application.Interfaces
{
    public interface ICompararDispositivosService
    {
        Task<List<CelularEntity>> BuscarCelularPorMarcaOuModelo(string termo);
        Task<List<NotebookEntity>> BuscarNotebookPorMarcaOuModelo(string termo);
    }
}