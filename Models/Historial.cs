using System;
using System.Collections.Generic;

namespace PruebaCRUD1.Models;

public partial class Historial
{
    public int IdHistorial { get; set; }

    public int? IdProducto { get; set; }

    public string? Nombre { get; set; }

    public decimal? PrecioUnitario { get; set; }

    public int? Cantidad { get; set; }

    public string? Accion { get; set; }

    public DateTime? FechaAccion { get; set; }

    public string? Detalles { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }
}
