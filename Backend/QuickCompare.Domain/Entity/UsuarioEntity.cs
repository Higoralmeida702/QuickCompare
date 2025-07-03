using System.ComponentModel.DataAnnotations;

namespace QuickCompare.Domain.Entity
{
    public class UsuarioEntity
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O email informado não é válido.")]
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}