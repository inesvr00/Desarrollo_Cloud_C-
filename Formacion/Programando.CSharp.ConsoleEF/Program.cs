using Programando.CSharp.ConsoleEF.Model;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Programando.CSharp.ConsoleEF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TrabajandoConEF();
        }

        static void ConsultaConADONET()
        {
            var connectionString = new SqlConnectionStringBuilder()
            {
                DataSource = "eoi-api.eastus.cloudapp.azure.com",
                InitialCatalog = "Northwind",
                UserID = "eoiuser",
                Password = "Pa$$w0rd",
                IntegratedSecurity = false,
                ConnectTimeout = 60,
                TrustServerCertificate = false,
                Encrypt = false
            };

            Console.WriteLine($"Cadena de conexión: {connectionString.ToString()}");

            // Creamos el objeto conexión
            var connection = new SqlConnection()
            {
                ConnectionString = connectionString.ToString()
            };

            // Abrimos conexión a la base de datos
            Console.WriteLine($"Estado: {connection.State.ToString()}");
            connection.Open();
            Console.WriteLine($"Estado: {connection.State.ToString()}");

            // Ejecutar un comando SELECT * FROM dbo.Customers
            var command = new SqlCommand()
            {
                Connection = connection,
                CommandText = "SELECT * FROM dbo.Customers"
            };

            SqlDataReader reader = command.ExecuteReader();

            if (!reader.HasRows) Console.WriteLine("Registros no encontrados");
            else
            {
                while(reader.Read())
                {
                    Console.WriteLine($"{reader["CustomerID"]}# {reader.GetValue(1)}");
                }
            }

            reader.Close();
            command.Dispose();
            connection.Close();
            connection.Dispose();

        }
    
        static void TrabajandoConEF()
        {
            // Instanciamos la clase del contexto
            var context = new ModelNorthwind();

           

            // INSERT, insertar un nuevo cliente
            Console.Write("ID Cliente: ");

            var cliente = new Customer()
            {
                CustomerID = "DEMO47",
                CompanyName = "Empresa Ines SL",
                ContactName = "Inés Victoria Rodríguez",
                Address = "Salinetas, S/N",
                Region = "",
                City = "Las Palmas GC",
                PostalCode = "28014",
                Country = "Spain",
                Phone = "9281009090",
                Fax = "9281009090"
            };

            context.Customers.Add(cliente);
            context.SaveChanges();
            Console.WriteLine("Cliente insertado correctamente.");

            Console.ReadKey();

            // UPDATE, modificar un cliente
            var customer = context.Customers
                .Where(r => r.CustomerID == "DEMO47")
                .FirstOrDefault();

            customer.CompanyName = "Empresa Ines :) SL";
            customer.ContactName = "Inés VR";
            context.SaveChanges();

            Console.WriteLine("Cliente modificado");
            Console.ReadKey();

            // DELETE, eliminar un cliente
            var customer = context.Customers
                .Where(r => r.CustomerID == "DEMO47")
                .FirstOrDefault();

            context.Customers.Remove(customer);
            context.SaveChanges();

            Console.WriteLine("Cliente eliminado");
            Console.ReadKey();


            // SELECT * FROM dbo.Customers
            var clientes = context.Customers
                .Select(r => r);

            var clientes2 = from r in context.Customers
                            select r;
                            


            foreach(var item in clientes)
            {
                Console.WriteLine($"{item.CustomerID}# {item.CompanyName}");
            }

        }
    }

}