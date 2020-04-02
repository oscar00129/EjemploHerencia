using System;
using System.Collections.Generic;
using System.Text;

namespace Herencia
{
    class DatosVenta
    {
        public double TotalVenta { get; set; }
        public bool HuboDescuento { get; set; }
        public double MontoDescuento { get; set; }
        public double ImporteTotal { get; set; }
        public double CalcularCambio(double PagoCliente) {
            double cambio = PagoCliente - ImporteTotal;
            return cambio;
        }
    }
}
