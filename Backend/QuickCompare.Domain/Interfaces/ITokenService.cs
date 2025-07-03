namespace QuickCompare.Domain.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(Guid usuarioId, string nome, string email);
    }
}