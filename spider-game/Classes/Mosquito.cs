using FuncionesCiclos;
using game_gibby.helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Timers;
using Timer = System.Timers.Timer;

namespace spider_game.Classes
{
    internal class Mosquito
    {

        public ConsoleColor Color { get; set; }
        public Coordinates Coordinates { get; set; }
        public Mosquito(ConsoleColor Color, Coordinates Coordinates)
        {
            this.Color = Color;
            this.Coordinates = Coordinates;
        }
        public Coordinates DrawMosquito(FrameModel FrameModel, Size SizeSpider1, Size SizeSpider2)
        {
            Console.ForegroundColor = Color;
            var random = new Random();
            Coordinates mosquitoPosition = new Coordinates
            (
                Coordinates.X = random.Next(FrameModel.Size.EndWeight),
                Coordinates.Y = random.Next(FrameModel.Size.EndHeigh)
            );
            mosquitoPosition = BarrerMosquito(SizeSpider1, SizeSpider2, mosquitoPosition);
            mosquitoPosition = FrameModel.BarrerMosquito(mosquitoPosition);
            GraphUtils.PaintXY(mosquitoPosition.X, mosquitoPosition.Y, "+");
            return mosquitoPosition;
        }
        public Coordinates BarrerMosquito(Size SizeSpider1, Size SizeSpider2, Coordinates mosquitoPosition)
        {

            if (mosquitoPosition.Y >= SizeSpider1.StartHeigh && mosquitoPosition.Y <= SizeSpider1.EndHeigh
                && mosquitoPosition.X >= SizeSpider1.StartWeight && mosquitoPosition.X <= SizeSpider1.EndWeight)
            {
                mosquitoPosition.X = mosquitoPosition.X - 15;
                mosquitoPosition.Y = mosquitoPosition.Y - 7;
            }

            if (mosquitoPosition.Y >= SizeSpider2.StartHeigh && mosquitoPosition.Y <= SizeSpider2.EndHeigh
                && mosquitoPosition.X >= SizeSpider2.StartWeight && mosquitoPosition.X <= SizeSpider2.EndWeight)
            {
                mosquitoPosition.X = mosquitoPosition.X - 15;
                mosquitoPosition.Y = mosquitoPosition.Y - 7;
            }

            return mosquitoPosition;

        }
        public Coordinates Move(FrameModel FrameModel, Size SizeSpider1, Size SizeSpider2, Mosquito mosquito)
        {
            Erase(mosquito.Coordinates);
            mosquito.Coordinates = mosquito.DrawMosquito(FrameModel, SizeSpider1, SizeSpider2);

            return mosquito.Coordinates;
        }

        public void Erase(Coordinates mosquito)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            GraphUtils.PaintXY(mosquito.X, mosquito.Y, "#");
        }
    }
}
