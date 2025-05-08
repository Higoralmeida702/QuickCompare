using Microsoft.EntityFrameworkCore;
using QuickCompare.Domain.Entity;
using QuickCompare.Domain.Interfaces;
using QuickCompare.Infra.Data.Data;

namespace QuickCompare.Infra.Data.Repository
{
    public class NotebookRepository : INotebookRepository
    {
        private readonly ApplicationDbContext _context;

        public NotebookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<NotebookEntity> AdicionarNotebook(NotebookEntity notebook)
        {
            await _context.Notebooks.AddAsync(notebook);
            await _context.SaveChangesAsync();
            return notebook;
        }

        public async Task<NotebookEntity> AtualizarNotebook(int id, NotebookEntity notebook)
        {
            var notebookExistente = await _context.Notebooks.FindAsync(id);
            if (notebookExistente == null)
            {
                throw new Exception("Notebook não encontrado");
            }

            _context.Notebooks.Update(notebook);
            await _context.SaveChangesAsync();
            return notebook;
        }

        public async Task<NotebookEntity> BuscarNotebookId(int id)
        {
            return await _context.Notebooks.FindAsync(id);
        }

        public async Task<List<NotebookEntity>> BuscarTodosNotebooks()
        {
            return await _context.Notebooks.ToListAsync();
        }

        public async Task<NotebookEntity> ExcluirNotebook(int id)
        {
            var notebookExistente = await _context.Notebooks.FindAsync(id);
            if (notebookExistente == null)
            {
                throw new Exception("Notebook não encontrado");
            }

            _context.Notebooks.Remove(notebookExistente);
            await _context.SaveChangesAsync();
            return notebookExistente;
        }
    }
}