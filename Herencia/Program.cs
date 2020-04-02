using System;
using System.Collections.Generic;

namespace Herencia
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Programa Iniciado!");

            //Creamos nueva venta
            Venta venta = new Venta();

            //Hacemos listas de productos
            List<Articulos> articulos = new List<Articulos>();
            List<Ropa> ropas = new List<Ropa>();

            //Hacemos productos y los agregamos a las listas
            articulos.Add(
                new Articulos {
                    Id=10,
                    Cantidad=1,
                    Nombre="Balon de Futbol",
                    Precio=20.00,
                    TipoArticulo="Balon"
                });
            articulos.Add(
                new Articulos
                {
                    Id = 12,
                    Cantidad = 2,
                    Nombre = "Tenis Nike",
                    Precio = 520.99,
                    TipoArticulo = "Tenis"
                });

            ropas.Add(
                new Ropa { 
                    Id=102288,
                    Cantidad=4,
                    Nombre="Camisa Baseball",
                    Precio=55.00,
                    TipoRopa= "Playera"
                });

            venta.ListaArticulos = articulos;
            venta.ListaRopa = ropas;

            //Sacamos y imprimimos los datos
            DatosVenta dv = venta.CalcularDatosVenta();
            Console.WriteLine("Venta Iniciada!");
            Console.WriteLine("Total: $" + dv.TotalVenta);
            Console.WriteLine("Descuento: " + dv.HuboDescuento);
            Console.WriteLine("Monto Descuento: $" + dv.MontoDescuento);
            Console.WriteLine("Importe Total: $" + dv.ImporteTotal);
            Console.WriteLine("\nIngrese su pago:");
            double pago = Double.Parse(Console.ReadLine());
            Console.WriteLine("Cambio: $" + dv.CalcularCambio(pago));
        }
    }
}
