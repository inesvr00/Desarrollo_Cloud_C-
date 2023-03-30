using System.Collections;
using System.Collections.Generic;

namespace Clase
{

    public class Practicando
    {
        public static void Main(string[] args)
        {
            Hashtable();
        }

        public static void ArrayList()
        {
            // Instanciar
            ArrayList array = new ArrayList();

            // Limpiar y eliminar los elementos
            array.Clear();

            // Añadir elementos
            array.Add(1);
            array.Add("Inés");
            array.Add(new { Nombre = "Maria", Apellidos = "del Carmen"});
            array.Add(new Alumno());

            // Añadir elemento en una posición 
            array.Insert(4, "blanco");

            // Añadir todos los elementos de otra colección
            var colores = new string[] {"azul", "rojo", "verde", "amarillo"};
            array.AddRange(colores);

            // Número de elementos del ArrayList
            Console.WriteLine($"Número de elementos: {array.Count}");

            // Eliminar elementos
            array.Remove("azul");
            array.RemoveAt(4);
            array.RemoveRange(2, 2);

            // Saber si un elemento está contenido
            Console.WriteLine($"Contiene el item rojo: {array.Contains("rojo")}");

            // Ordenar el array, aunque no lo ordena
            array.Sort();

            // Invertir el orden
            array.Reverse();

            // Convertir en un array de Object -> object[] array = new array[10]
            var nuevoArray = array.ToArray();

            // Recorrer el ArrayList
            foreach(var item in array)
                Console.WriteLine($"Item: {item}");

            for (var i = 0; i < array.Count; i++)
                Console.WriteLine($"{i}# {array[i]}");

        }
        public static void DemoArrays()
        {
            var alumno = new Alumno();

            int[] array1 = new int[5];

            Alumno[] array2 = new Alumno[5];

            int[] array = new int[] {6, 90, -15, 32};

            Alumno[] array4 = new Alumno[] {alumno, alumno, alumno};
            array4[0].Nombre = "Borja";
            array4[1].Nombre = "Ana";

            Alumno[] array5 = new Alumno[] {new Alumno(), new Alumno(), new Alumno()};
            array5[0].Nombre = "Ana";
            array5[1].Nombre = "Borja";

            Console.WriteLine(array4[0].Nombre);
            Console.WriteLine(array4[1].Nombre);
            Console.WriteLine(array4[2].Nombre);

            Console.WriteLine(array5[0].Nombre);
            Console.WriteLine(array5[1].Nombre);
            Console.WriteLine(array5[2].Nombre);
            
            int[] array3a = new int[] {6, 90, -15, 32};
            int[] array3b = {6, 90, -17, 32};

            int[,] array3c = new int[2, 5];
            array3c[0,0] = 32;
            array3c[0,1] = 32;
            array3c[1, 4] = 32;
            int[,] array3d = { {1, 62}, {2, 89}, {5, -16}, {15, 16}};
            Console.WriteLine(array3d[2,1]); // Mostrar -16

            int[][] array8 = new int[5][];
            array8[0] = new int[] { 45, 98, 172, 888, 12};
            array8[1] = new int[] { 888, 12};
            array8[2] = new int[] { 888, 12, 45, 98, 2172, 1888, 122};

            Console.WriteLine(array8[0][0]);
            Console.WriteLine(array8[1][0]);
            Console.WriteLine(array8[2][2]);

        }

        public static void Hashtable()
        {
            // Instanciar 
            var ht = new Hashtable();

            // Elimiar todos los elementos
            ht.Clear();

            // Añadir elementos
            ht.Add(1200, "Inés Victoria Rodríguez");
            ht.Add("ANATR", "Ana Trujillo");
            ht.Add(412, new Alumno());

            // Número de elementos
            Console.WriteLine($"Número de elementos: {ht.Count}");

            // Eliminar un elemento
            ht.Remove(1200);

            // Recorrer el HashTable
            foreach (var clave in ht.Keys) Console.WriteLine($"{clave}: {ht[clave]}");

        }

        public static void List()
        
        {
            // Instanciar
            List<string> list = new List<string>();

            List<string> list1 = new();
            var list2 = new List<string>();

            // Eliminar
            list.Clear();

            // Añadir elementos
            list.Add("azul");
            list.Add("verde");
            list.Add("amarillo");
            list.Add("rosa");

            // Añadir elementos en una posición
            list.Insert(4, "blanco");

            // Añadir todos los elementos de otra colección
            var colores = new string[] {"negro", "lila", "turquesa", "naranja"};
            list.AddRange(colores);

            // Número de elementos del List
            Console.WriteLine($"Número de elementos: {list.Count}");

            // Eliminar elementos
            list.Remove("azul");
            list.RemoveAt(4);
            list.RemoveRange(2, 2);

            // Saber si un elemento está contenido
            Console.WriteLine($"Contiene el item rojo: {list.Contains("rojo")}");

            // Ordena los elementos
            list.Sort();

            // Invertir el orden
            list.Reverse();

            // Convertir en un array de object -> object[] array = new array[10]
            var nuevoArray = list.ToArray();

            // Recorrer el list
            // Recorrer el List

            foreach (var item in list)
                Console.WriteLine($"{list.IndexOf(item)}# Item: {item}");

            for (var i = 0; i < list.Count; i++)
				Console.WriteLine($"{i}# {list[i]}");
        }

        public static void Dictionary()
        {
           	// Instanciar
			Dictionary<int, string> dic = new Dictionary<int, string>();

			Dictionary<int, string> dic1 = new();
			var dic2 = new Dictionary<int, string>();

			// Eliminar todos los elemento
			dic.Clear();

			// Añadir elementos
			dic.Add(1200, "Borja Cabeza");
			dic.Add(1300, "Ana Trujillo");
			dic.Add(1412, "José Guzman");

			// Número de elementos
			Console.WriteLine($"Número de elementos: {dic.Count}");

			// Eliminar un elemento
			dic.Remove(1200);

			// Recorrer el diccionario
			foreach (var clave in dic.Keys)

				Console.WriteLine($"{clave}: {dic[clave]}"); 
        }
    }

    public class Alumno
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Edad {get; set; }
    }
}