using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi.Models
{
    public partial class Producto
    {
        public int Id { get; set; }
        public int IdFactura { get; set; }
        public string NombreProducto { get; set; }
    }
}
