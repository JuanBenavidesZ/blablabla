using game_gibby.helper;

public class SpiderGame : ISpiderGame
{
    public void WaitStart(int x, int y, FrameModel dimensiones)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        //UpDownFrame
        for (int X = dimensiones.InicioAncho; X < dimensiones.FinalAncho + dimensiones.InicioAncho; X++)
        {
            GraphUtils.PrintXY(X, dimensiones.InicioAlto, "═");
            GraphUtils.PrintXY(X, dimensiones.InicioAlto + dimensiones.FinalAlto, "═");
        }

        //LeftRightFrame
        for (int Y = dimensiones.InicioAlto; Y < dimensiones.FinalAlto + dimensiones.InicioAlto; Y++)
        {
            GraphUtils.PrintXY(dimensiones.InicioAncho, Y, "║");
            GraphUtils.PrintXY(dimensiones.InicioAncho + dimensiones.FinalAncho, Y, "║");
        }
        //CornerFrame
        GraphUtils.PrintXY(dimensiones.InicioAncho, dimensiones.InicioAlto, "╔");
        GraphUtils.PrintXY(dimensiones.InicioAncho, dimensiones.InicioAlto + dimensiones.FinalAlto, "╚");
        GraphUtils.PrintXY(dimensiones.FinalAncho, dimensiones.InicioAlto, "╗");
        GraphUtils.PrintXY(dimensiones.FinalAncho, dimensiones.InicioAlto + dimensiones.FinalAlto, "╝");

        //Clock
        string Chars = "|/-\\";
        int i = 0;

        //ClockWaiting
        while (!Console.KeyAvailable)
        {
            GraphUtils.PrintXY(x, y, "Las Arañas cazadoras");
            GraphUtils.PrintXY(x - 7, y + 1, "¡PULSA CUALQUIER TECLA PARA JUGAR!");
            Console.SetCursorPosition(x + 8, y + 2);
            Console.Write(Chars[i]);
            i++;
            if (i > 3) i = 0;
            Thread.Sleep(250);
        }

        //key
        Console.ReadKey(true);

        //EraseClock
        GraphUtils.PrintXY(x, y, " ");
    }

    public void DrawWeb(FrameModel frameDimensions, FrameModel holesWeb)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        //UpDownWeb
        for (int X = frameDimensions.InicioAncho; X < frameDimensions.FinalAncho + frameDimensions.InicioAncho; X++)
        {
            GraphUtils.PrintXY(X, frameDimensions.InicioAlto, "═");
            GraphUtils.PrintXY(X, frameDimensions.InicioAlto + frameDimensions.FinalAlto, "═");
        }

        //LeftRightWeb
        for (int Y = frameDimensions.InicioAlto; Y < frameDimensions.FinalAlto + frameDimensions.InicioAlto; Y++)
        {
            GraphUtils.PrintXY(frameDimensions.InicioAncho, Y, "║");
            GraphUtils.PrintXY(frameDimensions.InicioAncho + frameDimensions.FinalAncho, Y, "║");
        }
        //CornersWeb
        GraphUtils.PrintXY(frameDimensions.InicioAncho, frameDimensions.InicioAlto, "╔");
        GraphUtils.PrintXY(frameDimensions.InicioAncho, frameDimensions.InicioAlto + frameDimensions.FinalAlto, "╚");
        GraphUtils.PrintXY(frameDimensions.FinalAncho, frameDimensions.InicioAlto, "╗");
        GraphUtils.PrintXY(frameDimensions.FinalAncho, frameDimensions.InicioAlto + frameDimensions.FinalAlto, "╝");
        //InteriorWeb
        Console.ForegroundColor = ConsoleColor.Cyan;
        for (int Y = frameDimensions.InicioAlto + 1; Y < frameDimensions.FinalAlto + frameDimensions.InicioAlto; Y++)
        {
            for (int X = frameDimensions.InicioAncho + 1; X < frameDimensions.FinalAncho + frameDimensions.InicioAncho; X++)
            {
                GraphUtils.PrintXY(X, Y, "#");
            }
        }

        //GapsWeb
        Console.ForegroundColor = ConsoleColor.Green;

        //Gap1
        for (int X = holesWeb.InicioAncho + 2; X < holesWeb.FinalAncho - 139 + holesWeb.InicioAncho; X++)
        {
            for (int Y = holesWeb.InicioAlto + 2; Y < holesWeb.FinalAlto - 33 + holesWeb.InicioAlto; Y++)
            {
                GraphUtils.PrintXY(X, Y, "°");
            }
        }

        //Gap2
        for (int X = holesWeb.InicioAncho + 132; X < holesWeb.FinalAncho - 2 + holesWeb.InicioAncho; X++)
        {
            for (int Y = holesWeb.InicioAlto + 3; Y < holesWeb.FinalAlto - 33 + holesWeb.InicioAlto; Y++)
            {
                GraphUtils.PrintXY(X, Y, "°");
            }
        }

        //Gap3
        for (int X = holesWeb.InicioAncho + 5; X < holesWeb.FinalAncho - 125 + holesWeb.InicioAncho; X++)
        {
            for (int Y = holesWeb.InicioAlto + 35; Y < holesWeb.FinalAlto - 1 + holesWeb.InicioAlto; Y++)
            {
                GraphUtils.PrintXY(X, Y, "°");
            }
        }

        //Gap4
        for (int X = holesWeb.InicioAncho + 138; X < holesWeb.FinalAncho - 2 + holesWeb.InicioAncho; X++)
        {
            for (int Y = holesWeb.InicioAlto + 30; Y < holesWeb.FinalAlto - 2 + holesWeb.InicioAlto; Y++)
            {
                GraphUtils.PrintXY(X, Y, "°");
            }
        }
    }

    public CoordModel DrawMosquito(CoordModel rangePosition, FrameModel frame)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        var random = new Random();
        CoordModel mosquitoPosition = new CoordModel
        {
            X = random.Next(rangePosition.X),
            Y = random.Next(rangePosition.Y)
        };

        //BarrerWeb
        if (mosquitoPosition.X <= frame.InicioAncho)
        {
            mosquitoPosition.X = frame.InicioAncho + 1;
        }
        else if (mosquitoPosition.Y >= frame.FinalAncho)
        {
            mosquitoPosition.Y = frame.FinalAncho - 1;
        }
        if (mosquitoPosition.Y <= frame.InicioAlto)
        {
            mosquitoPosition.Y = frame.InicioAlto + 1;
        }
        else if (mosquitoPosition.Y >= frame.FinalAlto)
        {
            mosquitoPosition.Y = frame.FinalAlto - 1;
        }

        //BarrerGap1

        if (mosquitoPosition.X <= frame.InicioAncho + 8 && mosquitoPosition.Y <= frame.InicioAlto + 9)
        {
            mosquitoPosition.X = frame.InicioAncho + 20;
            mosquitoPosition.Y = frame.InicioAlto + 15;
        }

        //BarrerGap2
        if (mosquitoPosition.X >= frame.InicioAncho + 130 && mosquitoPosition.Y <= frame.InicioAlto + 8)
        {
            mosquitoPosition.X = frame.InicioAncho + 124;
            mosquitoPosition.Y = frame.InicioAlto + 25;
        }

        //BarrerGap3
        if (mosquitoPosition.X <= frame.InicioAncho + 23 && mosquitoPosition.Y >= frame.InicioAlto + 33)
        {
            mosquitoPosition.X = frame.InicioAncho + 65;
            mosquitoPosition.Y = frame.InicioAlto + 38;
        }

        //BarrerGap4
        if (mosquitoPosition.X >= frame.InicioAncho + 136 && mosquitoPosition.Y >= frame.InicioAlto + 28)
        {
            mosquitoPosition.X = frame.InicioAncho + 128;
            mosquitoPosition.Y = frame.InicioAlto + 39;
        }
        GraphUtils.PrintXY(mosquitoPosition.X, mosquitoPosition.Y, "+");
        return mosquitoPosition;


    }

    public void DrawSpider(CoordModel positionPlayer, ConsoleKey Teclapa, String playerNumber)
    {
        if (playerNumber == "player1")
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            //WichSpider1
            switch (Teclapa)
            {
                case ConsoleKey.UpArrow:

                    int yo = 0;
                    foreach (var arañaup in Spiders.UpSide)
                    {
                        GraphUtils.PrintXY(positionPlayer.X, positionPlayer.Y + yo, arañaup);
                        yo++;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    int y1 = 0;
                    foreach (var arañadown in Spiders.DownSide)
                    {
                        GraphUtils.PrintXY(positionPlayer.X, positionPlayer.Y + y1, arañadown);
                        y1++;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    int y2 = 0;
                    foreach (var arañaleft in Spiders.LeftSide)
                    {
                        GraphUtils.PrintXY(positionPlayer.X, positionPlayer.Y + y2, arañaleft);
                        y2++;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    int y3 = 0;
                    foreach (var arañaright in Spiders.RightSide)
                    {
                        GraphUtils.PrintXY(positionPlayer.X, positionPlayer.Y + y3, arañaright);
                        y3++;
                    }
                    break;
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.White;

            //Wichspider2
            switch (Teclapa)
            {
                case ConsoleKey.W:

                    int yo = 0;
                    foreach (var arañaup in Spiders.UpSide)
                    {
                        GraphUtils.PrintXY(positionPlayer.X, positionPlayer.Y + yo, arañaup);
                        yo++;
                    }
                    break;
                case ConsoleKey.S:
                    int y1 = 0;
                    foreach (var arañadown in Spiders.DownSide)
                    {
                        GraphUtils.PrintXY(positionPlayer.X, positionPlayer.Y + y1, arañadown);
                        y1++;
                    }
                    break;
                case ConsoleKey.A:
                    int y2 = 0;
                    foreach (var arañaleft in Spiders.LeftSide)
                    {
                        GraphUtils.PrintXY(positionPlayer.X, positionPlayer.Y + y2, arañaleft);
                        y2++;
                    }
                    break;
                case ConsoleKey.D:
                    int y3 = 0;
                    foreach (var arañaright in Spiders.RightSide)
                    {
                        GraphUtils.PrintXY(positionPlayer.X, positionPlayer.Y + y3, arañaright);
                        y3++;
                    }
                    break;

            }
        }
    }

    public ConsoleKey WaitKey()
    {
        ConsoleKeyInfo tecla_MOVIMIENTO = Console.ReadKey(true);
        return tecla_MOVIMIENTO.Key;
    }

    public void DeleteSpider(CoordModel coord)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;

        //EraseSpider
        GraphUtils.PrintXY(coord.X, coord.Y, "############");
        GraphUtils.PrintXY(coord.X, coord.Y + 1, "############");
        GraphUtils.PrintXY(coord.X, coord.Y + 2, "############");
        GraphUtils.PrintXY(coord.X, coord.Y + 3, "############");
    }

    public CoordModel MoveSpider(ConsoleKey keyMovement, CoordModel spiderPosition1, CoordModel spiderPosition2, FrameModel frameDimension, FrameModel holesWeb, string whatSpider)
    {
        UtilsHelper utils = new UtilsHelper();
        if (whatSpider == "player1")
        {
            //SpiderMomevent
            switch (keyMovement)
            {
                case ConsoleKey.UpArrow:
                    spiderPosition1.Y = spiderPosition1.Y - 1;
                    break;
                case ConsoleKey.DownArrow:
                    spiderPosition1.Y = spiderPosition1.Y + 1;
                    break;
                case ConsoleKey.LeftArrow:
                    spiderPosition1.X = spiderPosition1.X - 1;
                    break;
                case ConsoleKey.RightArrow:
                    spiderPosition1.X = spiderPosition1.X + 1;
                    break;
            }
            //BarrerWeb
            if (spiderPosition1.X <= frameDimension.InicioAncho)
            {
                spiderPosition1.X = frameDimension.InicioAncho + 1;
            }
            else if (spiderPosition1.X >= frameDimension.FinalAncho - 12)
            {
                spiderPosition1.X = frameDimension.FinalAncho - 12;
            }
            if (spiderPosition1.Y <= frameDimension.InicioAlto)
            {
                spiderPosition1.Y = frameDimension.InicioAlto + 1;
            }
            else if (spiderPosition1.Y >= frameDimension.FinalAlto - 4)
            {
                spiderPosition1.Y = frameDimension.FinalAlto - 4;
            }

            //BarrerGap1

            if (spiderPosition1.X <= frameDimension.InicioAncho + 7 && spiderPosition1.Y <= frameDimension.InicioAlto + 6)
            {
                spiderPosition1.X = spiderPosition1.X + 1;
                spiderPosition1.Y = spiderPosition1.Y + 1;
            }

            //BarrerGap2
            if (spiderPosition1.X >= frameDimension.InicioAncho + 121 && spiderPosition1.Y <= frameDimension.InicioAlto + 6)
            {
                spiderPosition1.X = spiderPosition1.X - 1;
                spiderPosition1.Y = spiderPosition1.Y + 1;
            }

            //BarrerGap3
            if (spiderPosition1.X <= frameDimension.InicioAncho + 22 && spiderPosition1.Y >= frameDimension.InicioAlto + 31)
            {
                spiderPosition1.X = spiderPosition1.X + 1;
                spiderPosition1.Y = spiderPosition1.Y - 1;
            }

            //BarrerGap4
            if (spiderPosition1.X >= frameDimension.InicioAncho + 125 && spiderPosition1.Y >= frameDimension.InicioAlto + 27)
            {
                spiderPosition1.X = spiderPosition1.X - 1;
                spiderPosition1.Y = spiderPosition1.Y - 1;
            }

            return spiderPosition1;
        }
        else
        {
            //SpdierMovement
            switch (keyMovement)
            {
                case ConsoleKey.W:
                    spiderPosition2.Y = spiderPosition2.Y - 1;
                    break;
                case ConsoleKey.S:
                    spiderPosition2.Y = spiderPosition2.Y + 1;
                    break;
                case ConsoleKey.A:
                    spiderPosition2.X = spiderPosition2.X - 1;
                    break;
                case ConsoleKey.D:
                    spiderPosition2.X = spiderPosition2.X + 1;
                    break;
            }
            //BarrerWeb
            if (spiderPosition2.X <= frameDimension.InicioAncho)
            {
                spiderPosition2.X = frameDimension.InicioAncho + 1;
            }
            else if (spiderPosition2.X >= frameDimension.FinalAncho - 12)
            {
                spiderPosition2.X = frameDimension.FinalAncho - 12;
            }
            if (spiderPosition2.Y <= frameDimension.InicioAlto)
            {
                spiderPosition2.Y = frameDimension.InicioAlto + 1;
            }
            else if (spiderPosition2.Y >= frameDimension.FinalAlto - 4)
            {
                spiderPosition2.Y = frameDimension.FinalAlto - 4;
            }


            //BarrerGap1
            if (spiderPosition2.X <= frameDimension.InicioAncho + 7 && spiderPosition2.Y <= frameDimension.InicioAlto + 6)
            {
                spiderPosition2.X = spiderPosition2.X + 1;
                spiderPosition2.Y = spiderPosition2.Y + 1;
            }

            //BarrerGap2
            if (spiderPosition2.X >= frameDimension.InicioAncho + 121 && spiderPosition2.Y <= frameDimension.InicioAlto + 6)
            {
                spiderPosition2.X = spiderPosition2.X - 1;
                spiderPosition2.Y = spiderPosition2.Y + 1;
            }

            //BarrerGap3
            if (spiderPosition2.X <= frameDimension.InicioAncho + 22 && spiderPosition2.Y >= frameDimension.InicioAlto + 31)
            {
                spiderPosition2.X = spiderPosition2.X + 1;
                spiderPosition2.Y = spiderPosition2.Y - 1;
            }

            //BarrerGap4
            if (spiderPosition2.X >= frameDimension.InicioAncho + 125 && spiderPosition2.Y >= frameDimension.InicioAlto + 27)
            {
                spiderPosition2.X = spiderPosition2.X - 1;
                spiderPosition2.Y = spiderPosition2.Y - 1;
            }
            if (utils.Araña1Eaten(spiderPosition1, spiderPosition2) || utils.Araña1Eaten(spiderPosition1, spiderPosition2))
            {
                spiderPosition2.X = spiderPosition2.X - 1;
                spiderPosition2.Y = spiderPosition2.Y - 1;
            }
            return spiderPosition2;
        }

    }

    public int ScoreOne(CoordModel scorePosition, int score)
    {
        if (score < 10)
        {
            GraphUtils.PrintXY(scorePosition.X, scorePosition.Y, "Araña 1 = " + score);
            score++;
        }
        else if (score == 10)
        {
            GraphUtils.PrintXY(scorePosition.X, scorePosition.Y, "GANO Araña 1");
            GraphUtils.PrintXY(scorePosition.X + 130, scorePosition.Y, "PERDIO Araña 2");
        }
        return score;
    }

    public int ScoreTwo(CoordModel scorePosition, int score)
    {
        if (score < 10)
        {
            GraphUtils.PrintXY(scorePosition.X + 130, scorePosition.Y, "Araña 2 = " + score);
            score++;
        }
        else if (score == 10)
        {
            GraphUtils.PrintXY(scorePosition.X + 130, scorePosition.Y, "GANO Araña 2");
            GraphUtils.PrintXY(scorePosition.X, scorePosition.Y, "PERDIO Araña 1");
        }
        return score;
    }
}