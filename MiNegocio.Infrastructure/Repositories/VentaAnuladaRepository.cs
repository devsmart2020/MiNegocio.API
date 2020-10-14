using Microsoft.EntityFrameworkCore;
using MiNegocio.Core.Entities;
using MiNegocio.Core.Interfaces;
using MiNegocio.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MiNegocio.Infrastructure.Repositories
{
    public class VentaAnuladaRepository : IVentaAnulada
    {

        private readonly soport43_minegociocyjContext _contextcyj;
        private readonly VentaProductoAnuladaRepository _ventaProductoAnulada;
        private ProductoRepository _productoRepository;



        public VentaAnuladaRepository(soport43_minegociocyjContext contextcyj)
        {
            _contextcyj = contextcyj;
            _ventaProductoAnulada = new VentaProductoAnuladaRepository(_contextcyj);
            _productoRepository = new ProductoRepository(contextcyj);

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
            bool returnValue = false;

            //Consultamos Venta
            Tbventa tbventa = await _contextcyj.Tbventa
                .Where(x => x.IdVenta.Equals(entity.IdVenta))
                .FirstOrDefaultAsync();
            //VentaAnulada
            Tbventaanulada tbventaanulada = new Tbventaanulada()
            {
                IdVenta = tbventa.IdVenta,
                IdCliente = tbventa.IdCliente,
                Fecha = tbventa.Fecha,
                IdOrden = tbventa.IdOrden,
                IdFormaPago = tbventa.IdFormaPago,
                IdUsuario = tbventa.IdUsuario,
                IdNegocio = tbventa.IdNegocio,
                Observaciones = tbventa.Observaciones
            };
            //Consultamos DetalleVenta
            List<Tbventaproducto> detalleVenta = await _contextcyj.Tbventaproducto
               .Where(x => x.IdVenta.Equals(tbventaanulada.IdVenta))
                   .ToListAsync();
            if (detalleVenta.Count > 0)
            {
                List<Tbventaproductoanulada> vtaProdAnulada = new List<Tbventaproductoanulada>();
                //Guardamos detalleAnulado TbVtaProdAnulada              
                foreach (Tbventaproducto item in detalleVenta)
                {
                    vtaProdAnulada.Add(new Tbventaproductoanulada
                    {
                        IdVenta = item.IdVenta,
                        IdProducto = item.IdProducto,
                        Cantidad = item.Cantidad,
                        VlrProducto = item.VlrProducto,
                        Descuento = item.Descuento,
                        Serial1 = item.Serial1,
                        Serial2 = item.Serial2
                    });
                }
                await _contextcyj.Tbventaproductoanulada.AddRangeAsync(vtaProdAnulada);
                var dtlleVtaAnualadaQuery = await _contextcyj.SaveChangesAsync();
                if (dtlleVtaAnualadaQuery > 0)
                {
                    //Modificamos existencias
                    foreach (var item in vtaProdAnulada)
                    {
                        Tbproducto tbproducto = await _contextcyj.Tbproducto
                            .Where(x => x.IdProducto == item.IdProducto)
                            .FirstOrDefaultAsync();

                    }
                }


                if (vtaProdAnulada.Count > 0)
                {






                    returnValue = true;
                    //Modificamos existencias y guardamos VtaProductoAnulada         
                    for (int i = 0; i < vtaProdAnulada.Count; i++)
                    {
                        Tbproducto tbproducto = await _productoRepository.GetById(vtaProdAnulada[i].IdProducto);                       
                        //Descontar de inventario
                        int cantidad = vtaProdAnulada[i].Cantidad;
                        if (!string.IsNullOrEmpty(tbproducto.IdProducto))
                        {
                            tbproducto.Existencia = tbproducto.Existencia + cantidad;
                            //var desccuenta = await _contextcyj.SaveChangesAsync();
                            //if (desccuenta > 0)
                            //{
                            //    returnValue = true;
                            //}
                        }
                        await _contextcyj.Tbventaproductoanulada.AddAsync(vtaProdAnulada[i]);
                        //Tbproducto producto = await (from p in _contextcyj.Tbproducto
                        //                             where p.IdProducto == vtaProdAnulada[i].IdProducto
                        //                             select p).FirstOrDefaultAsync();
                        //producto.Existencia = producto.Existencia - cantidad;
                        //var descuenta = await _contextcyj.SaveChangesAsync();
                    }
                    int VTaProdAnuladDctaQuery = await _contextcyj.SaveChangesAsync();
                    if (VTaProdAnuladDctaQuery > 0)
                    {
                        returnValue = true;
                        //Eliminamos DetalleVenta
                        _contextcyj.Tbventaproducto.RemoveRange(detalleVenta);
                        var vtaProdElimina = await _contextcyj.SaveChangesAsync();
                        if (vtaProdElimina > 0)
                        {
                            returnValue = true;
                            //Guardamos VentaAnulada TbVentaAnulada
                            await _contextcyj.Tbventaanulada.AddAsync(tbventaanulada);
                            var saveVtaAnulada = _contextcyj.SaveChanges();
                            if (saveVtaAnulada > 0)
                            {
                                returnValue = true;
                                //Eliminamos Tbventa
                                var vtaBorrar = await _contextcyj.Tbventa.FindAsync(tbventa.IdVenta);
                                if (vtaBorrar != null)
                                {
                                    returnValue = true;
                                    _contextcyj.Tbventa.Remove(vtaBorrar);
                                    var eliminaventa = await _contextcyj.SaveChangesAsync();
                                    if (eliminaventa > 0)
                                    {
                                        returnValue = true;
                                    }
                                    else //No se borró Venta TbVenta
                                    {
                                        returnValue = false;
                                    }
                                }
                                else //NO se econtró Vta TbVenta
                                {
                                    returnValue = false;
                                }
                            }
                            else //NO Se guardó VtaAnulada
                            {
                                returnValue = false;
                            }

                        }
                        else //No se Elimino VtaProducto
                        {
                            returnValue = false;

                        }
                    }
                    else //No se guardo vtaProductoAnulada o descontó del inventario
                    {
                        returnValue = false;
                    }
                }
                else //VtarodcutoAnuladaList Vacia
                {
                    returnValue = false;

                }
            }
            else  //No DetalleVenta
            {
                returnValue = false;
            }

            return returnValue;
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
