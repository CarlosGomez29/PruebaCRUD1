using System;
using System.Collections.Generic;

namespace PruebaCRUD1.Models;

public partial class Venta
{
    public int IdVentas { get; set; }

    public int? IdProducto { get; set; }

    public decimal? PrecioUnitario { get; set; }

    public int? Cantidad { get; set; }

    public decimal? PrecioTotal { get; set; }

    public DateTime? FechaVenta { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }
}
