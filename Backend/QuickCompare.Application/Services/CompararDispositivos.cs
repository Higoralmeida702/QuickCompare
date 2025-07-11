using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuickCompare.Application.Interfaces;
using QuickCompare.Domain.Entity;
using QuickCompare.Domain.Interfaces;

namespace QuickCompare.Application.Services
{
    public class CompararDispositivos : ICompararDispositivosService
    {
        private readonly ICompararDispositivosRepository _compararDispositivosRepository;

        public CompararDispositivos(ICompararDispositivosRepository compararDispositivosRepository)
        {
            _compararDispositivosRepository = compararDispositivosRepository;
        }

        public async Task<List<CelularEntity>> BuscarCelularPorMarcaOuModelo(string termo)
        {
            return await _compararDispositivosRepository.BuscarCelularPorMarcaOuModelo(termo);
        }

        public async Task<List<NotebookEntity>> BuscarNotebookPorMarcaOuModelo(string termo)
        {
            return await _compararDispositivosRepository.BuscarNotebookPorMarcaOuModelo(termo);
        }
    }
}