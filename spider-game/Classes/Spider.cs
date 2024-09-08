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
        //Coordinates CoordinatesSpider1 = new Coordinates(40, 10);
        //Coordinates CoordinatesSpider2 = new Coordinates(70, 10);
        public ConsoleColor Color { get; set; }
        public Coordinates Coordinates { get; set; }
        //public Coordinates CoordinatesSpider1 { get; set; }
        //public Coordinates CoordinatesSpider2 { get; set; }
        public Size Size { get; set; }
        //public Score Score { get; set; }
        public ConsoleKey Key { get; set; }

        public Spider(ConsoleColor color, Coordinates coordinates, /*Score score*/ ConsoleKey key)
        {
            Color = color;
            //this.CoordinatesSpider1 = CoordinatesSpider1;
            //this.CoordinatesSpider2 = CoordinatesSpider2;
            Coordinates = coordinates;
            Size = new Size(coordinates.Y, coordinates.Y + 3, coordinates.X, coordinates.X + 12);
            //Score = score;
            this.Key = key;
        }
        public Coordinates Move()
        {
            //UtilHelper utils = new UtilHelper();
            if (whatSpider == "player1")
            {
                //SpiderMomevent
                switch (Key)
                {
                    case ConsoleKey.UpArrow or ConsoleKey.W:
                        CoordinatesSpider1.Y = CoordinatesSpider1.Y - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        CoordinatesSpider1.Y = CoordinatesSpider1.Y + 1;
                        break;
                    case ConsoleKey.LeftArrow:
                        CoordinatesSpider1.X = CoordinatesSpider1.X - 1;
                        break;
                    case ConsoleKey.RightArrow:
                        CoordinatesSpider1.X = CoordinatesSpider1.X + 1;
                        break;
                }

                // if (utils.Spider1EatenUL(spiderPosition1, spiderPosition2) || utils.Spider1EatenUL(spiderPosition2, spiderPosition1))
                // {

                //     spiderPosition1.X = spiderPosition1.X + 1;
                //     spiderPosition1.Y = spiderPosition1.Y + 1;
                // }

                //spiderPosition1 = utils.Spider1Eaten(spiderPosition1, spiderPosition2, spider1Range);

            }
            else
            {
                //SpdierMovement
                switch (Key)
                {
                    case ConsoleKey.W:
                        CoordinatesSpider2.Y = CoordinatesSpider2.Y - 1;
                        break;
                    case ConsoleKey.S:
                        CoordinatesSpider2.Y = CoordinatesSpider2.Y + 1;
                        break;
                    case ConsoleKey.A:
                        CoordinatesSpider2.X = CoordinatesSpider2.X - 1;
                        break;
                    case ConsoleKey.D:
                        CoordinatesSpider2.X = CoordinatesSpider2.X + 1;
                        break;
                }
                // if (utils.Spider1EatenUL(spiderPosition1, spiderPosition2) || utils.Spider1EatenUL(spiderPosition2, spiderPosition1))
                // {
                //     spiderPosition2.X = spiderPosition2.X - 1;
                //     spiderPosition2.Y = spiderPosition2.Y - 1;
                // }
                //spiderPosition2 = utils.Spider1Eaten(spiderPosition2, spiderPosition1, spider1Range);
            }
            return Coordinates;
        }
        public void Draw()
        {
            //if (whatSpider == "player1")
            //{
            Console.ForegroundColor = ConsoleColor.Yellow;

            //WichSpider1
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
            //}
            //else
            //{
            //    Console.ForegroundColor = ConsoleColor.White;

            //    //Wichspider2
            //    switch (Key)
            //    {
            //        case ConsoleKey.W:

            //            int yo = 0;
            //            foreach (var arañaup in SpiderForm.UpSide)
            //            {
            //                GraphUtils.PrintXY(Coordinates.X, Coordinates.Y + yo, arañaup);
            //                yo++;
            //            }
            //            break;
            //        case ConsoleKey.S:
            //            int y1 = 0;
            //            foreach (var arañadown in SpiderForm.DownSide)
            //            {
            //                GraphUtils.PrintXY(Coordinates.X, Coordinates.Y + y1, arañadown);
            //                y1++;
            //            }
            //            break;
            //        case ConsoleKey.A:
            //            int y2 = 0;
            //            foreach (var arañaleft in SpiderForm.LeftSide)
            //            {
            //                GraphUtils.PrintXY(Coordinates.X, Coordinates.Y + y2, arañaleft);
            //                y2++;
            //            }
            //            break;
            //        case ConsoleKey.D:
            //            int y3 = 0;
            //            foreach (var arañaright in SpiderForm.RightSide)
            //            {
            //                GraphUtils.PrintXY(Coordinates.X, Coordinates.Y + y3, arañaright);
            //                y3++;
            //            }
            //            break;

            //    }
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
        public Coordinates Barrer()
        {
            //barrerweb
            if (Coordinates.X <= Size.InicioAncho)
            {
                Coordinates.X = Size.InicioAncho + 1;
            }
            else if (Coordinates.X >= Size.FinalAncho - 12)
            {
                Coordinates.X = Size.FinalAncho - 12;
            }
            if (Coordinates.Y <= Size.InicioAlto)
            {
                Coordinates.Y = Size.InicioAlto + 1;
            }
            else if (Coordinates.Y >= Size.FinalAlto - 4)
            {
                Coordinates.Y = Size.FinalAlto - 4;
            }

            //barrergap1

            if (Coordinates.X <= Size.InicioAncho + 7 && Coordinates.Y <= Size.InicioAlto + 6)
            {
                Coordinates.X = Coordinates.X + 1;
                Coordinates.Y = Coordinates.Y + 1;
            }

            //barrergap2
            if (Coordinates.X >= Size.InicioAncho + 121 && Coordinates.Y <= Size.InicioAlto + 6)
            {
                Coordinates.X = Coordinates.X - 1;
                Coordinates.Y = Coordinates.Y + 1;
            }

            //barrergap3
            if (Coordinates.X <= Size.InicioAncho + 22 && Coordinates.Y >= Size.InicioAlto + 31)
            {
                Coordinates.X = Coordinates.X + 1;
                Coordinates.Y = Coordinates.Y - 1;
            }

            //barrergap4
            if (Coordinates.X >= Size.InicioAncho + 125 && Coordinates.Y >= Size.InicioAlto + 27)
            {
                Coordinates.X = Coordinates.X - 1;
                Coordinates.Y = Coordinates.Y - 1;
            }
            //if (utils.Spider1EatenUL(spiderPosition1, spiderPosition2) || utils.Spider1EatenUL(spiderPosition2, spiderPosition1))
            //{
            //    spiderPosition2.X = spiderPosition2.X - 1;
            //    spiderPosition2.Y = spiderPosition2.Y - 1;
            //}
            //spiderPosition2 = utils.Spider1Eaten(spiderPosition2, spiderPosition1, spider1Range);
            return Coordinates;

        }
        public bool Spider1EatenUL(Coordinates positionPlayer1, Coordinates positionPlayer2)
        {
            // up left
            return positionPlayer1.X >= positionPlayer2.X - 12 && positionPlayer1.X <= positionPlayer2.X + 12
            && (positionPlayer1.Y + 3 >= positionPlayer2.Y && positionPlayer1.Y <= positionPlayer2.Y - 3
            || positionPlayer1.Y - 3 >= positionPlayer2.Y - 3 && positionPlayer1.Y - 3 <= positionPlayer2.Y);
        }
    }
}
