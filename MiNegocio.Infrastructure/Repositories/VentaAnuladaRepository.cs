using Microsoft.EntityFrameworkCore;
using MiNegocio.Core.Entities;
using MiNegocio.Core.Interfaces;
using MiNegocio.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiNegocio.Infrastructure.Repositories
{
    public class VentaAnuladaRepository : IVentaAnulada
    {

        private readonly soport43_minegociocyjContext _contextcyj;
        private readonly VentaProductoAnuladaRepository _ventaProductoAnulada;       

        public VentaAnuladaRepository(soport43_minegociocyjContext contextcyj)
        {
            _contextcyj = contextcyj;
            _ventaProductoAnulada = new VentaProductoAnuladaRepository(_contextcyj);

        }
      

        public Task<bool> Delete(Tbventaanulada entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Tbventaanulada>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Tbventaanulada> GetById(Tbventaanulada entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Post(Tbventaanulada entity)
        {
            //Consultamos Venta
            var tbventa = await _contextcyj.Tbventa
                .Where(x => x.IdVenta.Equals(entity.IdVenta))
                .FirstOrDefaultAsync();
            //Guardamos VentaAnulada
            Tbventaanulada tbventaanulada = new Tbventaanulada()
            {
                IdVenta = tbventa.IdVenta,
                IdCliente = tbventa.IdCliente,
                Fecha = tbventa.Fecha,
                IdOrden = tbventa.IdOrden,
                IdFormaPago = tbventa.IdFormaPago,
                IdUsuario = tbventa.IdUsuario,
                IdNegocio = tbventa.IdNegocio,
                Observaciones = tbventa.Observaciones,
                
                
            };
            await _contextcyj.Tbventaanulada.AddAsync(tbventaanulada);
            var query = _contextcyj.SaveChanges();
            if (query > 0)
            {
                SavedVentaAnulada = true;

                //Consultamos DetalleVenta
                var detalleVenta = await _contextcyj.Tbventaproducto
                    .Where(x => x.IdVenta.Equals(tbventaanulada.IdVenta))
                    .ToListAsync();
                if (detalleVenta.Count > 0)
                {
                    NullDetalleVenta = true;
                    //Guardamos DetalleVenta
                    List<Tbventaproductoanulada> tbventaproductoanuladas = new List<Tbventaproductoanulada>();
                    foreach (var item in detalleVenta)
                    {
                        tbventaproductoanuladas.Add(new Tbventaproductoanulada()
                        {
                            IdVenta = item.IdVenta,
                            IdProducto = item.IdProducto,
                            Cantidad = item.Cantidad,
                            VlrProducto = item.VlrProducto,
                            Descuento = item.Descuento
                        });
                    }
                    await _contextcyj.Tbventaproductoanulada.AddRangeAsync(tbventaproductoanuladas);
                    var detalleAnulada = await _contextcyj.SaveChangesAsync();
                    if (detalleAnulada > 0)
                    {
                        SavedVentaProductoAnulada = true;
                        //Definimos Producto y ProductoSerial Para Sumar a Inventario
                        List<Tbproducto> tbproductos = new List<Tbproducto>();
                        List<Tbproductoserial> tbproductoserials = new List<Tbproductoserial>();
                        foreach (var item in tbventaproductoanuladas)
                        {

                            tbproductos = await _contextcyj.Tbproducto
                                .Where(x => x.IdProducto.Equals(item.IdProducto))
                                .ToListAsync();
                            if (tbproductos.Count > 0)
                            {
                                NullTbProductos = true;
                                if (item.IdProductoNavigation.IdTipoProducto.Equals(2)) // Si es Equipo
                                {
                                    //ProductoSerial
                                    Tbproductoserial tbproductoserial = new Tbproductoserial()
                                    {
                                        IdProducto = item.IdProducto,
                                        //Serie1 = item.IdProductoNavigation.idpr
                                    };
                                    tbproductoserials = await _contextcyj.Tbproductoserial
                                       .ToListAsync();
                                    if (tbproductoserials.Count > 0)
                                    {
                                        NullTbProductoSerial = true;
                                        await _contextcyj.AddRangeAsync(tbproductoserials);
                                        var productoSerial = await _contextcyj.SaveChangesAsync();
                                        if (productoSerial > 0)
                                        {
                                            SavedTbProductoSerial = true;
                                        }
                                        else
                                        {
                                            SavedTbProductoSerial = false;
                                        }
                                    }
                                    else
                                    {
                                        NullTbProductoSerial = false;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                NullTbProductos = false;
                                break;
                            }

                            //Sumar Producto en inventario
                            for (int i = 0; i < tbventaproductoanuladas.Count; i++)
                            {
                                int cantidad = tbventaproductoanuladas[i].Cantidad;
                                Tbproducto tbproducto = await _contextcyj.Tbproducto
                                    .Where(x => x.IdProducto.Equals(tbventaproductoanuladas[i].IdProducto))
                                    .FirstOrDefaultAsync();
                                tbproducto.Existencia += cantidad;
                                var suma = await _contextcyj.SaveChangesAsync();
                            }
                        }
                    }
                    else
                    {
                        SavedVentaProductoAnulada = false;
                    }
                }
                else
                {
                    NullDetalleVenta = false;
                }
            }
            else
            {
                SavedVentaAnulada = false;
            }

            if (SavedVentaAnulada && SavedVentaProductoAnulada && NullDetalleVenta && NullTbProductos
                && SavedTbProductoSerial)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Task<bool> Put(Tbventaanulada entity)
        {
            throw new NotImplementedException();
        }


        private bool SavedVentaAnulada { get; set; } = false;
        private bool SavedVentaProductoAnulada { get; set; } = false;
        private bool NullDetalleVenta { get; set; } = false;
        private bool NullTbProductos { get; set; } = false;
        private bool NullTbProductoSerial { get; set; } = false;
        private bool SavedTbProductoSerial { get; set; } = false;

    }
}
