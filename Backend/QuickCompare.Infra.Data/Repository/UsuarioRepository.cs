using Microsoft.EntityFrameworkCore;
using QuickCompare.Domain.Entity;
using QuickCompare.Domain.Interfaces;
using QuickCompare.Infra.Data.Data;

namespace QuickCompare.Infra.Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UsuarioEntity> GetByEmailAsync(string email)
            => await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);

        public async Task AddAsync(UsuarioEntity user)
        {
            _context.Usuarios.Add(user);
            await _context.SaveChangesAsync();
        }
    }
}