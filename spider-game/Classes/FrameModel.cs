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
            for (int X = Size.StartWeight; X < Size.EndWeight + Size.StartWeight; X++)
            {
                GraphUtils.PaintXY(X, Size.StartHeigh, "═");
                GraphUtils.PaintXY(X, Size.StartHeigh + Size.EndHeigh, "═");
            }

            //LeftRightWeb
            for (int Y = Size.StartHeigh; Y < Size.EndHeigh + Size.StartHeigh; Y++)
            {
                GraphUtils.PaintXY(Size.StartWeight, Y, "║");
                GraphUtils.PaintXY(Size.StartWeight + Size.EndWeight, Y, "║");
            }
            //CornersWeb
            GraphUtils.PaintXY(Size.StartWeight, Size.StartHeigh, "╔");
            GraphUtils.PaintXY(Size.StartWeight, Size.StartHeigh + Size.EndHeigh, "╚");
            GraphUtils.PaintXY(Size.EndWeight, Size.StartHeigh, "╗");
            GraphUtils.PaintXY(Size.EndWeight, Size.StartHeigh + Size.EndHeigh, "╝");
            //InteriorWeb
            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int Y = Size.StartHeigh + 1; Y < Size.EndHeigh + Size.StartHeigh; Y++)
            {
                for (int X = Size.StartWeight + 1; X < Size.EndWeight + Size.StartWeight; X++)
                {
                    GraphUtils.PaintXY(X, Y, "#");
                }
            }

            //GapsWeb
            Console.ForegroundColor = ConsoleColor.Green;

            //Gap1
            for (int X = Size.StartWeight + 2; X < Size.EndWeight - 139 + Size.StartWeight; X++)
            {
                for (int Y = Size.StartHeigh + 2; Y < Size.EndHeigh - 33 + Size.StartHeigh; Y++)
                {
                    GraphUtils.PaintXY(X, Y, "°");
                }
            }

            //Gap2
            for (int X = Size.StartWeight + 132; X < Size.EndWeight - 2 + Size.StartWeight; X++)
            {
                for (int Y = Size.StartHeigh + 3; Y < Size.EndHeigh - 33 + Size.StartHeigh; Y++)
                {
                    GraphUtils.PaintXY(X, Y, "°");
                }
            }

            //Gap3
            for (int X = Size.StartWeight + 5; X < Size.EndWeight - 125 + Size.StartWeight; X++)
            {
                for (int Y = Size.StartHeigh + 35; Y < Size.EndHeigh - 1 + Size.StartHeigh; Y++)
                {
                    GraphUtils.PaintXY(X, Y, "°");
                }
            }

            //Gap4
            for (int X = Size.StartWeight + 138; X < Size.EndWeight - 2 + Size.StartWeight; X++)
            {
                for (int Y = Size.StartHeigh + 30; Y < Size.EndHeigh - 2 + Size.StartHeigh; Y++)
                {
                    GraphUtils.PaintXY(X, Y, "°");
                }
            }
        }
        public Coordinates BarrerSpider(Coordinates spiderPosition)
        {
            //BarrerWeb
            if (spiderPosition.X <= Size.StartWeight)
            {
                spiderPosition.X = Size.StartWeight + 1;
            }
            else if (spiderPosition.X >= Size.EndWeight - 12)
            {
                spiderPosition.X = Size.EndWeight - 12;
            }
            if (spiderPosition.Y <= Size.StartHeigh)
            {
                spiderPosition.Y = Size.StartHeigh + 1;
            }
            else if (spiderPosition.Y >= Size.EndHeigh - 4)
            {
                spiderPosition.Y = Size.EndHeigh - 4;
            }

            //BarrerGap1
            if (spiderPosition.X <= Size.StartWeight + 7 && spiderPosition.Y <= Size.StartHeigh + 6)
            {
                spiderPosition.X = spiderPosition.X + 1;
                spiderPosition.Y = spiderPosition.Y + 1;
            }

            //BarrerGap2
            if (spiderPosition.X >= Size.StartWeight + 121 && spiderPosition.Y <= Size.StartHeigh + 6)
            {
                spiderPosition.X = spiderPosition.X - 1;
                spiderPosition.Y = spiderPosition.Y + 1;
            }

            //BarrerGap3
            if (spiderPosition.X <= Size.StartWeight + 22 && spiderPosition.Y >= Size.StartHeigh + 31)
            {
                spiderPosition.X = spiderPosition.X + 1;
                spiderPosition.Y = spiderPosition.Y - 1;
            }

            //BarrerGap4
            if (spiderPosition.X >= Size.StartWeight + 125 && spiderPosition.Y >= Size.StartHeigh + 27)
            {
                spiderPosition.X = spiderPosition.X - 1;
                spiderPosition.Y = spiderPosition.Y - 1;
            }
            return spiderPosition;
        }
        public Coordinates BarrerMosquito(Coordinates mosquitoPosition)
        {
            if (mosquitoPosition.X <= Size.StartWeight)
            {
                mosquitoPosition.X = Size.StartWeight + 1;
            }
            else if (mosquitoPosition.Y >= Size.EndWeight)
            {
                mosquitoPosition.Y = Size.EndWeight - 1;
            }
            if (mosquitoPosition.Y <= Size.StartHeigh)
            {
                mosquitoPosition.Y = Size.StartHeigh + 1;
            }
            else if (mosquitoPosition.Y >= Size.EndHeigh)
            {
                mosquitoPosition.Y = Size.EndHeigh - 1;
            }

            //BarrerGap1

            if (mosquitoPosition.X <= Size.StartWeight + 8 && mosquitoPosition.Y <= Size.StartHeigh + 9)
            {
                mosquitoPosition.X = Size.StartWeight + 20;
                mosquitoPosition.Y = Size.StartHeigh + 15;
            }

            //BarrerGap2
            if (mosquitoPosition.X >= Size.StartWeight + 130 && mosquitoPosition.Y <= Size.StartHeigh + 8)
            {
                mosquitoPosition.X = Size.StartWeight + 124;
                mosquitoPosition.Y = Size.StartHeigh + 25;
            }

            //BarrerGap3
            if (mosquitoPosition.X <= Size.StartWeight + 23 && mosquitoPosition.Y >= Size.StartHeigh + 33)
            {
                mosquitoPosition.X = Size.StartWeight + 65;
                mosquitoPosition.Y = Size.StartHeigh + 38;
            }

            //BarrerGap4
            if (mosquitoPosition.X >= Size.StartWeight + 136 && mosquitoPosition.Y >= Size.StartHeigh + 28)
            {
                mosquitoPosition.X = Size.StartWeight + 128;
                mosquitoPosition.Y = Size.StartHeigh + 39;
            }
            return mosquitoPosition;
        }
    }
}
