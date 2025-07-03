using QuickCompare.Application.Dto;

namespace QuickCompare.Application.Interfaces
{
    public interface IAuthService
    {
        Task<AuthRespostaDto> RegisterAsync(RegistrarUsuarioDto dto);
        Task<AuthRespostaDto> LoginAsync(LoginUsuarioDto dto);
    }
}