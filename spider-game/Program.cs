using System.Text.RegularExpressions;
using Microsoft.VisualBasic;



namespace FuncionesCiclos
{
    public class Program
    {
        public static CoordModel mosquito;
        public static FrameModel frameDimension = new(0, 0, 147, 40);
        public static CoordModel rangeFrame = new CoordModel(147, 40);
        static void Main(string[] args)
        {
            UtilsHelper utilsHelper = new UtilsHelper();
            SpiderGame newSpiderGame = new SpiderGame();

            //FrameModel frameDimension = new(0, 0, 147, 40);

            FrameModel holesCoord = new FrameModel(0, 0, 147, 40);


            CoordModel positionPlayer1 = new CoordModel(40, 20);

            //CoordModel rangeFrame = new CoordModel(147, 40);

            CoordModel positionPlayer2 = new CoordModel(75, 5);

            CoordModel scorePosition = new CoordModel(3, 41);

            //CursorVisible
            Console.CursorVisible = false;

            newSpiderGame.WaitStart(65, 20, frameDimension);

            newSpiderGame.DrawWeb(frameDimension, holesCoord);

            //Inicializacion Tecla fantasma
            ConsoleKey Tecla = ConsoleKey.W & ConsoleKey.UpArrow;
            //mosquito = newSpiderGame.DrawMosquito(rangeFrame, frameDimension);
            mosquito = utilsHelper.TimeMosquito();

            int score1 = 1;
            int score2 = 1;
            do
            {
                // >
                // <
                // CoordModel mosquito;
                // Tecla = newSpiderGame.WaitKey();
                // >
                // <
                // do
                // {
                // //     // newSpiderGame.DrawSpider(positionPlayer1, Tecla, "player1");
                // //     // newSpiderGame.DrawSpider(positionPlayer2, Tecla, "player2");
                // //     mosquito = newSpiderGame.DrawMosquito(rangeFrame, frameDimension);
                // //     Thread.Sleep(5000);
                // //     Console.SetCursorPosition(mosquito.X, mosquito.Y);
                // //     Console.Write("#");
                // //     // } while (!utilsHelper.ValidKeys(Tecla) || !utilsHelper.MosquitoEaten(positionPlayer1, mosquito) || !utilsHelper.MosquitoEaten(positionPlayer2, mosquito));
                // // } while (!utilsHelper.MosquitoEaten(positionPlayer1, mosquito) || !utilsHelper.MosquitoEaten(positionPlayer2, mosquito));

                // if (utilsHelper.MosquitoEaten(positionPlayer1, mosquito) || utilsHelper.MosquitoEaten(positionPlayer2, mosquito))
                // {
                //     mosquito = newSpiderGame.DrawMosquito(rangeFrame, frameDimension);
                // }
                // // else
                // // {
                // //     Thread.Sleep(3000);
                // //     Console.SetCursorPosition(mosquito.X, mosquito.Y);
                // //     Console.Write("#");
                // //     mosquito = newSpiderGame.DrawMosquito(rangeFrame, frameDimension);
                // // }

                if (utilsHelper.MosquitoEaten(positionPlayer1, mosquito) || utilsHelper.MosquitoEaten(positionPlayer2, mosquito))
                {
                    mosquito = newSpiderGame.DrawMosquito(rangeFrame, frameDimension);
                    // Thread.Sleep(3000);
                }
                //else
                //{
                //    // Thread.Sleep(3000);
                //    Console.SetCursorPosition(mosquito.X, mosquito.Y);
                //    Console.Write("#");
                //    mosquito = newSpiderGame.DrawMosquito(rangeFrame, frameDimension);
                //}

                newSpiderGame.DrawSpider(positionPlayer1, Tecla, "player1");
                newSpiderGame.DrawSpider(positionPlayer2, Tecla, "player2");

                Tecla = newSpiderGame.WaitKey();


                if (ConsoleKey.W == Tecla || ConsoleKey.A == Tecla || ConsoleKey.S == Tecla || ConsoleKey.D == Tecla)
                {
                    newSpiderGame.DeleteSpider(positionPlayer2);
                    positionPlayer2 = newSpiderGame.MoveSpider(Tecla, positionPlayer1, positionPlayer2, frameDimension, holesCoord, "player2");

                }
                else
                {
                    newSpiderGame.DeleteSpider(positionPlayer1);
                    positionPlayer1 = newSpiderGame.MoveSpider(Tecla, positionPlayer1, positionPlayer2, frameDimension, holesCoord, "player1");
                }

                if (utilsHelper.MosquitoEaten(positionPlayer1, mosquito))
                {
                    score1 = newSpiderGame.ScoreOne(scorePosition, score1);
                }
                if (utilsHelper.MosquitoEaten(positionPlayer2, mosquito))
                {
                    score2 = newSpiderGame.ScoreTwo(scorePosition, score2);
                }

            } while (Tecla != ConsoleKey.Escape);

        }
    }
}
