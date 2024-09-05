public class SpiderGame : ISpiderGame
{
    public void WaitStart(int x, int y, FrameModel dimensiones)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        //Parte superior e inferior del marco
        for (int X = dimensiones.InicioAncho; X < dimensiones.FinalAncho + dimensiones.InicioAncho; X++)
        {

            Console.SetCursorPosition(X, dimensiones.InicioAlto);
            Console.Write("=");
            Console.SetCursorPosition(X, dimensiones.InicioAlto + dimensiones.FinalAlto);
            Console.Write("=");
        }

        //Parte lateral izquierdo y derecho del marco
        for (int Y = dimensiones.InicioAlto; Y < dimensiones.FinalAlto + dimensiones.InicioAlto; Y++)
        {
            Console.SetCursorPosition(dimensiones.InicioAncho, Y);
            Console.Write("║");
            Console.SetCursorPosition(dimensiones.InicioAncho + dimensiones.FinalAncho, Y);
            Console.Write("║");
        }
        //Caracteres del reloj
        string Chars = "|/-\\";
        int i = 0;

        //Ciclo activamiento/desactivamiento reloj
        while (!Console.KeyAvailable)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine("Las Arañas cazadoras");
            Console.SetCursorPosition(x - 7, y + 1);
            Console.WriteLine("¡PULSA CUALQUIER TECLA PARA JUGAR!");
            Console.SetCursorPosition(x + 8, y + 2);
            Console.Write(Chars[i]);
            i++;
            if (i > 3) i = 0;
            Thread.Sleep(250);
        }

        //esperar tecla 
        Console.ReadKey(true);

        //Borrar reloj
        Console.SetCursorPosition(x, y);
        Console.Write(" ");
    }

    public void DrawWeb(FrameModel frameDimensions, FrameModel holesWeb)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        //Parte superior e inferior del marco
        for (int X = frameDimensions.InicioAncho; X < frameDimensions.FinalAncho + frameDimensions.InicioAncho; X++)
        {

            Console.SetCursorPosition(X, frameDimensions.InicioAlto);
            Console.Write("=");
            Console.SetCursorPosition(X, frameDimensions.InicioAlto + frameDimensions.FinalAlto);
            Console.Write("=");
        }

        //Parte lateral izquierdo y derecho del marco
        for (int Y = frameDimensions.InicioAlto; Y < frameDimensions.FinalAlto + frameDimensions.InicioAlto; Y++)
        {
            Console.SetCursorPosition(frameDimensions.InicioAncho, Y);
            Console.Write("║");
            Console.SetCursorPosition(frameDimensions.InicioAncho + frameDimensions.FinalAncho, Y);
            Console.Write("║");
        }

        //Relleno del marco
        Console.ForegroundColor = ConsoleColor.Cyan;
        for (int Y = frameDimensions.InicioAlto + 1; Y < frameDimensions.FinalAlto + frameDimensions.InicioAlto; Y++)
        {
            for (int X = frameDimensions.InicioAncho + 1; X < frameDimensions.FinalAncho + frameDimensions.InicioAncho; X++)
            {
                Console.SetCursorPosition(X, Y);
                Console.WriteLine("#");
            }
        }

        //HUECOS DE LA TELARAÑA
        Console.ForegroundColor = ConsoleColor.Green;

        //Hueco 1
        for (int X = holesWeb.InicioAncho + 2; X < holesWeb.FinalAncho - 139 + holesWeb.InicioAncho; X++)
        {
            for (int Y = holesWeb.InicioAlto + 2; Y < holesWeb.FinalAlto - 33 + holesWeb.InicioAlto; Y++)
            {
                Console.SetCursorPosition(X, Y);
                Console.WriteLine("°");
            }
        }

        //Hueco 2
        for (int X = holesWeb.InicioAncho + 132; X < holesWeb.FinalAncho - 2 + holesWeb.InicioAncho; X++)
        {
            for (int Y = holesWeb.InicioAlto + 3; Y < holesWeb.FinalAlto - 33 + holesWeb.InicioAlto; Y++)
            {
                Console.SetCursorPosition(X, Y);
                Console.WriteLine("°");
            }
        }

        //Hueco 3
        for (int X = holesWeb.InicioAncho + 5; X < holesWeb.FinalAncho - 125 + holesWeb.InicioAncho; X++)
        {
            for (int Y = holesWeb.InicioAlto + 35; Y < holesWeb.FinalAlto - 1 + holesWeb.InicioAlto; Y++)
            {
                Console.SetCursorPosition(X, Y);
                Console.WriteLine("°");
            }
        }

        //Hueco 4
        for (int X = holesWeb.InicioAncho + 138; X < holesWeb.FinalAncho - 2 + holesWeb.InicioAncho; X++)
        {
            for (int Y = holesWeb.InicioAlto + 30; Y < holesWeb.FinalAlto - 2 + holesWeb.InicioAlto; Y++)
            {
                Console.SetCursorPosition(X, Y);
                Console.WriteLine("°");
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
        // int randomX = random.Next(rangePosition.X);
        // int randomY = random.Next(rangePosition.Y);
        // rangePosition.X = randomX;
        // rangePosition.Y = randomY;


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

        //Barrera Hueco1

        if (mosquitoPosition.X <= frame.InicioAncho + 7 && mosquitoPosition.Y <= frame.InicioAlto + 6)
        {
            mosquitoPosition.X = frame.InicioAncho + 20;
            mosquitoPosition.Y = frame.InicioAlto + 15;
        }

        //Barrera Hueco2
        if (mosquitoPosition.X >= frame.InicioAncho + 113 && mosquitoPosition.X <= frame.InicioAncho + 126 && mosquitoPosition.Y >= frame.InicioAlto + 11 && mosquitoPosition.Y <= frame.InicioAlto + 14)
        {
            mosquitoPosition.X = frame.InicioAncho + 124;
            mosquitoPosition.Y = frame.InicioAlto + 25;
        }

        //Barrera Hueco3
        if (mosquitoPosition.X >= frame.InicioAncho + 50 && mosquitoPosition.X <= frame.InicioAncho + 66 && mosquitoPosition.Y >= frame.InicioAlto + 35 && mosquitoPosition.Y <= frame.InicioAlto + 38)
        {
            mosquitoPosition.X = frame.InicioAncho + 65;
            mosquitoPosition.Y = frame.InicioAlto + 38;
        }

        //Barrera Hueco4
        if (mosquitoPosition.X >= frame.InicioAncho + 138 && mosquitoPosition.X <= frame.InicioAncho + 145 && mosquitoPosition.Y >= frame.InicioAlto + 30 && mosquitoPosition.Y <= frame.InicioAlto + 37)
        {
            mosquitoPosition.X = frame.InicioAncho + 128;
            mosquitoPosition.Y = frame.InicioAlto + 39;
        }
        Console.SetCursorPosition(mosquitoPosition.X, mosquitoPosition.Y);
        Console.Write("+");
        return mosquitoPosition;


    }

    public void DrawSpider(CoordModel positionPlayer, ConsoleKey Teclapa, String playerNumber)
    {
        if (playerNumber == "player1")
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            /*Console.SetCursorPosition(coord1.X, coord1.Y);
            Console.Write("/ /");*/


            //(Araña completa con caracteres)
            switch (Teclapa)
            {
                case ConsoleKey.UpArrow:

                    int yo = 0;
                    foreach (var arañaup in Spiders.UpSide)
                    {
                        Console.SetCursorPosition(positionPlayer.X, positionPlayer.Y + yo);
                        Console.WriteLine(arañaup);
                        // Console.WriteLine("position X ");
                        // Console.WriteLine(positionPlayer.X);
                        // Console.WriteLine("position Y ");
                        // Console.WriteLine(positionPlayer.Y);
                        yo++;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    int y1 = 0;
                    foreach (var arañadown in Spiders.DownSide)
                    {
                        Console.SetCursorPosition(positionPlayer.X, positionPlayer.Y + y1);

                        Console.WriteLine(arañadown);
                        y1++;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    int y2 = 0;
                    foreach (var arañaleft in Spiders.LeftSide)
                    {
                        Console.SetCursorPosition(positionPlayer.X, positionPlayer.Y + y2);

                        Console.WriteLine(arañaleft);
                        y2++;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    int y3 = 0;
                    foreach (var arañaright in Spiders.RightSide)
                    {
                        Console.SetCursorPosition(positionPlayer.X, positionPlayer.Y + y3);

                        Console.WriteLine(arañaright);
                        y3++;
                    }
                    break;
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.White;
            /*Console.SetCursorPosition(coord4.X, coord4.Y);
            Console.Write("| |");*/

            //(Araña completa caracteres)
            switch (Teclapa)
            {
                case ConsoleKey.W:

                    int yo = 0;
                    foreach (var arañaup in Spiders.UpSide)
                    {
                        Console.SetCursorPosition(positionPlayer.X, positionPlayer.Y + yo);

                        Console.WriteLine(arañaup);
                        yo++;
                    }
                    break;
                case ConsoleKey.S:
                    int y1 = 0;
                    foreach (var arañadown in Spiders.DownSide)
                    {
                        Console.SetCursorPosition(positionPlayer.X, positionPlayer.Y + y1);

                        Console.WriteLine(arañadown);
                        y1++;
                    }
                    break;
                case ConsoleKey.A:
                    int y2 = 0;
                    foreach (var arañaleft in Spiders.LeftSide)
                    {
                        Console.SetCursorPosition(positionPlayer.X, positionPlayer.Y + y2);

                        Console.WriteLine(arañaleft);
                        y2++;
                    }
                    break;
                case ConsoleKey.D:
                    int y3 = 0;
                    foreach (var arañaright in Spiders.RightSide)
                    {
                        Console.SetCursorPosition(positionPlayer.X, positionPlayer.Y + y3);

                        Console.WriteLine(arañaright);
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
        Console.SetCursorPosition(coord.X, coord.Y);
        // Console.Write("###");

        //(Borrado de araña con caracteres)
        Console.Write("############");
        Console.SetCursorPosition(coord.X, coord.Y + 1);
        Console.Write("############");
        Console.SetCursorPosition(coord.X, coord.Y + 2);
        Console.Write("############");
        Console.SetCursorPosition(coord.X, coord.Y + 3);
        Console.Write("############");
    }

    public CoordModel MoveSpider(ConsoleKey keyMovement, CoordModel spiderPosition, FrameModel frameDimension, FrameModel holesWeb, string whatSpider)
    {
        if (whatSpider == "player1")
        {
            //Coindiciones movimiento en y,x del mosquito con letras(opcion con switch)
            switch (keyMovement)
            {
                case ConsoleKey.UpArrow:
                    spiderPosition.Y = spiderPosition.Y - 1;
                    break;
                case ConsoleKey.DownArrow:
                    spiderPosition.Y = spiderPosition.Y + 1;
                    break;
                case ConsoleKey.LeftArrow:
                    spiderPosition.X = spiderPosition.X - 1;
                    break;
                case ConsoleKey.RightArrow:
                    spiderPosition.X = spiderPosition.X + 1;
                    break;
            }
            //Coindiciones limites del marco para el mosquito (Opcion if-else)
            if (spiderPosition.X <= frameDimension.InicioAncho)
            {
                spiderPosition.X = frameDimension.InicioAncho + 1;
            }
            else if (spiderPosition.X >= frameDimension.FinalAncho - 12)
            {
                spiderPosition.X = frameDimension.FinalAncho - 12;
            }
            if (spiderPosition.Y <= frameDimension.InicioAlto)
            {
                spiderPosition.Y = frameDimension.InicioAlto + 1;
            }
            else if (spiderPosition.Y >= frameDimension.FinalAlto - 4)
            {
                spiderPosition.Y = frameDimension.FinalAlto - 4;
            }

            //Barrera Hueco1

            if (spiderPosition.X <= frameDimension.InicioAncho + 7 && spiderPosition.Y <= frameDimension.InicioAlto + 6)
            {
                spiderPosition.X = spiderPosition.X + 1;
                spiderPosition.Y = spiderPosition.Y + 1;

                // coord1.X = frameDimension.InicioAncho + 10;
                // coord1.Y = frameDimension.InicioAlto + 7;
            }

            //Barrera Hueco2
            if (spiderPosition.X >= frameDimension.InicioAncho + 121 && spiderPosition.Y <= frameDimension.InicioAlto + 6)
            {
                spiderPosition.X = spiderPosition.X - 1;
                spiderPosition.Y = spiderPosition.Y + 1;

                // coord1.X = frameDimension.InicioAncho + 114;
                // coord1.Y = frameDimension.InicioAlto + 15;
            }

            //Barrera Hueco3
            if (spiderPosition.X <= frameDimension.InicioAncho + 22 && spiderPosition.Y >= frameDimension.InicioAlto + 31)
            {
                spiderPosition.X = spiderPosition.X + 1;
                spiderPosition.Y = spiderPosition.Y - 1;


                // coord1.X = frameDimension.InicioAncho + 55;
                // coord1.Y = frameDimension.InicioAlto + 34;
            }

            //Barrera Hueco4
            if (spiderPosition.X >= frameDimension.InicioAncho + 125 && spiderPosition.Y >= frameDimension.InicioAlto + 27)
            {
                spiderPosition.X = spiderPosition.X - 1;
                spiderPosition.Y = spiderPosition.Y - 1;
                // coord1.X = frameDimension.InicioAncho + 135;
                // coord1.Y = frameDimension.InicioAlto + 35;
            }

            return spiderPosition;
        }
        else
        {
            //Coindiciones movimiento en y,x del mosquito con letras(opcion con switch)
            switch (keyMovement)
            {
                case ConsoleKey.W:
                    spiderPosition.Y = spiderPosition.Y - 1;
                    break;
                case ConsoleKey.S:
                    spiderPosition.Y = spiderPosition.Y + 1;
                    break;
                case ConsoleKey.A:
                    spiderPosition.X = spiderPosition.X - 1;
                    break;
                case ConsoleKey.D:
                    spiderPosition.X = spiderPosition.X + 1;
                    break;
            }
            //Coindiciones limites del marco para el mosquito (Opcion if-else)
            if (spiderPosition.X <= frameDimension.InicioAncho)
            {
                spiderPosition.X = frameDimension.InicioAncho + 1;
            }
            else if (spiderPosition.X >= frameDimension.FinalAncho - 12)
            {
                spiderPosition.X = frameDimension.FinalAncho - 12;
            }
            if (spiderPosition.Y <= frameDimension.InicioAlto)
            {
                spiderPosition.Y = frameDimension.InicioAlto + 1;
            }
            else if (spiderPosition.Y >= frameDimension.FinalAlto - 4)
            {
                spiderPosition.Y = frameDimension.FinalAlto - 4;
            }


            //Barrera Hueco1

            if (spiderPosition.X <= frameDimension.InicioAncho + 7 && spiderPosition.Y <= frameDimension.InicioAlto + 6)
            {
                spiderPosition.X = spiderPosition.X + 1;
                spiderPosition.Y = spiderPosition.Y + 1;

                // coord1.X = frameDimension.InicioAncho + 10;
                // coord1.Y = frameDimension.InicioAlto + 7;
            }

            //Barrera Hueco2
            if (spiderPosition.X >= frameDimension.InicioAncho + 121 && spiderPosition.Y <= frameDimension.InicioAlto + 6)
            {
                spiderPosition.X = spiderPosition.X - 1;
                spiderPosition.Y = spiderPosition.Y + 1;

                // coord1.X = frameDimension.InicioAncho + 114;
                // coord1.Y = frameDimension.InicioAlto + 15;
            }

            //Barrera Hueco3
            if (spiderPosition.X <= frameDimension.InicioAncho + 22 && spiderPosition.Y >= frameDimension.InicioAlto + 31)
            {
                spiderPosition.X = spiderPosition.X + 1;
                spiderPosition.Y = spiderPosition.Y - 1;


                // coord1.X = frameDimension.InicioAncho + 55;
                // coord1.Y = frameDimension.InicioAlto + 34;
            }

            //Barrera Hueco4
            if (spiderPosition.X >= frameDimension.InicioAncho + 125 && spiderPosition.Y >= frameDimension.InicioAlto + 27)
            {
                spiderPosition.X = spiderPosition.X - 1;
                spiderPosition.Y = spiderPosition.Y - 1;
                // coord1.X = frameDimension.InicioAncho + 135;
                // coord1.Y = frameDimension.InicioAlto + 35;
            }

            return spiderPosition;
        }

    }

    public int ScoreOne(CoordModel coord, int score)
    {
        if (score <= 10)
        {
            Console.SetCursorPosition(coord.X, coord.Y);
            Console.Write("Araña 1 = " + score);
            score++;
        }
        else if (score == 10)
        {
            Console.SetCursorPosition(coord.X, coord.Y);
            Console.Write("GANO");
        }
        return score;
    }

    public int ScoreTwo(CoordModel scorePosition, int score)
    {
        if (score <= 10)
        {
            Console.SetCursorPosition(scorePosition.X + 130, scorePosition.Y);
            Console.Write("Araña 2 = " + score);
            score++;
        }
        else if (score == 10)
        {
            Console.SetCursorPosition(scorePosition.X + 15, scorePosition.Y + 2);
            Console.Write("GANO");
        }
        return score;
    }
}