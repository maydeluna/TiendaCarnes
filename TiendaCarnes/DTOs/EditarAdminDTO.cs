using System.ComponentModel.DataAnnotations;

namespace TiendaCarnes.DTOs
{
    public class EditarAdminDTO
    {
        [Required]
        [EmailAddress]

        public string Email { get; set; }
    }
}
