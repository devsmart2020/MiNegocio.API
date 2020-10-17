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
        private ProductoSerialRepository _productoSerial;
        private ProductoRepository _productoRepository;



        public VentaAnuladaRepository(soport43_minegociocyjContext contextcyj)
        {
            _contextcyj = contextcyj;
            _productoSerial = new ProductoSerialRepository(contextcyj);
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
            //Consultamos DetalleVenta
            List<Tbventaproducto> detalleVenta = await _contextcyj.Tbventaproducto
               .Where(x => x.IdVenta.Equals(tbventa.IdVenta))
                   .ToListAsync();
            //Asignamos VentaAnulada
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
            //Guardamos VentaAnulada
            await _contextcyj.AddAsync(tbventaanulada);
            var queryVtaAnuluada = await _contextcyj.SaveChangesAsync();
            if (queryVtaAnuluada > 0)
            {
                if (detalleVenta.Count > 0)
                {
                    List<Tbventaproductoanulada> vtaProdAnulada = new List<Tbventaproductoanulada>();
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
                    _contextcyj.Tbventaproductoanulada.AddRange(vtaProdAnulada); //Guardamos TbVtaProductoAnulada
                    var dtlleVtaAnualadaQuery = _contextcyj.SaveChanges();
                    if (dtlleVtaAnualadaQuery > 0)
                    {
                        if (vtaProdAnulada.Count > 0)
                        {
                            returnValue = true;
                            //Modificamos existencias
                            Tbproducto tbproducto = new Tbproducto();
                            for (int i = 0; i < vtaProdAnulada.Count; i++)
                            {
                                tbproducto = await _productoRepository.GetById(vtaProdAnulada[i].IdProducto);
                                //Sumar al inventario
                                int cantidad = vtaProdAnulada[i].Cantidad;
                                if (tbproducto != null)
                                {
                                    tbproducto.Existencia += cantidad;
                                    var desccuenta = await _contextcyj.SaveChangesAsync();
                                    if (desccuenta > 0)
                                    {
                                        returnValue = true;
                                    }
                                    else // No se pudo Sumar al inventario
                                    {
                                        returnValue = false;
                                        Msj = "No se sumó al inventario";
                                        Console.WriteLine(Msj);
                                    }
                                }
                                else //No Se pudo consultar producto
                                {
                                    returnValue = false;
                                    Msj = "No se listó TbProducto";
                                    Console.WriteLine(Msj);
                                }
                            }

                            //Eliminamos DetalleVenta
                            _contextcyj.Tbventaproducto.RemoveRange(detalleVenta);
                            var queryDtlleVentaEliminar = await _contextcyj.SaveChangesAsync();
                            if (queryDtlleVentaEliminar > 0)
                            {
                                returnValue = true;
                                //Eliminamos TbVenta
                                _contextcyj.Tbventa.Remove(tbventa);
                                var queryEliminaTbVenta = await _contextcyj.SaveChangesAsync();
                                if (queryEliminaTbVenta > 0)
                                {
                                    returnValue = true;
                                    //Verificar si es equipo ProductoSerial
                                    IEnumerable<Tbproductoserial> productoserial = await _productoSerial.GetListById(tbproducto.IdProducto);
                                    if (productoserial != null)
                                    {

                                    }
                                }
                                else //No se eliminó TbVenta
                                {
                                    returnValue = false;
                                    Msj = "No se eliminó TbVenta";
                                    Console.WriteLine(Msj);
                                }
                            }
                            else //No se pudo eliminar DetalleVenta
                            {
                                returnValue = false;
                                Msj = "No se eliminó TbDetalleVenta";
                                Console.WriteLine(Msj);
                            }

                        }
                        else  //No se guardó VtaProductoAnulada
                        {
                            returnValue = false;
                            Msj = "No se guardó VentaProductoAnulada";
                            Console.WriteLine(Msj);
                        }
                    }
                    else //No se guardó DetalleVentaAnulada
                    {
                        returnValue = false;
                        Msj = "No se guardó DetalleVentaAnulada";
                        Console.WriteLine(Msj);
                    }
                }
                else // No se Listó vtaAnulada
                {
                    returnValue = false;
                    Msj = "No se listó TbVentaAnulada";
                    Console.WriteLine(Msj);
                }
            }

            return returnValue;
        }

        public Task<bool> Put(Tbventaanulada entity)
        {
            throw new NotImplementedException();
        }

        public string Msj { get; set; }
    }
}
