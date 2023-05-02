using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace P44a1_ProyectoPilotarAvion
{
    internal static class Util
    {
        public static int CapturaEntero(string mensaje, int min, int max) 
        {
            int valor = 0;
            bool numCorrecto;

            do
            {
                Console.Write("\n\t{0} [{1}..{2}]: ", mensaje, min, max);
                numCorrecto = Int32.TryParse(Console.ReadLine(), out valor);

                if (!numCorrecto)
                    Console.WriteLine("\n\t** [ERROR] No ha introducido un número entero. **");
                else if (valor < min || valor > max)
                {
                    numCorrecto = false;
                    Console.WriteLine("\n\t** [ERROR] El número introducido no se encuentra entre {0} y {1}. **", min, max);
                }


            } while (!numCorrecto);

            return valor;
        }
        public static int Menu() 
        {
            Console.WriteLine("\t\t\t╔════════════════════════════╗");
            Console.WriteLine("\t\t\t║ Opciones del Piloto        ║");
            Console.WriteLine("\t\t\t╠════════════════════════════╣");
            Console.WriteLine("\t\t\t║ 1) Aumentar Velocidad      ║");
            Console.WriteLine("\t\t\t║ 2) Disminuir Velocidad     ║");
            Console.WriteLine("\t\t\t║ 3) Despegar                ║");
            Console.WriteLine("\t\t\t║ 4) Aumentar Altitud        ║");
            Console.WriteLine("\t\t\t║ 5) Disminuir Altitud       ║");
            Console.WriteLine("\t\t\t║ 6) Aterrizar               ║");
            Console.WriteLine("\t\t\t║                            ║");
            Console.WriteLine("\t\t\t║ 0) Salir                   ║");
            Console.WriteLine("\t\t\t║                            ║");
            Console.WriteLine("\t\t\t╚════════════════════════════╝");

            return CapturaNumPulsado("\t\t\tPulse su opción", 0, 8);
        }
        public static int CapturaNumPulsado(string mensaje, int min, int max)
        {
            int valor = 0;

            do
            {
                Console.Write("{0} [{1}..{2}]: ", mensaje, min, max);
                valor = Console.ReadKey().KeyChar - '0';

                if (valor < min || valor > max)
                {
                    Console.Beep();
                    Console.Write(" ** NO VALIDO. ({0} a {1})\n", min, max);
                }

            } while (valor < min || valor > max);

            return valor;
        }
        public static void MostrarError(string mensaje) 
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("*** Error: {0} ***",mensaje);
            Console.ResetColor();
        }
    }
}
