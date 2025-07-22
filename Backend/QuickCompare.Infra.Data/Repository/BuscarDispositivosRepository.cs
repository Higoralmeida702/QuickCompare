using Microsoft.EntityFrameworkCore;
using QuickCompare.Domain.Entity;
using QuickCompare.Domain.Interfaces;
using QuickCompare.Infra.Data.Data;

namespace QuickCompare.Infra.Data.Repository
{
    public class BuscarDispositivosRepository : IBuscarDispositivosRepository
    {
        private readonly ApplicationDbContext _context;

        public BuscarDispositivosRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CelularEntity>> BuscarCelularPorMarcaOuModelo(string termo)
        {
            return await _context.Celulares
                .Where(c => c.Marca.Contains(termo) || c.Modelo.Contains(termo))
                .ToListAsync();
        }

        public async Task<List<NotebookEntity>> BuscarNotebookPorMarcaOuModelo(string termo)
        {
            return await _context.Notebooks
                .Where(c => c.Marca.Contains(termo) || c.Modelo.Contains(termo))
                .ToListAsync();
        }
    }
}