using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONSALUD.Prueba.WebAPI.DTO
{
     public class FacturaDetalleDto
    {
        public double CantidadProducto { get; set; }
        public ProductoDto Producto { get; set; }
        public double TotalProducto { get; set; }

    }
}
