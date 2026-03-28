using System.ComponentModel.DataAnnotations;

namespace Abstracciones.Modelos.Seguridad
{
    public class LoginBase
    {
        [Required]
        public string? NombreUsuario { get; set; }
        [Required]
        public string? PasswordHash { get; set; }
        [Required]
        [EmailAddress]
        public string CorreoElectronico { get; set; }
    }
    public class Login : LoginBase
    {
        [Required]
        public Guid Id { get; set; }
    }
    public class LoginRequest : LoginBase
    {
        [Required]
        public string Password { get; set; }
    }
}
