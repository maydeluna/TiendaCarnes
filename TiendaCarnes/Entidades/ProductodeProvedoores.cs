using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaCarnes.Entidades
{
    public class ProductodeProvedoores
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public List<TiendaProductoProvedoores> TiendaProductoProvedoores { get; set; }
    }
}
