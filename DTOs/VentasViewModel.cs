namespace PruebaCRUD1.DTOs
{
    public class VentasViewModel
    {
        public int IdVentas { get; set; }

        public int? IdProducto { get; set; }

        public string? Nombre { get; set; }

        public decimal? PrecioUnitario { get; set; }

        public int? Cantidad { get; set; }

        public decimal? PrecioTotal { get; set; }

        public DateTime? FechaVenta { get; set; }
    }

}
