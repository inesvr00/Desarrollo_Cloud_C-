using System;

namespace Programando.CSharp.Demos3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // 0 - 255
            byte var1 = 200;
            int var2 = 90;
            string var3 = "45";

            var1 = Convert.ToByte(var3);
            // Convierte el texto en byte
            var1 = byte.Parse(var3);
            // Convierte el string a byte
            var2 = int.Parse("89");
            // Conversión con TryParse
            bool resultado = byte.TryParse(var3, out var1);

            Console.Clear();
            Console.WriteLine("Resultado: {0}", resultado);
            Console.WriteLine("Var1: {0}", var1);
            Console.ReadKey();

            // Conversión implícita
            var2 = var1;

            // Conversión explícita
            var1 = (byte)var2;

            // Conversión utilizando el objeto CONVERT
            var1 = Convert.ToByte(var2);

            Console.WriteLine("Var1: {0}", var1);
            Console.ReadKey();
        }
    }
}
