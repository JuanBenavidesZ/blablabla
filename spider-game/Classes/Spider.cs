using game_gibby.helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spider_game.Classes
{
    internal class Spider
    {
        public ConsoleColor Color { get; set; }
        public Coordinates Coordinates { get; set; }
        public Size Size { get; set; }
        //public Score Score { get; set; }
        public ConsoleKey Key { get; set; }

        public Spider(ConsoleColor Color, Coordinates coordinates, /*Score score*/ ConsoleKey key, Size Size)
        {
            this.Color = Color;
            Coordinates = coordinates;
            this.Size = Size;
            //Score = score;
            this.Key = key;
        }
        public Coordinates Move(FrameModel FrameModel, Coordinates standingSpider)
        {
            //UtilHelper utils = new UtilHelper();
                //SpiderMomevent
                switch (Key)
                {
                    case ConsoleKey.UpArrow or ConsoleKey.W:
                        Coordinates.Y = Coordinates.Y - 1;
                        break;
                    case ConsoleKey.DownArrow or ConsoleKey.S:
                        Coordinates.Y = Coordinates.Y + 1;
                        break;
                    case ConsoleKey.LeftArrow or ConsoleKey.A:
                        Coordinates.X = Coordinates.X - 1;
                        break;
                    case ConsoleKey.RightArrow or ConsoleKey.D:
                        Coordinates.X = Coordinates.X + 1;
                        break;
                }
                Coordinates = FrameModel.BarrerSpider(Coordinates);
                Coordinates = BarrerSpider(standingSpider);
                return Coordinates;
        }
        public void Draw()
        {
            
            Console.ForegroundColor = Color;
            //WichSpider
            switch (Key)
            {
                case ConsoleKey.UpArrow or ConsoleKey.W:

                    int yo = 0;
                    foreach (var arañaup in SpiderForm.UpSide)
                    {
                        GraphUtils.PrintXY(Coordinates.X, Coordinates.Y + yo, arañaup);
                        yo++;
                    }
                    break;
                case ConsoleKey.DownArrow or ConsoleKey.S:
                    int y1 = 0;
                    foreach (var arañadown in SpiderForm.DownSide)
                    {
                        GraphUtils.PrintXY(Coordinates.X, Coordinates.Y + y1, arañadown);
                        y1++;
                    }
                    break;
                case ConsoleKey.LeftArrow or ConsoleKey.A:
                    int y2 = 0;
                    foreach (var arañaleft in SpiderForm.LeftSide)
                    {
                        GraphUtils.PrintXY(Coordinates.X, Coordinates.Y + y2, arañaleft);
                        y2++;
                    }
                    break;
                case ConsoleKey.RightArrow or ConsoleKey.D:
                    int y3 = 0;
                    foreach (var arañaright in SpiderForm.RightSide)
                    {
                        GraphUtils.PrintXY(Coordinates.X, Coordinates.Y + y3, arañaright);
                        y3++;
                    }
                    break;
            }
        }
        public void Erase()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            //EraseSpider
            GraphUtils.PrintXY(Coordinates.X, Coordinates.Y, "############");
            GraphUtils.PrintXY(Coordinates.X, Coordinates.Y + 1, "############");
            GraphUtils.PrintXY(Coordinates.X, Coordinates.Y + 2, "############");
            GraphUtils.PrintXY(Coordinates.X, Coordinates.Y + 3, "############");
        }
        public Coordinates BarrerSpider(Coordinates standingSpider)
        {
            if (Size.FinalAlto == standingSpider.Y &&
            (Size.InicioAncho >= standingSpider.X && Size.InicioAncho <= standingSpider.X + 12 ||
                Size.FinalAncho >= standingSpider.X && Size.FinalAncho <= standingSpider.X + 12))
            {
                // arriba
                Coordinates.X--;
                Coordinates.Y--;
            }
            if (Size.FinalAncho == standingSpider.X &&
                (Size.InicioAlto >= standingSpider.Y && Size.InicioAlto <= standingSpider.Y + 4
                    || Size.FinalAlto >= standingSpider.Y && Size.FinalAlto <= standingSpider.Y + 4))
            {
                // izquierda
                Coordinates.X--;
                Coordinates.Y--;

            }
            if (Size.InicioAncho == standingSpider.X + 12 &&
                (Size.InicioAlto >= standingSpider.Y && Size.InicioAlto <= standingSpider.Y + 4
                    || Size.FinalAlto >= standingSpider.Y && Size.FinalAlto <= standingSpider.Y + 4))
            {
                // derecha
                Coordinates.X++;
                Coordinates.Y++;
            }
            if (Size.InicioAlto == standingSpider.Y + 4 &&
                (Size.InicioAncho >= standingSpider.X && Size.InicioAncho <= standingSpider.X + 12 ||
                    Size.FinalAncho >= standingSpider.X && Size.FinalAncho <= standingSpider.X + 12))
            {
                // abajo
                Coordinates.X++;
                Coordinates.Y++;
            }

            return Coordinates;

        }
        public bool Eat(Coordinates coordinates, Coordinates mosquito)
        {
            return coordinates.X <= mosquito.X && coordinates.X + 12 >= mosquito.X &&
                coordinates.Y <= mosquito.Y && coordinates.Y + 4 >= mosquito.Y;
        } 
    }
}
