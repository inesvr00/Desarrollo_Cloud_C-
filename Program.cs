using System;
using Escuela;
using Universidad;
// Puedo poner o using Escuela o Escuela.Alumno
// Pero luego Escuela.Clases va a parte, también tengo que poner .Clases

namespace Programando.CSHarp.Demos
{

    public class Program
    {

        public static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");

            var alumno = new Escuela.Clases.Alumno();
            alumno1.Demo();
            // Si lo pongo así solo me sale Demo() por ser estático
            Asistente.Demo();
            // Necesito instanciar porque no es estátitico Demo2()
            var asistente = new Asistente();
            asistente.Demo2();

            // Las variables de tipo referencia (str, objectos, tal)
            // El valor predeterminado es NULL
            string texto;
            string texto1 = null;
            string otroTexto = "Hello Hello Helloooo";

            //Instanciamos el objeto alumno
            Alumno alumno1 = new Alumno();
            alumno1.nombre = "Inés";
            var alumno2 = new Alumno();
            alumno2.nombre = "Borja";
            Object alumno3 = new Alumno();
            dynamic alumno4 = new Alumno();

            Console.WriteLine("Tipo de la variable 1: " + alumno1.nombre);
            Console.WriteLine("Nombre: {0}", alumno1.nombre);
        }
    }
}

//Aquí también puedo poner Escuela.Clases
namespace Escuela {
    namespace Clases {
        class Alumno {

        }
    }

    
}
// No se puede crear una instancia de una clase estática
namespace Universidad {

    public class Alumno {

        public void Demo()
        {
            Console.WriteLine("Demo de Alumno");
        }
        string nombre = " ";
        int edad = 0;
    }

/// <summary>
/// Un ejemplo de una clase estática, implementando el patrón de diseño SINGLETON.
/// </summary>
    public partial class Profesor {

        public static void Demo()
        {
            Console.WriteLine("Demo del profesor");
        }
        public int num2 = 0;
    }
}

    public class Asistente {
        public static void Demo()
        {
            Console.WriteLine("Demo asistente");
        }

        public void Demo2() {
            Console.WriteLine("Demo2 de asistente");
        }
    }

