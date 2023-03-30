using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Programando.CSharp.Ejercicios.ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Ejercicios();
        }

        static void ConsultasBasicas()
            {
            //T-SQL: SELECT * FROM dbo.ListaProductos

            // Métodos de LINQ
            var r1a = DataLists.ListaProductos
                .Select(r => r).ToArray();

            // Expresión LINQ
            var r1b = from r in DataLists.ListaProductos
                      select r;

            foreach(Producto item in r1a) Console.WriteLine($"{item.Id} {item.Descripcion}");

            // Métodos de LINQ

            var r2a = DataLists.ListaClientes

                .Select(r => r.Nombre);



            // Expresión LINQ

            var r2b = from r in DataLists.ListaClientes
                      select r.Nombre;

            foreach (string item in r2b) Console.WriteLine($"{item}");

            // T-SQL: SELECT Id, Nombre FROM dbo.ListaClientes

            // Métodos de LINQ
            var r3a = DataLists.ListaClientes
                .Select (r => r.Nombre); // AQUÍ ME FALTAN COSAS


            //T-SQL: SELECT Descripcion FROM dbo.ListaProductos WHERE precio < 0.90

            //Métodos de LINQ
            var r4a = DataLists.ListaProductos
                .Where(r => r.Precio < 0.90)
                .Select(r => r.Descripcion);

            foreach (var item in r4a) Console.WriteLine($"{item}");
            Console.WriteLine(Environment.NewLine);

            // Me falta lo de filtración

            // Otros Ejemplos

            // Endswith
            var r6a = DataLists.ListaProductos
                .Where(r => r.Descripcion.ToLower().Contains("boli"))
                .Select(r => r);

            var r6b = from r in DataLists.ListaProductos
                      where r.Descripcion.ToLower().Contains("boli")
                      select r;

            var producto = DataLists.ListaProductos
                .Where(r => r.Id == 4)
                .OrderBy(r => r.Descripcion)
                .FirstOrDefault();

            // Paginación en DB
            var lista = DataLists.ListaProductos
                .OrderBy(r => r.Descripcion)
                .Skip(5)
                .Take(5)
                .Select(r => r);

            // Paginación en PC
            var lista2 = DataLists.ListaProductos
                .OrderBy(r => r.Descripcion)
                .Select(r => r)
                .Skip(5)
                .Take(5);
                


            // Count -> Cuenta los elementos
            // Distinct -> Valor distinto
            // Max -> valor máximo; Min -> valor mínimo
            // Sum -> suma de valores; Average -> media de los valores
            // Aggregate -> Aplicar fórmula o método de Agregación

            var r7a = DataLists.ListaProductos
                  .Where(r => r.Precio < 0.90)
                  .Count();

            var r7b = DataLists.ListaProductos
                .Count(r => r.Precio < 0.90);

            var r7c = (from r in DataLists.ListaProductos
                       where r.Precio < 0.90
                       select r.Descripcion).Count();
        }

        static void Ejercicios()
        {
            // Listado de clientes mayores de 50 años
            var hoy = DateTime.Now;

            var clientes_mayores_50 = DataLists.ListaClientes
                .Where(cliente => (hoy.Year - cliente.FechaNac.Year) > 50)
                .Select(cliente => new {cliente.Nombre});

            Console.WriteLine($"Nombre de los clientes mayores de 50 años:");
            foreach (var cliente in clientes_mayores_50) Console.WriteLine($"{cliente.Nombre}");



            // Listado de productos que empiecen por la letra C ordenado por precio
            var productos_c_ord = DataLists.ListaProductos
                .Where(producto => producto.Descripcion.ToLower().StartsWith("c"))
                .OrderBy(producto => producto.Precio)
                .Select(producto => new { producto.Descripcion });

            Console.WriteLine($"Listado de productos que empiezan por la letra C ordenados por precio: ");
            foreach (var producto in productos_c_ord) Console.WriteLine($"{producto.Descripcion}");


            // Preguntar por el id de un pedido y listar el contenido
            Console.WriteLine("Introduzca el id del pedido:");
            int idPedido2 = int.Parse(Console.ReadLine());
            
            // Uno las listas poniendo la condición de que IdProducto en ListaLineasPedido sea igual a Id en ListaProductos
            var contenidoPedido = from lp in DataLists.ListaLineasPedido
                                  join p in DataLists.ListaProductos on lp.IdProducto equals p.Id
                                  where lp.IdPedido == idPedido2
                                  select new { Descripcion = p.Descripcion, Cantidad = lp.Cantidad};

            Console.WriteLine($"Contenido del pedido {idPedido2}:");
            foreach (var linea in contenidoPedido)
            {
                Console.WriteLine($"- {linea.Descripcion}: ({linea.Cantidad} unidades)");
            }


            // Preguntar por el id de un pedido y mostrar el total
            Console.Write("Ingrese el IdPedido: ");
            int idPedido = int.Parse(Console.ReadLine());

            // Uno las listas poniendo la condición de que IdProducto en ListaLineasPedido sea igual a Id en ListaProductos
            // Selecciono la cantidad de cada línea de pedido (lp.Cantidad) y el precio de cada producto (p.Precio)
            // Multiplico y sumo los precios totales de cada línea
            decimal totalPedido = (from lp in DataLists.ListaLineasPedido
                                   join p in DataLists.ListaProductos on lp.IdProducto equals p.Id
                                   where lp.IdPedido == idPedido
                                   select (lp.Cantidad * (decimal)p.Precio)).Sum();

            Console.WriteLine($"El total del pedido {idPedido} es: {totalPedido.ToString("C2")}");


            // Listado de pedidos que contengan Lapicero (11)
            string objeto = "Lapicero";

            var id_lapicero = DataLists.ListaProductos
                .FirstOrDefault(producto => producto.Descripcion == objeto);

            var linea_pedidos_lapicero = DataLists.ListaLineasPedido
                .Where(linea => linea.IdProducto == id_lapicero.Id)
                .Select(linea => new { linea.IdPedido, linea.Id })
                .Distinct();

            Console.WriteLine($"Los Id de los pedidos que contienen lapiceros son:");

            foreach (var pedido in linea_pedidos_lapicero) Console.WriteLine($"{pedido.Id}");


            // Cantidad de pedidos que contengan Cuaderno Grande
            int cantidadPedidosCuadernoGrande = (from lp in DataLists.ListaLineasPedido
                                                 join p in DataLists.ListaProductos on lp.IdProducto equals p.Id
                                                 join pe in DataLists.ListaPedidos on lp.IdPedido equals pe.Id
                                                 where p.Descripcion == "Cuaderno grande"
                                                 select pe).Count();
            Console.WriteLine($"La cantidad de pedidos que incluyen un Cuaderno Grande es: {cantidadPedidosCuadernoGrande}");

            // Unidades vendidades de Cuaderno Pequeño

            var unidades = DataLists.ListaLineasPedido
                .Where(r => DataLists.ListaProductos
                            .Where(s => s.Descripcion.ToLower() == "Cuaderno Pequeño")
                            .Select(s => s.Id)
                            .FirstOrDefault() == r.IdProducto)
                .Sum(s => s.Cantidad);

            Console.WriteLine($"{unidades} Cuadernos Pequeños vendidos");


        }
            
            
    }
}