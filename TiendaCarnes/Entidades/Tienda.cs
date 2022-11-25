namespace TiendaCarnes.Entidades
{
    public class Tienda
    {
        public int Id { get; set; }
        public string NombreP { get; set; }

        public int Pdisp { get; set; }
        public string Estado { get; set; }

        public List<TiendaProductoProvedoores> TiendaProductoProvedoores { get; set; } 
    }
}
