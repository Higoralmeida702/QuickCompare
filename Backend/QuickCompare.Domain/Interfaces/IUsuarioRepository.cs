using QuickCompare.Domain.Entity;

namespace QuickCompare.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<UsuarioEntity> GetByEmailAsync(string email);
        Task AddAsync(UsuarioEntity user);
    }
}