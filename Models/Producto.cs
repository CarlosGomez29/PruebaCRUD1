namespace PruebaCRUD1.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string? Nombre { get; set; }

    public decimal PrecioUnitario { get; set; }

    public int Cantidad { get; set; }

    public bool? Activo { get; set; }

    public DateTime FechaCrea { get; set; }

    public DateTime? FechaMod { get; set; }

    public virtual ICollection<Historial> Historials { get; set; } = new List<Historial>();

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
