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
        public FrameModel(ConsoleColor Color)
        {
            this.Color = Color;
            Size = new Size(0,0,147,40);
            Coordinates = new Coordinates(0,0);
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
        public Coordinates BarrerSpider(Coordinates spiderPosition)
        {
            //BarrerWeb
            if (spiderPosition.X <= Size.InicioAncho)
            {
                spiderPosition.X = Size.InicioAncho + 1;
            }
            else if (spiderPosition.X >= Size.FinalAncho - 12)
            {
                spiderPosition.X = Size.FinalAncho - 12;
            }
            if (spiderPosition.Y <= Size.InicioAlto)
            {
                spiderPosition.Y = Size.InicioAlto + 1;
            }
            else if (spiderPosition.Y >= Size.FinalAlto - 4)
            {
                spiderPosition.Y = Size.FinalAlto - 4;
            }

            //BarrerGap1
            if (spiderPosition.X <= Size.InicioAncho + 7 && spiderPosition.Y <= Size.InicioAlto + 6)
            {
                spiderPosition.X = spiderPosition.X + 1;
                spiderPosition.Y = spiderPosition.Y + 1;
            }

            //BarrerGap2
            if (spiderPosition.X >= Size.InicioAncho + 121 && spiderPosition.Y <= Size.InicioAlto + 6)
            {
                spiderPosition.X = spiderPosition.X - 1;
                spiderPosition.Y = spiderPosition.Y + 1;
            }

            //BarrerGap3
            if (spiderPosition.X <= Size.InicioAncho + 22 && spiderPosition.Y >= Size.InicioAlto + 31)
            {
                spiderPosition.X = spiderPosition.X + 1;
                spiderPosition.Y = spiderPosition.Y - 1;
            }

            //BarrerGap4
            if (spiderPosition.X >= Size.InicioAncho + 125 && spiderPosition.Y >= Size.InicioAlto + 27)
            {
                spiderPosition.X = spiderPosition.X - 1;
                spiderPosition.Y = spiderPosition.Y - 1;
            }
            return spiderPosition;
        }
        public Coordinates BarrerMosquito(Coordinates mosquitoPosition)
        {
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
            return mosquitoPosition;
        }
    }
}
