using MiNegocio.Core.Entities;
using MiNegocio.Core.ReportsEntities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiNegocio.Core.Interfaces
{
    public interface IVentaRepository
    {
        Task<IEnumerable<Tbventa>> Get();
        Task<Tbventa> Post(Tbventa entity);
        Task<Tbventa> GetById(int id);
        Task<Tbventa> Put(int id, Tbventa entity);
        Task<bool> Delete(int id);
        Task<bool> Exists(int id);
        Task<bool> AnularVenta(IList<VentasDetalleRemisionVenta> entity);
        Task<IEnumerable<VentasPorCliente>> VentaPorCliente(VentasPorCliente entity);
        Task<IEnumerable<VentasxFecha>> VentasxFecha(DateTime fchaIni, DateTime fchaFin);
        Task<IEnumerable<VentasDetalleVentaxFecha>> DetalleVentaxFecha(DateTime fchaIni, DateTime fchaFin);
        Task<IEnumerable<VentasLiquidacionxFecha>> LiquidacionVentaxFecha(DateTime fchaIni, DateTime fchaFin);
        Task<IEnumerable<VentasRemisionVenta>> RemisionVenta(VentasRemisionVenta entity);
        Task<IEnumerable<VentasDetalleRemisionVenta>> DetalleRemision(VentasDetalleRemisionVenta entity);

    }
}
