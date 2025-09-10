using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PruebaCRUD1.DTOs
{
    public class ProductoDTO
    {        
        public int IdProducto { get; set; }

        [Required (ErrorMessage = "El nombre es obligatorio")]
        [StringLength (200, ErrorMessage = "El nombre no puede tener mas de 200 caracteres")]
        public string? Nombre { get; set; }

        [Required (ErrorMessage = "El precio unitario es obligatorio")]
        [Range (1, double.MaxValue, ErrorMessage = "El precio debe ser valido y mayor que cero")]
        public decimal PrecioUnitario { get; set; }

        [Required(ErrorMessage = "La cantidad es obligatoria")]
        [Range (1, int.MaxValue, ErrorMessage = "La cantidad debe ser valida y mayor que cero")]
        public int Cantidad { get; set; }

        public DateTime? FechaCrea { get; set; }
    }
}
