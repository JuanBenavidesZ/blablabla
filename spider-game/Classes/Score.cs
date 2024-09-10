using game_gibby.helper;
using static System.Formats.Asn1.AsnWriter;

namespace spider_game.Classes
{
    internal class Score
    {
        public Coordinates Coordinates { get; set; }
        public ConsoleColor Color { get; set; }
        public int Amount { get; set; }
        public Score(ConsoleColor Color, Coordinates Coordinates, int Amount)
        {
            this.Coordinates = Coordinates;
            this.Color = Color;
            this.Amount = Amount;
        }
        public void ShowScore(string spider, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            GraphUtils.PaintXY(Coordinates.X, Coordinates.Y, "               ");
            GraphUtils.PaintXY(Coordinates.X, Coordinates.Y, spider + " =  " + Amount);
        }
        public int Adittion(string spider)
        {
            Console.ForegroundColor = Color;
            if (Amount < 10)
            {
                Amount++;
                ShowScore(spider, ConsoleColor.Blue);
            }
            return Amount;
        }
        public int Substracion(string spider)
        {
            //Color = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Red;
            Amount--;
            ShowScore(spider, ConsoleColor.Red);
            return Amount;
        }
        public void Winner(string spider)
        {
            if (Amount == 10)
            {
                GraphUtils.PaintXY(Coordinates.X, Coordinates.Y, "GANO " + spider);
            }
        }
    }
}
