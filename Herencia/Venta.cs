using System;
using System.Collections.Generic;
using System.Text;

namespace Herencia
{
    class Venta
    {
        public List<Articulos> ListaArticulos { get; set; }
        public List<Ropa> ListaRopa { get; set; }

        public DatosVenta CalcularDatosVenta() {
            DatosVenta datosVenta = new DatosVenta();

            //Calcular total de la venta
            datosVenta.TotalVenta = CalcularTotalVenta();

            //Saber si hubo descuento
            if (CalcularPorcentajeDescuento() > 0)
                datosVenta.HuboDescuento = true;
            else
                datosVenta.HuboDescuento = false;

            //Calcular Monto Descuento
            datosVenta.MontoDescuento = datosVenta.TotalVenta * CalcularPorcentajeDescuento() / 100;

            //Calcular Importe Total
            datosVenta.ImporteTotal = datosVenta.TotalVenta - datosVenta.MontoDescuento;
            
            return datosVenta;
        }

        private double CalcularTotalVenta() {
            double total = 0;
            foreach (Articulos art in ListaArticulos) {
                total += art.Precio * art.Cantidad;
            }
            foreach (Ropa ropa in ListaRopa) {
                total += ropa.Precio * ropa.Cantidad;
            }
            return total;
        }

        private double CalcularPorcentajeDescuento() {
            double porcentaje = 0;
            if (HayDescuentoPlayeras())
            {
                porcentaje += 7.5;
            }
            if (HayDescuentoArticulosProteccion())
            {
                porcentaje += 15;
            }
            if (HayDescuentoPorTotal())
            {
                porcentaje += 25;
            }
            return porcentaje;
        }

        private bool HayDescuentoPlayeras() {
            int contadorPlayeras = 0;
            foreach (Ropa ropa in ListaRopa) {
                if (ropa.TipoRopa.Equals("Playera")) {
                    contadorPlayeras += ropa.Cantidad;
                }
            }
            if (contadorPlayeras >= 2)
                return true;
            else
                return false;
        }

        private bool HayDescuentoArticulosProteccion() {
            int contadorArtProt = 0;
            foreach (Articulos art in ListaArticulos) {
                if (art.TipoArticulo.Equals("Proteccion"))
                    contadorArtProt += art.Cantidad;
            }
            if (contadorArtProt >= 10)
                return true;
            else
                return false;
        }

        private bool HayDescuentoPorTotal() {
            if (CalcularTotalVenta() >= 1000)
                return true;
            else
                return false;
        }

    }
}
