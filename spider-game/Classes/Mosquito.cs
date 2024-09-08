﻿using FuncionesCiclos;
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
        private static Coordinates coordinatestatic;
        private static FrameModel framestatic;
        private static Size SizeSpider1static;
        private static Size SizeSpider2static;
        private static Score Score1static;
        private static Score Score2static;
        private static ConsoleColor Colorstatic;

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
            Coordinates mosquitoPosition= new Coordinates
            (
                Coordinates.X = random.Next(FrameModel.Size.EndWeight),
                Coordinates.Y = random.Next(FrameModel.Size.EndHeigh)
            );
            mosquitoPosition = BarrerMosquito(SizeSpider1,SizeSpider2, mosquitoPosition);
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
        
        public Coordinates Move(FrameModel FrameModel, Size SizeSpider1, Size SizeSpider2, bool reset, Score Score1, Score Score2)
        {
            Timer myTimer = new(30000);
            framestatic = FrameModel;
            SizeSpider1static= SizeSpider1;
            SizeSpider2static= SizeSpider2;
            coordinatestatic = Coordinates;
            Score1static = Score1;
            Score2static = Score2;           
            Colorstatic = ConsoleColor.Red;
            //Timer myTimer = new(10000);
            if (!reset)
            {
                myTimer.Enabled = true;
                myTimer.AutoReset = reset;
                coordinatestatic = DrawMosquito(FrameModel,SizeSpider1,SizeSpider2);
            }
            else
            {
                // Attach the Tick method to the Elapsed event
                myTimer.Elapsed += Tick;
                // Enable the Timer
                myTimer.Enabled = true;

            }
            myTimer.AutoReset = true;
            return coordinatestatic;
        }
        private static void Tick(Object source, ElapsedEventArgs e)
        {
            Mosquito mosquito = new Mosquito(Colorstatic,coordinatestatic); 
            Console.ForegroundColor = ConsoleColor.Cyan;
            GraphUtils.PaintXY(coordinatestatic.X, coordinatestatic.Y, "#");
            coordinatestatic = mosquito.DrawMosquito(framestatic, SizeSpider1static, SizeSpider2static);
            Score1static.Amount = Score1static.Substracion("Araña 1");
            Score2static.Amount = Score2static.Substracion("Araña 2");
        }
    }
}
