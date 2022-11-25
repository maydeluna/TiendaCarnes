using System.ComponentModel.DataAnnotations;

namespace TiendaCarnes.DTOs
{
    public class CredencialesCliente
    {
        [Required]
        [EmailAddress]

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
