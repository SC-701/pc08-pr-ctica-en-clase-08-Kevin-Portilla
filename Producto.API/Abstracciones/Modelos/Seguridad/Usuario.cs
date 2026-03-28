using System.ComponentModel.DataAnnotations;

namespace Abstracciones.Modelos.Seguridad
{
        public class UsuarioBase
        {

            [Required]
            public string NombreUsuario { get; set; }
            [Required]
            public string? PasswordHash { get; set; }
            [Required]
            [EmailAddress]
            public string CorreoElectronico { get; set; }
        }
        public class Usuario : UsuarioBase
        {
            [Required]
            public string Password { get; set; }
            public string ConfirmarPassword { get; set; }

        }
    }
