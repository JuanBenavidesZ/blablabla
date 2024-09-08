using game_gibby.helper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spider_game.Classes
{
    internal class FrameModel
    {
        public ConsoleColor Color { get; set; }
        public Size Size { get; set; }
        public Coordinates Coordinates { get; set; }
        public FrameModel(ConsoleColor Color, Coordinates coordinates, Size Size)
        {
            this.Color = Color;
            this.Size = Size;
            Coordinates = coordinates;
        }
        public void DrawWeb()
        {
            Console.ForegroundColor = Color;
            for (int X = Size.InicioAncho; X < Size.FinalAncho + Size.InicioAncho; X++)
            {
                GraphUtils.PrintXY(X, Size.InicioAlto, "═");
                GraphUtils.PrintXY(X, Size.InicioAlto + Size.FinalAlto, "═");
            }

            //LeftRightWeb
            for (int Y = Size.InicioAlto; Y < Size.FinalAlto + Size.InicioAlto; Y++)
            {
                GraphUtils.PrintXY(Size.InicioAncho, Y, "║");
                GraphUtils.PrintXY(Size.InicioAncho + Size.FinalAncho, Y, "║");
            }
            //CornersWeb
            GraphUtils.PrintXY(Size.InicioAncho, Size.InicioAlto, "╔");
            GraphUtils.PrintXY(Size.InicioAncho, Size.InicioAlto + Size.FinalAlto, "╚");
            GraphUtils.PrintXY(Size.FinalAncho, Size.InicioAlto, "╗");
            GraphUtils.PrintXY(Size.FinalAncho, Size.InicioAlto + Size.FinalAlto, "╝");
            //InteriorWeb
            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int Y = Size.InicioAlto + 1; Y < Size.FinalAlto + Size.InicioAlto; Y++)
            {
                for (int X = Size.InicioAncho + 1; X < Size.FinalAncho + Size.InicioAncho; X++)
                {
                    GraphUtils.PrintXY(X, Y, "#");
                }
            }

            //GapsWeb
            Console.ForegroundColor = ConsoleColor.Green;

            //Gap1
            for (int X = Size.InicioAncho + 2; X < Size.FinalAncho - 139 + Size.InicioAncho; X++)
            {
                for (int Y = Size.InicioAlto + 2; Y < Size.FinalAlto - 33 + Size.InicioAlto; Y++)
                {
                    GraphUtils.PrintXY(X, Y, "°");
                }
            }

            //Gap2
            for (int X = Size.InicioAncho + 132; X < Size.FinalAncho - 2 + Size.InicioAncho; X++)
            {
                for (int Y = Size.InicioAlto + 3; Y < Size.FinalAlto - 33 + Size.InicioAlto; Y++)
                {
                    GraphUtils.PrintXY(X, Y, "°");
                }
            }

            //Gap3
            for (int X = Size.InicioAncho + 5; X < Size.FinalAncho - 125 + Size.InicioAncho; X++)
            {
                for (int Y = Size.InicioAlto + 35; Y < Size.FinalAlto - 1 + Size.InicioAlto; Y++)
                {
                    GraphUtils.PrintXY(X, Y, "°");
                }
            }

            //Gap4
            for (int X = Size.InicioAncho + 138; X < Size.FinalAncho - 2 + Size.InicioAncho; X++)
            {
                for (int Y = Size.InicioAlto + 30; Y < Size.FinalAlto - 2 + Size.InicioAlto; Y++)
                {
                    GraphUtils.PrintXY(X, Y, "°");
                }
            }
        }
    }
}
