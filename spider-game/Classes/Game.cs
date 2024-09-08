using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace spider_game.Classes
{
    internal class Game
    {
        public FrameModel FrameModel { get; set; }
        public Mosquito Mosquito { get; set; }
        public Spider Spider { get; set; }
        public Score Score { get; set; }
        public Game()
        {
            Coordinates StartCoordinates = new Coordinates(50, 10);
            //FrameModel hola = new FrameModel(ConsoleColor.Magenta, new Coordinates(0, 0)
            //                , new Size(0, 0, 147, 40));
        }
        public void Play()
        {
            FrameModel hola = new FrameModel(ConsoleColor.Magenta, new Coordinates(0, 0)
               , new Size(0, 0, 147, 40));
            hola.DrawWeb();
            ConsoleKey key = ConsoleKey.C;
            Spider spider = new Spider(ConsoleColor.Yellow, new Coordinates(50, 10), key);
            spider.Draw();
            do
            {

                key = WaitKey();

                if (key == ConsoleKey.F)
                {
                    Mosquito mosquito = new Mosquito(ConsoleColor.Red, new Coordinates(147, 40), new Size(0, 0, 147, 40));
                    mosquito.DrawMosquito();
                }
            } while (!(key == ConsoleKey.Escape));

        }
        public ConsoleKey WaitKey()
        {
            ConsoleKeyInfo Key = Console.ReadKey(true);
            return Key.Key;
        }
    }
}
