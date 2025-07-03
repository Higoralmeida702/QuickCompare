using QuickCompare.Application.Dto;
using QuickCompare.Application.Interfaces;
using QuickCompare.Domain.Entity;
using QuickCompare.Domain.Interfaces;

namespace QuickCompare.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUsuarioRepository _userRepository;
        private readonly ITokenService _tokenService;

        public AuthService(IUsuarioRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public async Task<AuthRespostaDto> RegisterAsync(RegistrarUsuarioDto dto)
        {
            var exists = await _userRepository.GetByEmailAsync(dto.Email);
            if (exists != null)
                throw new ArgumentException("Usuário já existe.");

            var user = new UsuarioEntity
            {
                Id = Guid.NewGuid(),
                Nome = dto.Nome,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };

            await _userRepository.AddAsync(user);

            var token = _tokenService.GenerateToken(user.Id, user.Nome, user.Email);
            return new AuthRespostaDto { Token = token, Nome = user.Nome };
        }

        public async Task<AuthRespostaDto> LoginAsync(LoginUsuarioDto dto)
        {
            var user = await _userRepository.GetByEmailAsync(dto.Email)
                       ?? throw new ArgumentException("Usuário não encontrado.");

            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                throw new ArgumentException("Credenciais inválidas.");

            var token = _tokenService.GenerateToken(user.Id, user.Nome, user.Email);
            return new AuthRespostaDto { Token = token, Nome = user.Nome };
        }
    }
}