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
            FrameModel = new FrameModel(ConsoleColor.Magenta);
        }
        public void Play()
        {
            ConsoleKey key = ConsoleKey.C;
            Size size = new Size(0, 0, 12, 3);
            Spider spider1 = new Spider(ConsoleColor.Yellow, new Coordinates(50, 10), key, size);
            Spider spider2 = new Spider(ConsoleColor.White, new Coordinates(70, 10), key, size);
            Mosquito mosquito = new Mosquito(ConsoleColor.Red, new Coordinates(147, 40));
            Score Score1 = new Score(ConsoleColor.Blue,new Coordinates(3,41),0);
            Score Score2 = new Score(ConsoleColor.Blue, new Coordinates(133, 41), 0);
            FrameModel.DrawWeb();
            Console.CursorVisible = false;
            mosquito.Coordinates = mosquito.DrawMosquito(FrameModel, spider1.Size, spider2.Size);
            mosquito.Coordinates = mosquito.Mover(FrameModel, spider1.Size, spider2.Size, true, Score1, Score2);
            do
            {
                spider1.Draw();
                spider2.Draw();
                key = WaitKey();
                bool mosquitoWasEaten1 = spider1.Eat(spider1.Coordinates, mosquito.Coordinates);
                bool mosquitoWasEaten2 = spider2.Eat(spider2.Coordinates, mosquito.Coordinates);
                if (mosquitoWasEaten1)
                {
                    mosquito.Coordinates = mosquito.Mover(FrameModel, spider1.Size, spider2.Size, false,Score1, Score2);
                }
                if (mosquitoWasEaten2)
                {
                    mosquito.Coordinates = mosquito.Mover(FrameModel, spider1.Size, spider2.Size, false, Score1, Score2);
                }
                if (key == ConsoleKey.W || key == ConsoleKey.S || key == ConsoleKey.A || key == ConsoleKey.D)
                {
                    spider1.Key = key;
                    spider1.Erase();
                    spider1.Coordinates = spider1.Move(FrameModel,spider2.Coordinates);
                    spider1.Size = new Size(spider1.Coordinates.X,spider1.Coordinates.Y,spider1.Coordinates.X+12,spider1.Coordinates.Y+4);
                }
                if (key == ConsoleKey.UpArrow|| key == ConsoleKey.DownArrow || key == ConsoleKey.LeftArrow || key == ConsoleKey.RightArrow)
                {
                    spider2.Key = key;
                    spider2.Erase();
                    spider2.Coordinates = spider2.Move(FrameModel,spider1.Coordinates);
                    spider2.Size = new Size(spider2.Coordinates.X, spider2.Coordinates.Y, spider2.Coordinates.X + 12, spider2.Coordinates.Y + 4);

                }
                if (mosquitoWasEaten1)
                {
                    Score1.Amount = Score1.Adittion("Araña 1");
                    Score1.Winner("Araña 1 ");
                }
                if (mosquitoWasEaten2)
                {
                    Score2.Amount = Score2.Adittion("Araña 2");
                    Score2.Winner("Araña 2 ");
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
