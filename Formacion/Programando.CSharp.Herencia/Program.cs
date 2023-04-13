using System.Reflection.Metadata.Ecma335;

namespace Programando.CSharp.Herencia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EjemploHerencia2();
            Console.WriteLine("");
            EjemploPolimorfismo2();
            Console.WriteLine("");
            EjemploClasesAbstractas();

        }
        static void Procesar(IVehiculo item)
        {
            Console.WriteLine(item.Nombre);
            Console.WriteLine(item.GetType());

            if (typeof(Avion) == item.GetType())
            {
                ((Avion)item).Despegar();
            }
            else if (typeof(Coche) == item.GetType())
            {
                ((Coche)item).Test();
            }
        }
        static void EjemploHerencia1()
        {
            var list = new List<string>();
            list.Add("Hello");
            list.Add(", It's me");

            var col = new Coleccion<string>();
            col.Add("Hola");
            col.Add("Maricarmen");
            col.OutputAll();
        }

        static void EjemploHerencia2()
        {
            var animal = new Animal();
            animal.MetodoA();
            animal.MetodoB();
            Console.WriteLine(Environment.NewLine);

            var mamifero = new Mamifero();
            mamifero.MetodoA();
            mamifero.MetodoB();


        }

        static void EjemploPolimorfismo1()
        {
            Coche coche = new Coche()
            {
                Nombre = "Hunday Tucson",
                Ruedas = 4,
                Color = "Rojo"
            };

            IVehiculo coche2 = new Coche();

            Avion avion = new Avion()
            {
                Nombre = "Maricarmen Airlines",
                Ruedas = 8
            };

            Console.WriteLine("AVIÓN ================");
            avion.Iniciar();
            avion.Despegar();

            Console.WriteLine("COCHE ===================");
            IVehiculo vehiculo = coche;
            vehiculo.Iniciar();

            Console.WriteLine("VEHÍCULO AVIÓN ================");
            vehiculo = avion;
            vehiculo.Iniciar();

            Console.WriteLine("VEHÍCULO COCHE ====================");
            vehiculo = coche;
            vehiculo.Parar();

            Console.WriteLine("PROCESAR ==============");
            Procesar(avion);

        }

        static void EjemploPolimorfismo2()
        {
            var formas = new List<Forma>();

            formas.Add(new Forma());
            formas.Add(new Circulo());
            formas.Add(new Cuadrado());
            formas.Add(new Triangulo());

            foreach (var item in formas) item.Dibujar();

        }
    
        static void EjemploClasesAbstractas()
        {
            var nevera = new Nevera()
            {
                Nombre = "Nevera Demo",
                Color = "Rojo",
                Consumo = "200W"
            };

            nevera.MetodoA();
            nevera.MetodoB();
            nevera.MetodoC();
        }
    }
    // Al poner : habilitamos la herencia
    public class Coleccion<T> : List<T>
    {
        public void OutputAll()
        {
            foreach (var item in this)
            {
                Console.WriteLine($"{item.ToString()}");
            }
        }
    }

    public class Animal
    {
        public string Name { get; set; }
        public string Familia { get; set; }

        public virtual void MetodoA() // Los virtuales se pueden override
        {
            Console.WriteLine("Método A, implementado en Animal.");
        }

        public void MetodoB()
        {
            Console.WriteLine("Método B, implementado en Animal.");
        }


    }

    public sealed class Mamifero : Animal
    {
        public override void MetodoA()
        {
            Console.WriteLine("Método A, implementado en mamífero");
            // Aunque lo hayamos sustituido si llamo a MetodoA desde base ejecuta el original
            base.MetodoA();
        }
    }

    // No se puede heredar de Mamífero cuando la clase está sellada con SEALED
    //public class Oso : Mamifero
    //{  
    //}

    public interface IVehiculo
    {
        public string Nombre { get; set; }
        public int Ruedas { get; set; }
        public void Iniciar();
        public void Parar();
    }

    public class Avion : IVehiculo
    {
        public string Nombre { get; set; }
        public int Ruedas { get; set; }

        public void Iniciar() => Console.WriteLine("Avión en marcha");

        public void Parar() => Console.WriteLine("Avión parado.");

        public void Test() => Console.WriteLine("Avión chequeándose.");
        public void Despegar() => Console.WriteLine("Avión despegando");

        public void Aterrizar() => Console.WriteLine("Avión aterrizando");
    }

    public class Coche : IVehiculo
    {
        public string Nombre { get; set; }
        public int Ruedas { get; set; }
        public string Color { get; set; }

        public void Iniciar() => Console.WriteLine("Coche en marcha");

        public void Parar() => Console.WriteLine("Coche parado.");

        public void Test() => Console.WriteLine("Coche chequeándose.");

        void IVehiculo.Iniciar() => Console.WriteLine("Vehículo en marcha.");
        void IVehiculo.Parar() => Console.WriteLine("Vehículo parado.");
    }

    public class Forma
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public virtual void Dibujar() => Console.WriteLine("Método Dibujar en Forma");

    }

    public class Circulo : Forma
    {
        public override void Dibujar() => Console.WriteLine("Método Dibujar en Circulo.");
    }

    public class Cuadrado : Forma
    {
        public override void Dibujar() => Console.WriteLine("Método dibujar en Cuadrado.");

    }

    public class Triangulo : Forma
    {
        public override void Dibujar() => Console.WriteLine("Método dibujar en Triángulo.");

        public void Tipo() => Console.WriteLine("Muestra el tipo del triángulo.");
    }


    public abstract class Electrodomestico
    {
        public string Nombre { get; set; }
        public abstract string Color { get; set; }
        public void MetodoA() => Console.WriteLine("Método A en Electrodoméstico.");
        public abstract void MetodoB();
    }

    public class Nevera : Electrodomestico
    {
        public override string Color { get; set; }

        public string Consumo { get; set; }

        public override void MetodoB() => Console.WriteLine("Método B en Nevera.");

        public void MetodoC() => Console.WriteLine("Método C en Nevera");
    }

}