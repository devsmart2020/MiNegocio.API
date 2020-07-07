using MiNegocio.Core.Entities;
using MiNegocio.Core.ReportsEntities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiNegocio.Core.Interfaces
{
    public interface ICompraRepository
    {
        Task<IEnumerable<Tbcompra>> Get();
        Task<Tbcompra> Post(Tbcompra entity);
        Task<Tbcompra> GetById(int id);
        Task<Tbcompra> Put(int id, Tbcompra entity);
        Task<bool> Delete(int id);
        Task<bool> Exists(int id);
        Task<object> CompraProveedor(string idCliente);
        Task<object> CompraxUsuario(string idUsuario);
        Task<IEnumerable<ComprasxFecha>> ComprasxFecha(DateTime fchaIni, DateTime fchaFin);

    }
}
