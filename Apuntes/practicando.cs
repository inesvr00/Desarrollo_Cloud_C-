using System;

namespace Practicando
{
   public class Ejercicios
   {
       public static void Main(string[] args)
       {       
           Console.Clear();   
           //sumita(); 
           //nombreyciudad();
           // mayorque();
           // finde();
           // pares1_100();
           pares1_100y3();
       }

       static void sumita()
       {
           int num1 = 2;
           int num2 = 3;
           int num3 = 10;

           int suma = num1 + num2 + num3;

           Console.WriteLine($"El resultado de la suma de: {num1} + {num2} + {num3} = {suma}");
       }

       static void nombreyciudad()
       {
           Persona usuario = new Persona();

           Console.WriteLine($"Por favor introduzca su nombre: ");
           usuario.nombre = Console.ReadLine();

           Console.WriteLine($"Por favor introduzca la ciudad destino: ");
           usuario.ciudad = Console.ReadLine();

           Console.WriteLine($"Hola {usuario.nombre}, bienvenido/a a {usuario.ciudad}");
       }

       static void mayorque()
       {
           Console.WriteLine($"Por favor introduzca el primer número: ");
           string num1 = Console.ReadLine();
           int num1int = Convert.ToInt32(num1);

           Console.WriteLine($"Por favor introduzca el segundo número: ");
           string num2 = Console.ReadLine();
           int num2int = Convert.ToInt32(num2);

           if(num1int > num2int)
           {
               Console.Write($"{num1} > {num2}. El número mayor es {num1}");
           }

           else
           {
               Console.Write($"{num2} > {num1}. El número mayor es {num2}");
           }
       }

       static void finde()
       {
           string[] semana = {"lunes", "martes", "miércoles", "jueves", "viernes", "sábado", "domingo"};

           Console.WriteLine("Por favor introduzca el día de la semana: ");
           string dia = Console.ReadLine().ToLower();

           while (Array.IndexOf(semana, dia) == -1)
           {
               Console.WriteLine("El valor ingresado no es un día de la semana válido. Por favor, inténtelo de nuevo.");
               Console.WriteLine("Por favor introduzca el día de la semana: ");
               dia = Console.ReadLine().ToLower();
           }

           if (Array.IndexOf(semana, dia) < 5)
           {
               Console.WriteLine("Es un día laborable.");
           }
           else
           {
               Console.WriteLine("No es un día laborable.");
           }
       }

       static void pares1_100()
       {
           Console.WriteLine("A continuación se muestran los números pares que se encuentran entre el 1 y el 100: ");
           for (int i = 0; i < 101; i++)
           {
               if (i%2 == 0)
               {
                   Console.WriteLine(i);
               }
                
           }
       }

       static void pares1_100y3()
       {
           Console.WriteLine("A continuación se muestran los números divisibles entre 2 y 3 que se encuentran entre el 1 y el 100: ");
           for (int i = 0; i < 101; i++)
           {
               if (i % 2 == 0 && i % 3 == 0)
               {
                   Console.WriteLine(i);
               }
                
           }
       }
   }

}