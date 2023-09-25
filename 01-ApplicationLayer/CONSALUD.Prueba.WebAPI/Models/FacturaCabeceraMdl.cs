using CONSALUD.Prueba.WebAPI.DTO;

namespace CONSALUD.Prueba.WebAPI.Models
{
    public class FacturaCabeceraMdl
    {
        public string NumeroDocumento { get; set; }
        public string RUTVendedor { get; set; }
        public string DvVendedor { get; set; }
        public string RUTComprador { get; set; }
        public string DvComprador { get; set; }
        public string DireccionComprador { get; set; }
        public string ComunaComprador { get; set; }
        public string RegionComprador { get; set; }
        public string TotalFactura { get; set; }
        public FacturaDetalleDto DetalleFactura { get; set; }
    }
}
