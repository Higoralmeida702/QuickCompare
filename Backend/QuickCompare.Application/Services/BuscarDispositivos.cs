using QuickCompare.Application.Interfaces;
using QuickCompare.Domain.Entity;
using QuickCompare.Domain.Interfaces;

namespace QuickCompare.Application.Services
{
    public class BuscarDispositivos : IBuscarDispositivosService
    {
        private readonly IBuscarDispositivosRepository _buscarDispositivosRepository;

        public BuscarDispositivos(IBuscarDispositivosRepository buscarDispositivosRepository)
        {
            _buscarDispositivosRepository = buscarDispositivosRepository;
        }

        public async Task<List<CelularEntity>> BuscarCelularPorMarcaOuModelo(string termo)
        {
            return await _buscarDispositivosRepository.BuscarCelularPorMarcaOuModelo(termo);
        }

        public async Task<List<NotebookEntity>> BuscarNotebookPorMarcaOuModelo(string termo)
        {
            return await _buscarDispositivosRepository.BuscarNotebookPorMarcaOuModelo(termo);
        }
    }
}