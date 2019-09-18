namespace Vendedores.Models
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int VendedorId { get; set; }
        public Vendedor Vendedor { get; set; }
    }
}