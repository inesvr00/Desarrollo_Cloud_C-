using Programando.CSharp.Ejercicios.LINQ;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Programando.CSharp.Ejercicios.LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new ModelNorthwind();
            /////////////////////////////////////////////////////////////////////////////////
            // Listado de Clientes que residen en USA
            /////////////////////////////////////////////////////////////////////////////////

            // SELECT * FROM dbo.Customers WHERE Country = 'USA'

            var customers_USA = from r in context.Customers
                                where r.Country == "USA"
                                select r;

            Console.WriteLine("Listado de clientes que residen en USA");

            foreach (var customer in customers_USA)
            {
                Console.WriteLine($"ID: {customer.CustomerID.PadRight(7)} - Company: {customer.CompanyName.PadRight(35)} - Name: {customer.ContactName.PadRight(15)}");
            }
            Console.WriteLine("\n \n");


            /////////////////////////////////////////////////////////////////////////////////
            // Listado de Proveedores (Suppliers) de Berlin
            /////////////////////////////////////////////////////////////////////////////////

            // SELECT * FROM dbo.Suppliers WHERE Country = 'Berlin'

            var suppliers_berlin = from r in context.Suppliers
                                   where r.City == "Berlin"
                                   select r;

            Console.WriteLine("Listado de Proveedores de Berlín");

            foreach (var supplier in suppliers_berlin)
            {
                Console.WriteLine($"ID: {supplier.SupplierID.ToString().PadRight(5)} - Company: {supplier.CompanyName.PadRight(30)} - Name: {supplier.ContactName.PadRight(15)}");
            }
            Console.WriteLine("\n \n");
            

            /////////////////////////////////////////////////////////////////////////////////
            // Listado de Empleados con identificadores 3, 5 y 8
            /////////////////////////////////////////////////////////////////////////////////

            // SELECT * FROM dbo.Employees WHERE EmployeeID IN (3, 5, 8)

            var employees_3_5_8 = from r in context.Employees
                                  where r.EmployeeID == 3 || r.EmployeeID == 5 || r.EmployeeID == 8
                                  select r;

            Console.WriteLine("Listado de Empleados con identificadores 3, 5 y 8");

            foreach(var employee in employees_3_5_8)
            {
                Console.WriteLine($"ID: {employee.EmployeeID.ToString().PadRight(3)} - Nombre: {employee.FirstName.PadRight(6)} {employee.LastName.PadRight(10)} - País: {employee.Country}");
            }
            Console.WriteLine("\n \n");


            /////////////////////////////////////////////////////////////////////////////////
            // Listado de Productos con stock mayor de cero
            /////////////////////////////////////////////////////////////////////////////////

            // SELECT * FROM dbo.Products WHERE UnitsInStock > 0

            var stock_mas_cero = from r in context.Products
                                 where r.UnitsInStock > 0
                                 select r;

            Console.WriteLine("Listado de productos con stock mayor que cero: ");

            foreach(var unit in stock_mas_cero)
            {
                Console.WriteLine($"Nombre: {unit.ProductName.PadRight(32)} - Unidades en stock: {unit.UnitsInStock.ToString().PadRight(3)} - Precio por unidad: {unit.UnitPrice:F2} €");
            }
            Console.WriteLine("\n \n");


            /////////////////////////////////////////////////////////////////////////////////////////////////
            // Listado de Productos con stock mayor de cero de los proveedores con identificadores 1, 3 y 5
            /////////////////////////////////////////////////////////////////////////////////////////////////

            // SELECT * FROM dbo.Products WHERE SupplierID IN (1, 3, 5) 

            var prod_stock_nozero_id_1_3_5 = from r in context.Products
                                  where r.SupplierID == 3 || r.SupplierID == 5 || r.SupplierID == 8
                                  where r.UnitsInStock > 0
                                  select r;

            Console.WriteLine("Listado de productos con stock mayor que cero de los proveedores con identificadores 1, 3 y 5: ");

            foreach (var unit in prod_stock_nozero_id_1_3_5)
            {
                Console.WriteLine($"Supplier ID: {unit.SupplierID.ToString().PadRight(2)} - Nombre: {unit.ProductName.PadRight(32)} - Unidades en stock: {unit.UnitsInStock.ToString().PadRight(3)} - Precio por unidad: {unit.UnitPrice:F2} €");
            }
            Console.WriteLine("\n \n");


            /////////////////////////////////////////////////////////////////////////////////
            // Listado de Productos con precio mayor de 20 y menor 90
            /////////////////////////////////////////////////////////////////////////////////

            // SELECT * FROM dbo.Products WHERE UnitPrice > 20 AND UnitPrice < 90

            var prod_20_90 = from r in context.Products
                             where r.UnitPrice > 20 && r.UnitPrice < 90
                             select r;

            Console.WriteLine("Listado de productos con precio mayor que 20 y menor que 90: ");

            foreach (var unit in prod_20_90)
            {
                Console.WriteLine($"Supplier ID: {unit.SupplierID.ToString().PadRight(2)} - Nombre: {unit.ProductName.PadRight(32)} - Unidades en stock: {unit.UnitsInStock.ToString().PadRight(3)} - Precio por unidad: {unit.UnitPrice:F2} €");
            }
            Console.WriteLine("\n \n");


            /////////////////////////////////////////////////////////////////////////////////
            // Listado de Pedidos entre 01/01/1997 y 15/07/1997
            /////////////////////////////////////////////////////////////////////////////////

            // SELECT * dbo.Orders WHERE OrderDate >= '1997/01/01' AND OrderDate <= '1997/09/15'

            DateTime start = new DateTime(1997, 1, 1);
            DateTime end = new DateTime(1997, 7, 15);

            var order_dates = from r in context.Orders
                              where r.OrderDate >= start && r.OrderDate <= end
                              select r;

            Console.WriteLine("Listado de pedidos entre 01/01/1997 y 15/07/1997");

            foreach (var order in order_dates)
            {
                Console.WriteLine($"Order ID: {order.OrderID.ToString().PadRight(3)} - CustomerID: {order.CustomerID.ToString().PadRight(3)} - Fecha: {order.OrderDate}");
            }
            Console.WriteLine("\n \n");


            /////////////////////////////////////////////////////////////////////////////////////////////////
            // Listado de Pedidos registrados por los empleados con identificador 1, 3, 4 y 8 en 1997
            /////////////////////////////////////////////////////////////////////////////////////////////////

            // SELECT * dbo.Orders WHERE YEAR(OrderDate) = 1997 AND EmployeeID IN (1, 3, 4, 8)

            var id_date = from r in context.Orders
                          where r.OrderDate.HasValue && r.OrderDate.Value.Year == 1997
                          where r.EmployeeID == 1 || r.EmployeeID == 3 || r.EmployeeID == 4 || r.EmployeeID == 8
                          orderby r.EmployeeID ascending
                          select r;

            Console.WriteLine("Listado de pedidos realizados en 1997 por los ID de los empleados: 1, 3, 4 y 8: ");

            foreach (var order in id_date)
            {
                Console.WriteLine($"Order ID: {order.OrderID.ToString().PadRight(3)} - EmployeeID: {order.EmployeeID.ToString().PadRight(3)} - Fecha: {order.OrderDate}");
            }
            Console.WriteLine("\n \n");


            /////////////////////////////////////////////////////////////////////////////////
            // Listado de Pedidos de abril de 1996
            /////////////////////////////////////////////////////////////////////////////////

            // SELECT * dbo.Orders WHERE YEAR(OrderDate) = 1996 AND MONTH(OrderDate) = 4

            var order_year_month = from r in context.Orders
                          where r.OrderDate.HasValue && r.OrderDate.Value.Year == 1996
                          where r.OrderDate.HasValue && r.OrderDate.Value.Month == 4
                          orderby r.OrderDate ascending
                          select r;

            Console.WriteLine("Listado de pedidos realizados en abril de 1996: ");

            foreach (var order in order_year_month)
            {
                Console.WriteLine($"Order ID: {order.OrderID.ToString().PadRight(3)} - EmployeeID: {order.EmployeeID.ToString().PadRight(3)} - Fecha: {order.OrderDate}");
            }
            Console.WriteLine("\n \n");

            /////////////////////////////////////////////////////////////////////////////////
            // Listado de Pedidos del realizado los dia uno de cada mes del año 1998
            /////////////////////////////////////////////////////////////////////////////////

            // SELECT * dbo.Orders WHERE YEAR(OrderDate) = 1998 AND MONTH(OrderDate) = 1

            var order_first_day_month_1998 = from r in context.Orders
                                   where r.OrderDate.HasValue && r.OrderDate.Value.Year == 1998
                                   where r.OrderDate.HasValue && r.OrderDate.Value.Day == 1
                                   orderby r.OrderDate.Value.Month ascending
                                   select r;

            Console.WriteLine("Listado de pedidos realizados los día 1 de cada mes del año 1998: ");

            foreach (var order in order_first_day_month_1998)
            {
                Console.WriteLine($"Order ID: {order.OrderID.ToString().PadRight(3)} - EmployeeID: {order.EmployeeID.ToString().PadRight(3)} - Fecha: {order.OrderDate}");
            }
            Console.WriteLine("\n \n");


            /////////////////////////////////////////////////////////////////////////////////
            // Listado de Clientes que no tiene fax
            /////////////////////////////////////////////////////////////////////////////////

            // SELECT * FROM dbo.Customers WHERE Fax = NULL

            var clientes_no_fax = from r in context.Customers
                                  where r.Fax == null
                                  select r;

            Console.WriteLine("Listado de Clientes que no tienen fax: ");

            foreach (var cliente in clientes_no_fax)
            {
                Console.WriteLine($"ID: {cliente.CustomerID.PadRight(7)} - Company: {cliente.CompanyName.PadRight(35)} - Name: {cliente.ContactName.PadRight(15)}");
            }
            Console.WriteLine("\n \n");

            /////////////////////////////////////////////////////////////////////////////////
            // Listado de los 10 productos más baratos
            /////////////////////////////////////////////////////////////////////////////////

            // SELECT TOP(10) * FROM dbo.Products ORDER BY UnitPrice

            var cheapest_prod = (from r in context.Products
                             orderby r.UnitPrice ascending
                             select r).Take(10);

            Console.WriteLine("Listado de los 10 productos más baratos: ");

            foreach (var unit in cheapest_prod)
            {
                Console.WriteLine($"Supplier ID: {unit.SupplierID.ToString().PadRight(2)} - Nombre: {unit.ProductName.PadRight(32)} - Unidades en stock: {unit.UnitsInStock.ToString().PadRight(3)} - Precio por unidad: {unit.UnitPrice:F2} €");
            }
            Console.WriteLine("\n \n");

            /////////////////////////////////////////////////////////////////////////////////
            // Listado de los 10 productos más caros con stock
            /////////////////////////////////////////////////////////////////////////////////

            // SELECT TOP(10) * FROM dbo.Products ORDER BY UnitPrice DESC

            var expensive_stock_prod = (from r in context.Products
                                        orderby r.UnitPrice descending
                                        where r.UnitsInStock != 0
                                        select r).Take(10);

            Console.WriteLine("Listado de los 10 productos más caros en stock: ");

            foreach (var unit in expensive_stock_prod)
            {
                Console.WriteLine($"Supplier ID: {unit.SupplierID.ToString().PadRight(2)} - Nombre: {unit.ProductName.PadRight(32)} - Unidades en stock: {unit.UnitsInStock.ToString().PadRight(3)} - Precio por unidad: {unit.UnitPrice:F2} €");
            }
            Console.WriteLine("\n \n");


            /////////////////////////////////////////////////////////////////////////////////
            // Listado de Cliente de UK y nombre de empresa que comienza por B
            /////////////////////////////////////////////////////////////////////////////////

            // SELECT * FROM dbo.Customers WHERE CompanyName LIKE 'B%' AND Country = 'Uk'

            var customers_B_UK = from r in context.Customers
                                 where r.Country.ToLower() == "uk"
                                 where r.CompanyName.ToLower().StartsWith("b")
                                 select r;

            Console.WriteLine("Listado de clientes que residen en UK y cuya empresa comienza por B: ");

            foreach (var customer in customers_B_UK)
            {
                Console.WriteLine($"ID: {customer.CustomerID.PadRight(7)} - Company: {customer.CompanyName.PadRight(35)} - Name: {customer.ContactName.PadRight(15)} - Country: {customer.Country}");
            }
            Console.WriteLine("\n \n");


            /////////////////////////////////////////////////////////////////////////////////
            // Listado de Productos de identificador de categoria 3 y 5
            /////////////////////////////////////////////////////////////////////////////////

            // SELECT TOP(10) * FROM dbo.Products WHERE CategoryID IN (3, 5)

            var category_3_5 = from r in context.Products
                               where r.CategoryID == 3 || r.CategoryID == 5
                               select r;

            Console.WriteLine("Listado de productos con categoría ID 3 y 5: ");

            foreach (var unit in category_3_5)
            {
                Console.WriteLine($"Supplier ID: {unit.SupplierID.ToString().PadRight(2)} - Nombre: {unit.ProductName.PadRight(32)} - Unidades en stock: {unit.UnitsInStock.ToString().PadRight(3)} - Precio por unidad: {unit.UnitPrice:F2} €");
            }
            Console.WriteLine("\n \n");

            /////////////////////////////////////////////////////////////////////////////////
            // Importe total del stock
            /////////////////////////////////////////////////////////////////////////////////

            // SELECT SUM(UnitInStock * UnitPrice) FROM Products

            decimal? stock_total = (from r in context.Products
                                    select r.UnitsInStock * (decimal)r.UnitPrice).Sum();

            Console.WriteLine($"Importe total del stock: {stock_total:F2} €");
;           Console.WriteLine("\n \n");

            /////////////////////////////////////////////////////////////////////////////////
            // Listado de Pedidos de los clientes de Argentina
            /////////////////////////////////////////////////////////////////////////////////            

            // SELECT CustomerID FROM dbo.Customers WHERE Country = 'Argentina'
            // SELECT * FROM dbo.Orders WHERE CustomerID IN ('CACTU', 'OCEAN', 'RANCH')


            // SELECT * FROM dbo.Orders WHERE CustomerID IN (SELECT CustomerID FROM dbo.Customers WHERE Country = 'Argentina')

            var orders_argentina = from o in context.Orders
                         where (from c in context.Customers
                                where c.Country == "Argentina"
                                select c.CustomerID).Contains(o.CustomerID)
                         select o;

        }
    }
}
