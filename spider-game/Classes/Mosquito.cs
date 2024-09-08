using game_gibby.helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spider_game.Classes
{
    internal class Mosquito
    {
        public ConsoleColor Color { get; set; }
        public Coordinates Coordinates { get; set; }
        public Size Size { get; set; }
        public Mosquito(ConsoleColor Color, Coordinates Coordinates, Size Size)
        {
            this.Color = Color;
            this.Coordinates = Coordinates;
            this.Size = Size;
        }
        public Coordinates Mover()
        {

            return Coordinates;
        }
        public Coordinates DrawMosquito()
        {
            Console.ForegroundColor = Color;
            var random = new Random();
            Coordinates mosquitoPosition = new Coordinates
            (
                Coordinates.X = random.Next(Coordinates.X),
                Coordinates.Y = random.Next(Coordinates.Y)
            );
            if (mosquitoPosition.Y >= Size.InicioAlto && mosquitoPosition.Y <= Size.FinalAlto
            && mosquitoPosition.X >= Size.InicioAncho && mosquitoPosition.X <= Size.FinalAncho)
            {
                mosquitoPosition.X = mosquitoPosition.X - 15;
                mosquitoPosition.Y = mosquitoPosition.Y - 7;
            }

            if (mosquitoPosition.Y >= Size.InicioAlto && mosquitoPosition.Y <= Size.FinalAlto
                && mosquitoPosition.X >= Size.InicioAncho && mosquitoPosition.X <= Size.FinalAncho)
            {
                mosquitoPosition.X = mosquitoPosition.X - 15;
                mosquitoPosition.Y = mosquitoPosition.Y - 7;
            }

            //BarrerWeb
            if (mosquitoPosition.X <= Size.InicioAncho)
            {
                mosquitoPosition.X = Size.InicioAncho + 1;
            }
            else if (mosquitoPosition.Y >= Size.FinalAncho)
            {
                mosquitoPosition.Y = Size.FinalAncho - 1;
            }
            if (mosquitoPosition.Y <= Size.InicioAlto)
            {
                mosquitoPosition.Y = Size.InicioAlto + 1;
            }
            else if (mosquitoPosition.Y >= Size.FinalAlto)
            {
                mosquitoPosition.Y = Size.FinalAlto - 1;
            }

            //BarrerGap1

            if (mosquitoPosition.X <= Size.InicioAncho + 8 && mosquitoPosition.Y <= Size.InicioAlto + 9)
            {
                mosquitoPosition.X = Size.InicioAncho + 20;
                mosquitoPosition.Y = Size.InicioAlto + 15;
            }

            //BarrerGap2
            if (mosquitoPosition.X >= Size.InicioAncho + 130 && mosquitoPosition.Y <= Size.InicioAlto + 8)
            {
                mosquitoPosition.X = Size.InicioAncho + 124;
                mosquitoPosition.Y = Size.InicioAlto + 25;
            }

            //BarrerGap3
            if (mosquitoPosition.X <= Size.InicioAncho + 23 && mosquitoPosition.Y >= Size.InicioAlto + 33)
            {
                mosquitoPosition.X = Size.InicioAncho + 65;
                mosquitoPosition.Y = Size.InicioAlto + 38;
            }

            //BarrerGap4
            if (mosquitoPosition.X >= Size.InicioAncho + 136 && mosquitoPosition.Y >= Size.InicioAlto + 28)
            {
                mosquitoPosition.X = Size.InicioAncho + 128;
                mosquitoPosition.Y = Size.InicioAlto + 39;
            }
            GraphUtils.PrintXY(mosquitoPosition.X, mosquitoPosition.Y, "+");
            return mosquitoPosition;
        }
    }
}
