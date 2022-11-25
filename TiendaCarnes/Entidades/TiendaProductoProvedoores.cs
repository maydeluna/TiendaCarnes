namespace TiendaCarnes.Entidades
{
    public class TiendaProductoProvedoores
    {
        public int Orden { get; set; }
        public int TiendaId { get; set; }

        public int ProductodeProvedooresId { get; set; }

        public Tienda Tienda { get; set; }

        public ProductodeProvedoores ProductodeProvedoores { get; set; }
    }
}
