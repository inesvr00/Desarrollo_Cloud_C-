using Programando.CSharp.ConsoleEF.Model;
using System.Collections.Specialized;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Programando.CSharp.Delegate
{
    internal class Program
    {
        public delegate void Delegado1();
      
        public class Alumno { }

        static void Main(string[] args)
        {
            Delegado1 delegado1 = Test1;
            Delegado1 delegado2 = () =>
            {
                Console.WriteLine("Demo delegado B)");
            };
            delegado2();
            Console.WriteLine("");
            Console.WriteLine("INICIO CREAR TAREAS");
            CrearTareas();
            Console.WriteLine("FINAL CREAR TAREAS");
            Console.ReadKey();
            Console.WriteLine("FINAL CREAR TAREAS DESPUÉS DEL READKEY");
            Console.WriteLine("");
            Console.WriteLine("Inicio Asíncrona");
            DemoAsync();
            Console.WriteLine("Final Asíncrona");
            Console.WriteLine("");
            ParallelFor();
        }

        static void ParallelForEach()
        {
            var db = new ModelNorthwind();

            var clientes = db.Customers
                .Where(r => r.Country == "USA")
                .OrderBy(r => r.City)
                .ToList();

            foreach (var cliente in clientes)
                Console.WriteLine($"{cliente.CustomerID} {cliente.CompanyName} - {cliente.City}");

            Console.WriteLine(Environment.NewLine);

            Parallel.ForEach(clientes,
                item => Console.WriteLine($"{item.CustomerID} {item.CompanyName} - {item.City}"));
        }

        static void ParallelFor()
        {
            double[] array = new double[50000000];

            var f1 = DateTime.Now;
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Math.Sqrt(i);
            }
            var f2 = DateTime.Now;

            Parallel.For(0, 49999999, (i) =>
            {
                array[i] = Math.Sqrt(i);
            });

            var f3 = DateTime.Now;
            Console.WriteLine($"         FOR -> {f3.Subtract(f1).TotalMilliseconds}");
            Console.WriteLine($"PARALLEL FOR -> {f3.Subtract(f2).TotalMilliseconds}");
        }
       
        static void CrearTareas()
        {   // Se crean tareas
            Task tarea1 = new Task(new Action(() => { Console.WriteLine("Método con un Action"); }));

            Task tarea2 = new Task(new Action(Test1));

            Task tarea3 = new Task(delegate { Console.WriteLine("Tarea 3"); });

            Task tarea4 = new Task(() => { Console.WriteLine("Tarea4"); });

            Task tarea5 = new Task(() => Test1());

            // A partir de aquí empiezan a ejecutarse
            Task tarea6 = Task.Run(() => { Console.WriteLine("Tarea 6"); });
            Task<string> tarea7 = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Tarea7");
                return "Tarea 7";
            });

            Console.WriteLine($"Estado tarea 1: {tarea1.Status}");
            Console.WriteLine($"Estado tarea 7: {tarea7.Status}");
            //Ahora empezamos a iniciar las otras
            tarea1.Start();
            tarea2.Start();
            tarea3.Start();
            tarea4.Start();
            tarea5.Start();

            Console.WriteLine($"Estado tarea 1: {tarea1.Status}");
            Console.WriteLine($"Estado tarea 7: {tarea7.Status}");


        }

        static void Test1()
        {
            Console.WriteLine("Soy el Método Test1");
        }
    
        static async void DemoAsync()
        {
            var obj = new DemoObject();
            string resultado = await obj.MetodoAsync();
        }
    }

    public class DemoObject
    {
        public string MetodoSync()
        {
            Console.WriteLine("INICIO TAREA");
            Task<string> tarea = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Tarea Síncrona");
                return "Tarea Sícrona";
            });
            Console.WriteLine("FIN TAREA");

            return tarea.Result;
        }

        public async Task<string> MetodoAsync()
        {
            return await Task<string>.Run(() =>
            {
                Console.WriteLine("INICIO TAREA");
                Thread.Sleep(15000);
                Console.WriteLine("Tarea Asíncrona");
                Console.WriteLine("FIN TAREA");

                return "Tarea Asíncrona";
                });
            }
        }

    }
