using CONSALUD.Prueba.WebAPI.DTO;

namespace CONSALUD.Prueba.WebAPI.Models
{
    public class FacturaDetalleMdl
    {
        public double CantidadProducto { get; set; }
        public ProductoDto Producto { get; set; }
        public string TotalProducto { get; set; }
    }
}
