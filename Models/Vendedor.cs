using System.Collections.Generic;

namespace Vendedores.Models
{
    public class Vendedor
    {
        public int VendedorId { get; set; }
        public string Name { get; set; }

        public ICollection<Producto> Productos { get; set; }

    }
}