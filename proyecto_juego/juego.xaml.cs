using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace proyecto_juego
{
    
    public partial class juego : Window
    {
        public juego()
        {
            InitializeComponent();
        }

        
        enum Direccion { Arriba, Abajo, Derecha, Izquierda, Ninguna }; 
        Direccion direccionJugador = Direccion.Ninguna;

        double velocidadHero = 300;
        void moverjugador(TimeSpan deltaTime)
        {
            double LeftNaveActual = Canvas.GetLeft(hero);
            double bottomNaveActual = Canvas.GetTop(hero);

            switch (direccionJugador)
            {
                case Direccion.Arriba:

                    double topNaveActual = Canvas.GetTop(hero);
                    //Primero el elemento a mover, Luego los valores a mover                  
                    if (bottomNaveActual - (velocidadHero * deltaTime.TotalSeconds) >= 0)
                    {
                        Canvas.SetTop(hero, topNaveActual - (velocidadHero * deltaTime.TotalSeconds));
                    }
                    break;

                case Direccion.Abajo:

                    double nuevaPosicion1 = bottomNaveActual + (velocidadHero * deltaTime.TotalSeconds);
                    if (nuevaPosicion1 + hero.Width <= 440)
                    {

                        Canvas.SetTop(hero, nuevaPosicion1);
                    }


                    break;

                case Direccion.Izquierda: 

                    if (LeftNaveActual - (velocidadHero * deltaTime.TotalSeconds) >= 0)
                    {
                        Canvas.SetLeft(hero, LeftNaveActual - (velocidadHero * deltaTime.TotalSeconds));
                    }
                    break;

                case Direccion.Derecha:

                    double nuevaPosicion = LeftNaveActual + (velocidadHero * deltaTime.TotalSeconds);
                    if (nuevaPosicion + hero.Width <= 800)
                    {
                        Canvas.SetLeft(hero, nuevaPosicion);
                    }

                    break;

                case Direccion.Ninguna:
                    break;
            }
        }
    }
}
