using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P44a1_ProyectoPilotarAvion
{
    internal class Avion
    {

        //Atributos
        string marca, modelo,matricula;
        const int ALTITUDMAXIMA = 1000;
        int altitud, velocidad;
        bool haDespegado;

        //Constructores
        public Avion(string marca, string modelo, string matricula)
        {
            this.Marca = marca;
            this.Modelo = modelo;
            this.Matricula = matricula;
            this.Altitud = 0;
            this.Velocidad = 0;
            this.HaDespegado = false;
        }
        #region Propiedades básicas
        public string Marca { get => marca; set => marca = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public string Matricula { get => matricula; set => matricula = value; }
        public static int ALTITUDMAXIMA1 => ALTITUDMAXIMA;
        public int Altitud { get => altitud; set => altitud = value; }
        public int Velocidad { get => velocidad; set => velocidad = value; }
        public bool HaDespegado { get => haDespegado; set => haDespegado = value; }
        #endregion

        //Métodos
        public void AumentarVelocidad(int cantAumentar) 
        {
            Console.WriteLine("\n\tOK: aumentando {0}km/h la velocidad.", cantAumentar);
            velocidad += cantAumentar;
            Util.Pausa();
        }
        public void DisminuirVelocidad(int cantReducir) 
        {
            if ((velocidad - cantReducir < 100) && HaDespegado)
                Util.MostrarError("\n\t*** Error: la velocidad no puede bajar de 100Km/h porque se estrellaría ***");
            else if (velocidad == 0)
                Util.MostrarError("\n\t** Error: No se puede disminuir la velocidad, ya se encuentra parado ***");
            else if ((velocidad - cantReducir < 0) && !HaDespegado)
                Util.MostrarError("\n\t** Error: No se puede disminuir la velocidad menor de cero ***");
            else
            {
                Console.WriteLine("\n\tOK: reduciendo {0}km/h la velocidad. Pulse una tecla.", cantReducir);
                velocidad -= cantReducir;
            }
            Util.Pausa();

        }
        public void Despegar() 
        {
            if(HaDespegado)
                Util.MostrarError("\n\tEl avión ya se encuentra en el aire!");       
            else if (velocidad < 200)
                Util.MostrarError("\n\t*** Error: Velocidad insuficiente para despegar ***");
            else 
            {
                HaDespegado = true;
                altitud = 100;
                Console.WriteLine("\n\tEl avión ha despegado!");
            }
            Util.Pausa();

        }
        public void AumentarAltitud(int cantAumentar) 
        {
            if (!HaDespegado)
                Util.MostrarError("\n\t *** Error: Antes tiene que despegar ***");
            else if ((altitud + cantAumentar) > ALTITUDMAXIMA)
                Util.MostrarError("\n\t *** Error: Superaría la Altitud máxima de 1000 m ***");
            else 
            {
                Console.WriteLine("\n\tOK: Aumentando altitud en {0} m.",cantAumentar);
                altitud += cantAumentar;
            }
            Util.Pausa();

        }
        public void DisminuirAltitud(int cantReducir) 
        {
            if ((altitud - cantReducir < 100) && HaDespegado)
                Util.MostrarError("\n\t*** Error: En vuelo no se puede bajar de 100m de altitud, es peligroso ***");
            else if (!HaDespegado)
                Util.MostrarError("\n\t*** Error: No se puede bajar de altitud cuando aún no ha despegado ***");
            else if (altitud - cantReducir < 0)
                Util.MostrarError("\n\t** Error: No se puede disminuir la altitud, ya se encuentra en el suelo ***");
            else
            {
                Console.WriteLine("\n\tOK: Reduciendo altitud en {0} m.", cantReducir); 
                altitud -= cantReducir;
            }
            Util.Pausa();

        }
        public void Aterrizar() 
        {
            if (!HaDespegado)
                Util.MostrarError("\n\t *** Error: el avion no ha despegado aún, intenta despegar primero ***");
            else if (altitud < 200 && velocidad < 400)
            {
                HaDespegado = false;
                altitud = 0;
                velocidad = 0;
                Console.WriteLine("\n\tOK avión aterrizado! Pulse una tecla.");
            }
            else
                Util.MostrarError("\n\t***Error: Para aterrizar: Altitud < 200m y Velocidad < 400 km/h ***");

            Util.Pausa();

        }
        public bool Salir() 
        {
            if (velocidad == 0 && !HaDespegado)
            {
                Console.WriteLine("\n\tSaliendo del avión");
                Util.Pausa();
                return true;
            }
            else
            {
                Util.MostrarError("\n\t *** Error: El avión debe estar en el suelo y parado para salir ***");
                Util.Pausa();
                return false;
            }


        }

    }
}
