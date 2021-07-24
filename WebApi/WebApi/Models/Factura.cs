using System;

#nullable disable

namespace WebApi.Models
{
    public partial class Factura
    {
        public int Id { get; set; }
        public int NumeroFactura { get; set; }
        public DateTime Fecha { get; set; }
        public int TipoDePago { get; set; }
        public string DocumentoCliente { get; set; }
        public string NombreCliente { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Descuento { get; set; }
        public decimal Iva { get; set; }
        public decimal TotalDescuento { get; set; }
        public decimal TotalImpuesto { get; set; }
        public decimal Total { get; set; }
    }
}
