using CONSALUD.Prueba.WebAPI.DTO;
using CONSALUD.Prueba.WebAPI.Infraestructure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CONSALUD.Prueba.WebAPI.Domain
{
    public class FacturasService
    {

        private readonly FacturasDao _FacturasDao;
        public FacturasService(FacturasDao FacturasDao)
        {
            this._FacturasDao = FacturasDao;
        }

       /// <summary>
       /// -Retornar lista completa de las facturas y calcular el total de cada para cada una de ellas.
       /// </summary>
       /// <returns></returns>
        public List<FacturaCabeceraDto> LeerFactorurasYCalculaTotal()
        {
            try
            {
                List<FacturaCabeceraDto> lCabecera = _FacturasDao.CargarArchivoDatos();

                foreach(FacturaCabeceraDto Dto in lCabecera){

                    Dto.TotalFactura = Dto.DetalleFactura.Sum(i => i.TotalProducto);

                }

                return lCabecera;
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }


        /// <summary>
        /// -Debe retornar las facturas de un comprador según su rut.
        /// </summary>
        /// <param name="Rut"></param>
        /// <returns></returns>
        public List<FacturaCabeceraDto> LeerFacturasPorRut(double Rut)
        {
            try
            {
                List<FacturaCabeceraDto> lCabecera = _FacturasDao.CargarArchivoDatos();
                return lCabecera.Where(i=> i.RUTVendedor == Rut).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// -Debe retornar el comprador que tenga mas compras.
        /// </summary>
        /// <returns></returns>
        public CompradorDto LeerCompradorConMasCompras()
        {
            try
            {
             
                List<FacturaCabeceraDto> lCabecera = LeerFactorurasYCalculaTotal();

                List<CompradorDto> result = lCabecera
                        .GroupBy(l => l.RUTComprador)
                        .Select(cl => new CompradorDto
                        {       
                            RUTComprador = cl.First().RUTComprador,
                            DvComprador = cl.First().DvComprador,
                            DireccionComprador = cl.First().DireccionComprador,
                            ComunaComprador = cl.First().ComunaComprador,
                            RegionComprador = cl.First().RegionComprador,
                            CantidadCompras = cl.Count(),
                            TotalCompra = cl.Sum(x => x.TotalFactura)
                        }).ToList();

                var maxValue = result.Max(x => x.TotalCompra);

                return result.First(x => x.TotalCompra == maxValue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        /// <summary>
        /// -Retornar lista de compradores con el monto total de compras realizadas.
        /// </summary>
        /// <returns></returns>
        public List<CompradorDto> LeerCompradoresConTotalCompras()
        {
            try
            {
                List<FacturaCabeceraDto> lCabecera = LeerFactorurasYCalculaTotal();


                List<CompradorDto> result = lCabecera
                        .GroupBy(l => l.RUTComprador)
                        .Select(cl => new CompradorDto
                        {
                            RUTComprador = cl.First().RUTComprador,
                            DvComprador = cl.First().DvComprador,
                            DireccionComprador = cl.First().DireccionComprador,
                            ComunaComprador = cl.First().ComunaComprador,
                            RegionComprador = cl.First().RegionComprador,
                            CantidadCompras = cl.Count(),
                            TotalCompra = cl.Sum(x=>x.TotalFactura)
                        }).ToList();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// -Retornar lista de facturas agrupadas por comuna, y permitir buscar facturas de una comuna específica.
        /// </summary>
        /// <param name="Comuna"></param>
        /// <returns></returns>
        public object[] LeerAgrupadoPorComunas(Double Comuna)
        {
            object[] objParams;
            try
            { 
                List<FacturaCabeceraDto> lCabecera = LeerFactorurasYCalculaTotal();

                if (Comuna == 0)
                {
                    objParams = lCabecera
                        .GroupBy(l => l.ComunaComprador)
                        .Select(cl => new ComunasVentasDto
                        {
                            ComunaComprador = cl.First().ComunaComprador,
                            RegionComprador = cl.First().RegionComprador,
                            TotalCompra = cl.Sum(x => x.TotalFactura)
                        }).ToArray<object>();                    

                }
                else
                {

                    objParams = lCabecera
                            .GroupBy(l => l.RUTComprador)
                            .Select(cl => new CompradorDto
                            {
                                RUTComprador = cl.First().RUTComprador,
                                DvComprador = cl.First().DvComprador,
                                DireccionComprador = cl.First().DireccionComprador,
                                ComunaComprador = cl.First().ComunaComprador,
                                RegionComprador = cl.First().RegionComprador,
                                CantidadCompras = cl.Count(),
                                TotalCompra = cl.Sum(x => x.TotalFactura)
                            })
                            .Where(cl => cl.ComunaComprador == Comuna)
                            .ToArray<object>();

                }

                return objParams;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
