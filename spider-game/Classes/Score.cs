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
        public int Adittion(string spider)
        {
            if (Amount < 10)
            {
                GraphUtils.PaintXY(Coordinates.X, Coordinates.Y, "               ");
                Amount++;
                GraphUtils.PaintXY(Coordinates.X, Coordinates.Y, spider + " =  " + Amount);

            }
            return Amount;
        }
        public int Substracion(string spider)
        {

            Amount--;
            GraphUtils.PaintXY(Coordinates.X, Coordinates.Y, "             ");
            GraphUtils.PaintXY(Coordinates.X, Coordinates.Y, spider + " =  " + Amount);
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
