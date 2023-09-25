using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONSALUD.Prueba.WebAPI.DTO
{
    public class CompradorDto
    {
        public string RUTComprador { get; set; }
        public string DvComprador { get; set; }
        public string DireccionComprador { get; set; }
        public double ComunaComprador { get; set; }
        public double RegionComprador { get; set; }
        public double CantidadCompras { get; set; }
        public double TotalCompra { get; set; }
    }
}
