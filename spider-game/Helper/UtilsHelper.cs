using FuncionesCiclos;
using game_gibby.helper;
using System.Timers;
using Timer = System.Timers.Timer;

public class UtilsHelper
{
    public bool MosquitoEaten(CoordModel positionPlayer, CoordModel mosquito)
    {
        return positionPlayer.X <= mosquito.X && positionPlayer.X + 11 >= mosquito.X &&
                positionPlayer.Y <= mosquito.Y && positionPlayer.Y + 3 >= mosquito.Y;
    }

    public bool ValidKeys(ConsoleKey key)
    {
        bool a = ConsoleKey.W != key || ConsoleKey.A != key || ConsoleKey.S != key || ConsoleKey.D != key ||
        ConsoleKey.UpArrow != key || ConsoleKey.DownArrow != key || ConsoleKey.LeftArrow != key || ConsoleKey.RightArrow != key;
        return a;
    }
    public bool Spider1EatenUL(CoordModel positionPlayer1, CoordModel positionPlayer2)
    {
        // up left
        return positionPlayer1.X >= positionPlayer2.X - 12 && positionPlayer1.X <= positionPlayer2.X + 12
        && (positionPlayer1.Y + 3 >= positionPlayer2.Y && positionPlayer1.Y <= positionPlayer2.Y - 3
        || positionPlayer1.Y - 3 >= positionPlayer2.Y - 3 && positionPlayer1.Y - 3 <= positionPlayer2.Y);
    }

    public FrameModel RangeSPider(CoordModel positionPlayer)
    {
        return new FrameModel
        {
            FinalAlto = positionPlayer.Y + 4,
            FinalAncho = positionPlayer.X + 12,
            InicioAlto = positionPlayer.Y,
            InicioAncho = positionPlayer.X
        };
    }

    public CoordModel Spider1Eaten(CoordModel movingSpider, CoordModel standingSpider, FrameModel rangeSpider)
    {

        if (rangeSpider.FinalAlto == standingSpider.Y &&
            (rangeSpider.InicioAncho >= standingSpider.X && rangeSpider.InicioAncho <= standingSpider.X + 12 ||
                rangeSpider.FinalAncho >= standingSpider.X && rangeSpider.FinalAncho <= standingSpider.X + 12))
        {
            // arriba
            movingSpider.X--;
            movingSpider.Y--;
        }
        if (rangeSpider.FinalAncho == standingSpider.X &&
            (rangeSpider.InicioAlto >= standingSpider.Y && rangeSpider.InicioAlto <= standingSpider.Y + 4
                || rangeSpider.FinalAlto >= standingSpider.Y && rangeSpider.FinalAlto <= standingSpider.Y + 4))
        {
            // izquierda
            movingSpider.X--;
            movingSpider.Y--;

        }
        if (rangeSpider.InicioAncho == standingSpider.X + 12 &&
            (rangeSpider.InicioAlto >= standingSpider.Y && rangeSpider.InicioAlto <= standingSpider.Y + 4
                || rangeSpider.FinalAlto >= standingSpider.Y && rangeSpider.FinalAlto <= standingSpider.Y + 4))
        {
            // derecha
            movingSpider.X++;
            movingSpider.Y++;
        }
        if (rangeSpider.InicioAlto == standingSpider.Y + 4 &&
            (rangeSpider.InicioAncho >= standingSpider.X && rangeSpider.InicioAncho <= standingSpider.X + 12 ||
                rangeSpider.FinalAncho >= standingSpider.X && rangeSpider.FinalAncho <= standingSpider.X + 12))
        {
            // abajo
            movingSpider.X++;
            movingSpider.Y++;
        }

        return movingSpider;
    }

    // Create a Timer that ticks every second
    static Timer myTimer = new(10000);

    public CoordModel TimeMosquito(bool reset)
    {
        SpiderGame spiderGame = new();
        //myTimer.Stop();
        //myTimer.Start();

        if (!reset)
        {
            // Attach the Tick method to the Elapsed event
            //myTimer.Elapsed += Tick;
            // Enable the Timer
            myTimer.Enabled = true;
            myTimer.AutoReset = reset;
            Program.mosquito = spiderGame.DrawMosquito(Program.rangeFrame, Program.frameSPider1, Program.frameSpider2);
            return Program.mosquito;
            //myTimer.EndInit();
        }


        // Attach the Tick method to the Elapsed event
        myTimer.Elapsed += Tick;
        // Enable the Timer
        myTimer.Enabled = true;
        myTimer.AutoReset = true;
        //myTimer.Stop();
        //myTimer.Start();



        return Program.mosquito;
    }

    // This method will be called every second
    private static void Tick(Object source, ElapsedEventArgs e)
    {
        SpiderGame spiderGame = new();
        Console.ForegroundColor = ConsoleColor.Cyan;
        GraphUtils.PrintXY(Program.mosquito.X, Program.mosquito.Y, "#");
        Program.mosquito = spiderGame.DrawMosquito(Program.rangeFrame, Program.frameSPider1, Program.frameSpider2);
        //Program.score1 = spiderGame.ScoreOne(Program.score1, false);
        //Program.score2 = spiderGame.ScoreTwo(Program.score2, false);
    }

}