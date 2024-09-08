﻿using System.Text.RegularExpressions;
using game_gibby.helper;
using Microsoft.VisualBasic;



namespace FuncionesCiclos
{
    public class Program
    {
        public static CoordModel mosquito;
        public static FrameModel frameDimension = new(0, 0, 147, 40);
        public static CoordModel rangeFrame = new CoordModel(147, 40);
        public static FrameModel frameSPider1;
        public static FrameModel frameSpider2;
        public static int score1;
        public static int score2;
        static void Main(string[] args)
        {
            UtilsHelper utilsHelper = new UtilsHelper();
            SpiderGame newSpiderGame = new SpiderGame();

            FrameModel holesCoord = new FrameModel(0, 0, 147, 40);

            CoordModel positionPlayer1 = new CoordModel(40, 20);

            CoordModel positionPlayer2 = new CoordModel(75, 5);

            //CursorVisible
            Console.CursorVisible = false;

            newSpiderGame.WaitStart(65, 20, frameDimension);

            newSpiderGame.DrawWeb(frameDimension, holesCoord);

            //Inicializacion Tecla fantasma
            ConsoleKey Tecla = ConsoleKey.W & ConsoleKey.UpArrow;
            mosquito = newSpiderGame.DrawMosquito(rangeFrame, frameSPider1, frameSpider2);
            GraphUtils.PrintXY(positionPlayer1.X,positionPlayer1.Y,"Hola jejeje jkjujuju");
            mosquito = utilsHelper.TimeMosquito(true);

            score1 = 0;
            score2 = 0;
            do
            {
                frameSPider1 = utilsHelper.RangeSPider(positionPlayer1);
                frameSpider2 = utilsHelper.RangeSPider(positionPlayer2);
                bool mosquitoWasEaten = utilsHelper.MosquitoEaten(positionPlayer1, mosquito) || utilsHelper.MosquitoEaten(positionPlayer2, mosquito);

                if (mosquitoWasEaten)
                {
                    mosquito = utilsHelper.TimeMosquito(false);
                }

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
                    score1 = newSpiderGame.ScoreOne(score1, true);
                }
                if (utilsHelper.MosquitoEaten(positionPlayer2, mosquito))
                {
                    score2 = newSpiderGame.ScoreTwo(score2, true);
                }
                

            } while (Tecla != ConsoleKey.Escape);

        }
    }
}
