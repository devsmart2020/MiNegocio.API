using System;

namespace MiNegocio.Core.ReportsEntities
{
    public class CreditoClienteCartera
    {
        public int IdVenta { get; set; }
        public string Documento { get; set; }
        public string Cliente { get; set; }
        public DateTime Fecha { get; set; }
        public int Cartera { get; set; }
        public int Abono { get; set; }
        public sbyte PazySalvo { get; set; }
        public int SaldoRestante { get; set; }
    }
}
