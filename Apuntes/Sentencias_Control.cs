using System;
using Universidad;

namespace Programando.CSharp.C
{
   public class Program
   {
       public static void Main(string[] args)
       {       
           Console.Clear();   
           SentenciasControl2(); 
       }

       static void SentenciasControl()
       {
           var reserva = new Reserva();
           reserva.id = "1050CA";
           reserva.cliente = "Inés Victoria Rodríguez";

           var reserva2 = new Reserva() {
               id = "106HC",
               cliente = "Anna García"

           };

           var reserva3 = new Reserva();

           Console.Write("ID Reserva: ");
           reserva3.id = Console.ReadLine();
           Console.WriteLine($"Tipo de reserva {reserva3.id}");

           Console.Write("Nombre Cliente: ");
           reserva3.cliente = Console.ReadLine();
           Console.WriteLine($"Tipo de reserva {reserva3.cliente}");

           Console.Write("Tipo de Habitación: ");
           //int.TryParse(Console.ReadLine(), out reserva3.tipo);
           //reserva3.tipo = int.Parse(Console.ReadLine());
           string valor = Console.ReadLine();

           switch(valor)
           {
               case "100":
                   reserva3.tipo = 100;
                   break;
               case "200":
                   reserva3.tipo = 200;
                   break;
               case "300":
                   reserva3.tipo = 300;
                   break;
               case "400":
                   reserva3.tipo = 400;
                   break;
               default:
                   reserva3.tipo = -1;
                   break;

           Console.WriteLine($"Tipo de reserva {reserva3.tipo}");
           }
           if(valor == "100")
           {
               reserva3.tipo = 100;
           }
           else if (valor == "200")
           {
               reserva3.tipo = 200;
           }
        }

       // and es &&
       static void SentenciasControl2()
       {
           int[] nums;
           int[] nums2 = new int[5];
           int[] nums3 = new int[5] {1, 8, 74, 1, -10};
           int[] nums4 = new int[] {1, 8, 74, 1, -10};
           int[] numeros = {10, 95, -2, 32, 118, 72, -52};
           string[] frutas = {"naranja", "limón", "pomelo", "lima"};

           for(int i = 0; i < frutas.Length; i++)
           {
               Console.WriteLine($"Posición: {i} -> {frutas[i]}");
           }
           foreach(var fruta in frutas)
           {
               Console.WriteLine($"{fruta}");
           }
       }
        
       static void EjemplosConsol()
       {
           Console.ForegroundColor = ConsoleColor.Gray;
           Console.BackgroundColor = ConsoleColor.Black;
           Console.Clear();

           var tecla = Console.ReadKey();
           Console.WriteLine($"Pulso {tecla.KeyChar.ToString()}");

           Console.Write("Dime algo: ");
           string respuesta = Console.ReadLine();
           Console.ForegroundColor = ConsoleColor.Cyan;
           Console.Write($"Respueta: ");
           Console.ForegroundColor = ConsoleColor.Yellow;
           Console.Write($"{respuesta}");
           Console.ForegroundColor = ConsoleColor.Gray;
       }

       static void DeclaracionVariables()
       {
           //variables de tipo referencía el valor predeterminado es NULL
           //variables de tipo valor el valor predeterminado es 0
           string texto;
           string texto1 = null;
           string otroTexto = "Hola Mundo !!!";

           int numero = 214;
           System.Int32 numero2 = 142;
           Int32 numero3 = 12;
           int otroNumero;
           decimal a, b, c;

           //el tipo int es distinto a int?
           int? numero4 = null;

           //Instaciamos el objeto alumno
           Alumno alumno1 = new Alumno();
           alumno1.nombre = "Borja";

           var alumno2 = new Alumno();
           alumno2.nombre = "Borja";

           Object alumno3 = new Alumno();
           ((Alumno)alumno3).nombre = "Borja";

           dynamic alumno4 = new Alumno();
           alumno4.nombre = "Borja";

           Console.WriteLine("Tipo de la variable 1: " + alumno1.GetType());
           Console.WriteLine("Nombre: {0}", alumno1.nombre);

           Console.WriteLine("Tipo de la variable 2: " + alumno2.GetType());
           Console.WriteLine("Nombre: {0}", alumno2.nombre);

           Console.WriteLine("Tipo de la variable 3: " + alumno3.GetType());
           Console.WriteLine("Nombre: {0}", ((Alumno)alumno3).nombre);

           Console.WriteLine("Tipo de la variable 4: " + alumno4.GetType());
           Console.WriteLine("Nombre: {0}", alumno4.nombre);
       }

       static void ConversionVariables()
       {
           // 0 - 255
           byte var1 = 200;
           int var2 = 90;
           string var3 = "45";

           // ToString() convierte a texto cualquir valor númerico
           // o muestra el nombre del objeto.
           var3 = var1.ToString();


           //Conversión con TRYPARSE
           bool resultado = byte.TryParse(var3, out var1);
           resultado = byte.TryParse(var3, out _);

           Console.Clear();
           Console.WriteLine("Resultado: {0}", resultado.ToString());
           Console.WriteLine("Var1: {0}", var1.ToString());
           //Console.Write("L1 \nL2" + Environment.NewLine + "L3");
           Console.ReadKey();


           var1 = Convert.ToByte(var3);

           // Conversión con PARSE
           var1 = byte.Parse(var3);

           //Conversión implicita
           var2 = var1;

           //Conversión explicita
           var1 = (byte)var2;

           //Conversión utilizando el Objeto CONVERT
           var1 = Convert.ToByte(var2);
       }
   }
}