using System.ComponentModel.DataAnnotations;

namespace Abstracciones.Modelos
{
    public class ProductoBase
    {
        [Required(ErrorMessage = "El nombre del producto es requerido")]
        [StringLength(100, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres", MinimumLength = 3)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La descripción del producto es requerida")]
        [StringLength(500, ErrorMessage = "La descripción debe tener entre 10 y 500 caracteres", MinimumLength = 10)]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El precio del producto es requerido")]
        [Range(0.01, 999999.99, ErrorMessage = "El precio debe estar entre 0.01 y 999999.99")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "El stock del producto es requerido")]
        [Range(0, 100000, ErrorMessage = "El stock debe estar entre 0 y 100000")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "El código de barras es requerido")]
        [RegularExpression(@"^\d{13}$", ErrorMessage = "El código de barras debe tener exactamente 13 dígitos")]
        public string CodigoBarras { get; set; }
    }

    public class ProductoRequest : ProductoBase
    {
        [Required(ErrorMessage = "El ID de subcategoría es requerido")]
        [RegularExpression(@"^[{]?[0-9a-fA-F]{8}-([0-9a-fA-F]{4}-){3}[0-9a-fA-F]{12}[}]?$",
            ErrorMessage = "El formato del ID de subcategoría no es válido")]
        public Guid IdSubCategoria { get; set; }
    }

    public class ProductoResponse : ProductoBase
    {
        public Guid Id { get; set; }
        public string? SubCategoria { get; set; }
        public string? Categoria { get; set; }
    }

    public class ProductoDetalleResponse : ProductoResponse
    {
        public decimal PrecioUSD { get; set; }
    }
}