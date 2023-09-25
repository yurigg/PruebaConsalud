using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONSALUD.Prueba.WebAPI.DTO
{
    public class FacturaCabeceraDto
    {

        public double NumeroDocumento { get; set; }
        public double RUTVendedor { get; set; }
        public string DvVendedor { get; set; }
        public string RUTComprador { get; set; }
        public string DvComprador { get; set; }
        public string DireccionComprador { get; set; }
        public double ComunaComprador { get; set; }
        public double RegionComprador { get; set; }
        public double TotalFactura { get; set; }
        public FacturaDetalleDto[] DetalleFactura { get; set; }

    }
}
