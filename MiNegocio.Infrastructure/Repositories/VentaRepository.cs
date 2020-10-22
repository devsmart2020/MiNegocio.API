using Microsoft.EntityFrameworkCore;
using MiNegocio.Core.Entities;
using MiNegocio.Core.Interfaces;
using MiNegocio.Core.ReportsEntities;
using MiNegocio.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace MiNegocio.Infrastructure.Repositories
{

    public class VentaRepository : IVentaRepository
    {
        private readonly soport43_minegociocyjContext _contextcyj;

        public VentaRepository(soport43_minegociocyjContext contextcyj)
        {
            _contextcyj = contextcyj;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _contextcyj.Tbventa.FindAsync(id);
            if (entity != null)
            {
                _contextcyj.Tbventa.Remove(entity);
                await _contextcyj.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Exists(int id)
        {
            return await _contextcyj.Tbventa.AnyAsync(x => x.IdVenta == id);

        }

        public async Task<IEnumerable<Tbventa>> Get()
        {
            var entities = await _contextcyj.Tbventa.ToListAsync();
            return entities;
        }

        public async Task<Tbventa> GetById(int id)
        {
            var entity = await _contextcyj.Tbventa.FindAsync(id);
            if (entity != null)
            {
                return entity;
            }
            else
            {
                return null;
            }
        }

        public async Task<Tbventa> Post(Tbventa entity)
        {

            await _contextcyj.Tbventa.AddAsync(entity);
            var query = _contextcyj.SaveChanges();
            if (query > 0)
            {
                return entity;
            }
            else
            {
                return null;
            }
        }

        public async Task<Tbventa> Put(int id, Tbventa entity)
        {
            var query = await _contextcyj.SaveChangesAsync();
            if (query > 0)
            {
                return entity;
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<VentasxFecha>> VentasxFecha(DateTime fchaIni, DateTime fchaFin)
        {
            IEnumerable<VentasxFecha> venta = await _contextcyj.Tbventa
                .Where(x => x.Fecha.Date >= fchaIni.Date && x.Fecha.Date <= fchaFin.Date)
                .Select(x => new VentasxFecha()
                {
                    IdVenta = (int)x.IdVenta,
                    Documento = x.IdCliente,
                    Cliente = x.IdClienteNavigation.Nombres + " " + x.IdClienteNavigation.Apellidos,
                    Fecha = x.Fecha,
                    FormaPago = x.IdFormaPagoNavigation.FormaPago,
                    Observaciones = x.Observaciones,
                    FechaIni = fchaIni,
                    FechaFin = fchaFin
                })
                .OrderBy(x => x.IdVenta)
                .ToListAsync();
            return venta;
        }

        public async Task<IEnumerable<VentasDetalleVentaxFecha>> DetalleVentaxFecha(DateTime fchaIni, DateTime fchaFin)
        {
            IEnumerable<VentasDetalleVentaxFecha> ventaProducto = await _contextcyj.Tbventaproducto
                 .Where(x => x.IdVentaNavigation.Fecha.Date >= fchaIni.Date && x.IdVentaNavigation.Fecha.Date <= fchaFin.Date)
                 .Select(x => new VentasDetalleVentaxFecha()
                 {
                     Factura = x.IdVenta,
                     Documento = x.IdVentaNavigation.IdCliente,
                     Cliente = x.IdVentaNavigation.IdClienteNavigation.Nombres + " " + x.IdVentaNavigation.IdClienteNavigation.Apellidos,
                     FormaPago = x.IdVentaNavigation.IdFormaPagoNavigation.FormaPago,
                     Fecha = x.IdVentaNavigation.Fecha,
                     IdProducto = x.IdProducto,
                     Producto = x.IdProductoNavigation.Producto,
                     VlrCompra = (x.Cantidad * x.IdProductoNavigation.VlrVenta) - x.Descuento,
                     Cantidad = x.Cantidad,
                     Descuento = x.Descuento,
                     Total = (x.Cantidad * x.IdProductoNavigation.VlrVenta) - x.Descuento,
                     FechaIni = fchaIni,
                     FechaFin = fchaFin
                 })
                 .OrderBy(x => x.Factura)
                 .ToListAsync();
            foreach (var item in ventaProducto)
            {
                if (item.FormaPago == "CRÉDITO")
                {
                    item.Total = 0;

                }
            }
            return ventaProducto;
        }

        public async Task<IEnumerable<VentasLiquidacionxFecha>> LiquidacionVentaxFecha(DateTime fchaIni, DateTime fchaFin)
        {
            IEnumerable<VentasLiquidacionxFecha> liquidacionxFechas = await _contextcyj.Tbventaproducto
                .Where(x => x.IdVentaNavigation.Fecha.Date >= fchaIni.Date && x.IdVentaNavigation.Fecha.Date <= fchaFin.Date)
                .Select(x => new VentasLiquidacionxFecha()
                {
                    Factura = x.IdVenta,
                    Fecha = x.IdVentaNavigation.Fecha,
                    IdProducto = x.IdProducto,
                    Producto = x.IdProductoNavigation.Producto,
                    FormaPago = x.IdVentaNavigation.IdFormaPagoNavigation.FormaPago,
                    CostoProducto = x.IdProductoNavigation.Costo,
                    Cantidad = x.Cantidad,
                    VlrVenta = x.VlrProducto,
                    Descuento = x.Descuento,
                    VlrCompra = (x.Cantidad * x.VlrProducto) - x.Descuento,
                    TotalVenta = (x.Cantidad * x.VlrProducto) - x.Descuento,
                    FechaIni = fchaIni,
                    FechaFin = fchaFin,
                    TotalCosto = x.Cantidad * x.IdProductoNavigation.Costo,
                    TotalGanancia = (x.VlrProducto * x.Cantidad - x.Descuento) - (x.IdProductoNavigation.Costo * x.Cantidad)
                })
                .OrderBy(x => x.Factura)
                .ToListAsync();
            foreach (var item in liquidacionxFechas)
            {
                if (item.FormaPago == "CRÉDITO")
                {
                    item.TotalVenta = 0;
                    item.TotalGanancia = 0;
                }
            }
            return liquidacionxFechas;
        }

        public async Task<IEnumerable<VentasRemisionVenta>> RemisionVenta(VentasRemisionVenta entity)
        {
            IEnumerable<VentasRemisionVenta> ventasRemision = await _contextcyj.Tbventa
            .Where(x => x.IdVenta.Equals(entity.IdVenta))
            .Select(x => new VentasRemisionVenta()
            {
                IdVenta = (int)x.IdVenta,
                IdCliente = x.IdCliente,
                NomCliente = $"{x.IdClienteNavigation.Nombres} {x.IdClienteNavigation.Apellidos}",
                TelCliente = x.IdClienteNavigation.Telefono,
                DireccionCliente = x.IdClienteNavigation.Direccion,
                Fecha = x.Fecha,
                IdOrden = x.IdOrden,
                FormaPago = x.IdFormaPagoNavigation.FormaPago,
                Usuario = x.IdUsuarioNavigation.Nombres,
                Observaciones = x.Observaciones,
                NombreNegocio = x.IdNegocioNavigation.Nombre,
                Nit = x.IdNegocio,
                Direccion = x.IdNegocioNavigation.Direccion,
                Telefono = x.IdNegocioNavigation.Telefono,
                TelefonoAlterno = x.IdNegocioNavigation.TelefonoAlterno,
                IdTitular = x.IdNegocioNavigation.IdTitular,
                TitularNombre = x.IdNegocioNavigation.TitularNombre,
                TelTitular = x.IdNegocioNavigation.TelTitular,
                CtaBancoTitular = x.IdNegocioNavigation.CtaBancoTitular,
                TipoCuentaTitular = x.IdNegocioNavigation.TipoCuentaTitular,
                Regimen = x.IdNegocioNavigation.Regimen,
                PermisoTic = x.IdNegocioNavigation.PermisoTic,
                Imagen = x.IdNegocioNavigation.Imagen
            })
             .ToListAsync();
            return ventasRemision;
        }

        public async Task<IEnumerable<VentasDetalleRemisionVenta>> DetalleRemision(VentasDetalleRemisionVenta entity)
        {
            IEnumerable<VentasDetalleRemisionVenta> ventasDetalles = await _contextcyj.Tbventaproducto
                .Where(x => x.IdVenta.Equals(entity.IdVenta))
                .Select(x => new VentasDetalleRemisionVenta()
                {
                    IdProducto = x.IdProducto,
                    Producto = x.IdProductoNavigation.Producto,
                    Cantidad = x.Cantidad,
                    Descuento = x.Descuento,
                    Total = (x.Cantidad * x.IdProductoNavigation.VlrVenta)
                })
                .ToListAsync();
            return ventasDetalles;
        }
        public async Task<IEnumerable<VentasPorCliente>> VentaPorCliente(VentasPorCliente entity)
        {
            IEnumerable<VentasPorCliente> ventaCliente = await _contextcyj.Tbventa
                .Where(x => x.IdVenta.Equals(entity.Venta) || x.IdCliente.Equals(entity.IdCliente)
                || x.IdClienteNavigation.Nombres.Equals(entity.Cliente) || x.Fecha.Date == entity.Fecha.Date)
                .Select(x => new VentasPorCliente
                {
                    Venta = x.IdVenta,
                    IdCliente = x.IdCliente,
                    Cliente = $"{x.IdClienteNavigation.Nombres} {x.IdClienteNavigation.Apellidos}",
                    Teléfono = x.IdClienteNavigation.Telefono,
                    Dirección = x.IdClienteNavigation.Direccion,
                    Fecha = x.Fecha,
                    IdOrden = x.IdOrden,
                    FormaPago = x.IdFormaPagoNavigation.FormaPago,
                    Usuario = x.IdUsuarioNavigation.Nombres,
                    Observaciones = x.Observaciones

                }).ToListAsync();
            return ventaCliente;
        }

        public async Task<IEnumerable<VentasxUsuario>> VentasxUsuarios(VentasxUsuario entity)
        {
            IEnumerable<VentasxUsuario> ventasxUsuarios = await _contextcyj.Tbventaproducto
                 .Where(x => x.IdVentaNavigation.IdUsuario.Equals(entity.IdUsuario) 
                 && x.IdVentaNavigation.Fecha.Date >= entity.FechaIni.Date && x.IdVentaNavigation.Fecha.Date <= entity.FechaFin.Date)
                 .Select(x => new VentasxUsuario()
                 {
                     Factura = x.IdVenta,
                     Documento = x.IdVentaNavigation.IdCliente,
                     Cliente = x.IdVentaNavigation.IdClienteNavigation.Nombres + " " + x.IdVentaNavigation.IdClienteNavigation.Apellidos,
                     FormaPago = x.IdVentaNavigation.IdFormaPagoNavigation.FormaPago,
                     Fecha = x.IdVentaNavigation.Fecha,
                     IdProducto = x.IdProducto,
                     Producto = x.IdProductoNavigation.Producto,
                     VlrCompra = (x.Cantidad * x.IdProductoNavigation.VlrVenta) - x.Descuento,
                     Cantidad = x.Cantidad,
                     Descuento = x.Descuento,
                     Total = (x.Cantidad * x.IdProductoNavigation.VlrVenta) - x.Descuento,
                     FechaIni = entity.FechaIni,
                     FechaFin = entity.FechaFin,
                     IdUsuario = x.IdVentaNavigation.IdUsuario,
                     Usuario = $"{x.IdVentaNavigation.IdUsuarioNavigation.Nombres} {x.IdVentaNavigation.IdUsuarioNavigation.Apellidos}"
                 })
                 .OrderBy(x => x.Factura)
                 .ToListAsync();
            foreach (var item in ventasxUsuarios)
            {
                if (item.FormaPago == "CRÉDITO")
                {
                    item.Total = 0;
                }
            }

            return ventasxUsuarios;
        }
    }
}