using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P44a1_ProyectoPilotarAvion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Avion miJetPrivado = new Avion("Gulfstream", "G800","CSI1-2022");
            int opcion;
            bool estaElPilotoFuera=false;

            do
            {
                Console.Clear();
                Console.WriteLine("\n\n\t\tAvión: {0}-{1}. Matrícula: {2}. Altitud máxima: {3}",miJetPrivado.Marca,miJetPrivado.Modelo,miJetPrivado.Matricula,Avion.ALTITUDMAXIMA1);
                Console.WriteLine("\n\t\tSituación actual --> Altitud: {0} m   Velocidad: {1} Km/h.",miJetPrivado.Altitud,miJetPrivado.Velocidad);
                opcion = Util.Menu();
                switch (opcion) 
                {
                    case 0:
                        estaElPilotoFuera=miJetPrivado.Salir();
                        break;
                    case 1:
                        miJetPrivado.AumentarVelocidad(Util.CapturaEntero("¿Que cantidad quiere incrementar la velocidad?: ",0));
                        break;
                    case 2:
                        miJetPrivado.DisminuirVelocidad(Util.CapturaEntero("¿Que cantidad quiere disminuir la velocidad?: ", 0));
                        break;
                    case 3:
                        miJetPrivado.Despegar();
                        break;
                    case 4:
                        miJetPrivado.AumentarAltitud(Util.CapturaEntero("¿En cuantos metros quiere incrementar la altitud?: ", 0));
                        break;
                    case 5:
                        miJetPrivado.DisminuirAltitud(Util.CapturaEntero("¿En cuantos metros quiere reducir la altitud?: ", 0));
                        break;
                    case 6:
                        miJetPrivado.Aterrizar();
                        break;

                }
            } while (opcion!=0 || !estaElPilotoFuera);
        }
    }
}
