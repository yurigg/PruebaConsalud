using CONSALUD.Prueba.WebAPI.DTO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CONSALUD.Prueba.WebAPI.Infraestructure
{
    public class FacturasDao
    {
        private readonly FacturasListasDto _ArchivoDatos;
        private readonly IHostingEnvironment _hostingEnvironment;

        public FacturasDao(IOptions<FacturasListasDto> options, IHostingEnvironment hostingEnvironment)
        {
            this._ArchivoDatos = options.Value;
            _hostingEnvironment = hostingEnvironment;
        }

        public List<FacturaCabeceraDto> CargarArchivoDatos()
        {
            List<FacturaCabeceraDto> lCabecera = new List<FacturaCabeceraDto>();
            try
            {
                string contentRootPath = _hostingEnvironment.ContentRootPath;

                string json = File.ReadAllText(Path.Combine(contentRootPath, "JsonEjemplo.json"));
                lCabecera = JsonConvert.DeserializeObject<List<FacturaCabeceraDto>>(json);               

                return lCabecera;
            }
            catch (Exception ex)
            {
                //if (idSolicitudCarga > 0) this._solicitudArchivoRespuestaDao.DeleteSolicitudCargaSync(idSolicitudCarga, solicitudCargaSync.IdTipoArchivo, log);
                throw ex;
            }
        }
    }
}
