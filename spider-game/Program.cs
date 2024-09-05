namespace FuncionesCiclos
{
    internal class Program
    {

        static void Main(string[] args)
        {
            UtilsHelper utilsHelper = new UtilsHelper();
            SpiderGame newSpiderGame = new SpiderGame();
            //Punteros de las estructuras 
            // Frame frameDimension = new Frame(0, 0, 147, 40);
            FrameModel frameDimension = new FrameModel(0, 0, 147, 40);

            FrameModel holesCoord = new FrameModel(0, 0, 147, 40);
            // Frame holesCoord = new Frame(0, 0, 147, 40);

            CoordModel positionPlayer1 = new CoordModel(40, 20);
            // Coord coord1 = new Coord(40, 20);
            CoordModel rangeFrame = new CoordModel(147, 40);
            // Coord coord2 = new Coord(147, 40);
            CoordModel positionPlayer2 = new CoordModel(75, 5);
            // Coord coord4 = new Coord(75, 5);
            CoordModel scorePosition = new CoordModel(3, 41);
            // Coord coord = new Coord(1, 1);
            // Coord coord3 = new Coord(90, 20);

            //Visibilidad del cursor
            Console.CursorVisible = false;

            newSpiderGame.WaitStart(65, 20, frameDimension);
            // EsperarInicio(65, 20, frameDimension);
            newSpiderGame.DrawWeb(frameDimension, holesCoord);
            // PintarTelaraña(frameDimension, holesCoord);

            //Inicializacion Tecla fantasma
            ConsoleKey Tecla = ConsoleKey.W & ConsoleKey.UpArrow;
            CoordModel mosquito = newSpiderGame.DrawMosquito(rangeFrame, frameDimension);
            // coord2 = PintarMosquito(coord2, frameDimension);
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

                newSpiderGame.DrawSpider(positionPlayer1, Tecla, "player1");
                // PintarAraña1(coord1, Tecla, "player1");

                newSpiderGame.DrawSpider(positionPlayer2, Tecla, "player2");
                // PintarAraña1(coord4, Tecla, "player2");
                Tecla = newSpiderGame.WaitKey();
                // Tecla = Esperartecla();

                if (ConsoleKey.W == Tecla || ConsoleKey.A == Tecla || ConsoleKey.S == Tecla || ConsoleKey.D == Tecla)
                {
                    newSpiderGame.DeleteSpider(positionPlayer2);
                    positionPlayer2 = newSpiderGame.MoveSpider(Tecla, positionPlayer2, frameDimension, holesCoord, "player2");
                    // BorrarAraña1(coord4);
                }
                else
                {
                    newSpiderGame.DeleteSpider(positionPlayer1);
                    positionPlayer1 = newSpiderGame.MoveSpider(Tecla, positionPlayer1, frameDimension, holesCoord, "player1");
                    // BorrarAraña1(coord1);
                }

                // positionPlayer1 = newSpiderGame.MoveSpider(Tecla, positionPlayer1, frameDimension, holesCoord, "player1");
                // coord1 = MoverAraña1(Tecla, coord1, frameDimension, holesCoord, "player1");
                // positionPlayer2 = newSpiderGame.MoveSpider(Tecla, positionPlayer2, frameDimension, holesCoord, "player2");
                // coord4 = MoverAraña1(Tecla, coord4, frameDimension, holesCoord, "player2");

                if (utilsHelper.MosquitoEaten(positionPlayer1, mosquito))
                {
                    score1 = newSpiderGame.ScoreOne(scorePosition, score1);
                    // newSpiderGame.ScoreOne(scorePosition);
                    // Puntaje1(coord);
                }
                if (utilsHelper.MosquitoEaten(positionPlayer2, mosquito))
                {
                    score2 = newSpiderGame.ScoreTwo(scorePosition, score2);
                    // newSpiderGame.ScoreTwo(scorePosition);
                    // Puntaje2(coord);
                }

            } while (Tecla != ConsoleKey.Escape);

        }
        // static void Puntaje2(Coord coord)
        // {
        //     int i = 1;
        //     if (i <= 10)
        //     {
        //         Console.SetCursorPosition(coord.X + 15, coord.Y);
        //         Console.Write("Araña 2 = " + i);
        //         i++;
        //     }
        //     else if (i == 10)
        //     {
        //         Console.SetCursorPosition(coord.X + 15, coord.Y);
        //         Console.Write("GANO");
        //     }
        // }
        // static void Puntaje1(Coord coord)
        // {
        //     int i = 1;
        //     if (i <= 10)
        //     {
        //         Console.SetCursorPosition(coord.X, coord.Y);
        //         Console.Write("Araña 1 = " + i);
        //         i++;
        //     }
        //     else if (i == 10)
        //     {
        //         Console.SetCursorPosition(coord.X, coord.Y);
        //         Console.Write("GANO");
        //     }
        // }

        // static void PintarTelaraña(Frame frameDimensions, Frame holesWeb)
        // {
        //     Console.ForegroundColor = ConsoleColor.Magenta;
        //     //Parte superior e inferior del marco
        //     for (int X = frameDimensions.InicioAncho; X < frameDimensions.FinalAncho + frameDimensions.InicioAncho; X++)
        //     {

        //         Console.SetCursorPosition(X, frameDimensions.InicioAlto);
        //         Console.Write("=");
        //         Console.SetCursorPosition(X, frameDimensions.InicioAlto + frameDimensions.FinalAlto);
        //         Console.Write("=");
        //     }

        //     //Parte lateral izquierdo y derecho del marco
        //     for (int Y = frameDimensions.InicioAlto; Y < frameDimensions.FinalAlto + frameDimensions.InicioAlto; Y++)
        //     {
        //         Console.SetCursorPosition(frameDimensions.InicioAncho, Y);
        //         Console.Write("║");
        //         Console.SetCursorPosition(frameDimensions.InicioAncho + frameDimensions.FinalAncho, Y);
        //         Console.Write("║");
        //     }

        //     //Relleno del marco
        //     Console.ForegroundColor = ConsoleColor.Cyan;
        //     for (int Y = frameDimensions.InicioAlto + 1; Y < frameDimensions.FinalAlto + frameDimensions.InicioAlto; Y++)
        //     {
        //         for (int X = frameDimensions.InicioAncho + 1; X < frameDimensions.FinalAncho + frameDimensions.InicioAncho; X++)
        //         {
        //             Console.SetCursorPosition(X, Y);
        //             Console.WriteLine("#");
        //         }
        //     }

        //     //HUECOS DE LA TELARAÑA
        //     Console.ForegroundColor = ConsoleColor.Green;

        //     //Hueco 1
        //     for (int X = holesWeb.InicioAncho + 2; X < holesWeb.FinalAncho - 139 + holesWeb.InicioAncho; X++)
        //     {
        //         for (int Y = holesWeb.InicioAlto + 2; Y < holesWeb.FinalAlto - 33 + holesWeb.InicioAlto; Y++)
        //         {
        //             Console.SetCursorPosition(X, Y);
        //             Console.WriteLine("°");
        //         }
        //     }

        //     //Hueco 2
        //     for (int X = holesWeb.InicioAncho + 114; X < holesWeb.FinalAncho - 20 + holesWeb.InicioAncho; X++)
        //     {
        //         for (int Y = holesWeb.InicioAlto + 11; Y < holesWeb.FinalAlto - 25 + holesWeb.InicioAlto; Y++)
        //         {
        //             Console.SetCursorPosition(X, Y);
        //             Console.WriteLine("°");
        //         }
        //     }

        //     //Hueco 3
        //     for (int X = holesWeb.InicioAncho + 50; X < holesWeb.FinalAncho - 80 + holesWeb.InicioAncho; X++)
        //     {
        //         for (int Y = holesWeb.InicioAlto + 35; Y < holesWeb.FinalAlto - 1 + holesWeb.InicioAlto; Y++)
        //         {
        //             Console.SetCursorPosition(X, Y);
        //             Console.WriteLine("°");
        //         }
        //     }

        //     //Hueco 4
        //     for (int X = holesWeb.InicioAncho + 138; X < holesWeb.FinalAncho - 2 + holesWeb.InicioAncho; X++)
        //     {
        //         for (int Y = holesWeb.InicioAlto + 30; Y < holesWeb.FinalAlto - 2 + holesWeb.InicioAlto; Y++)
        //         {
        //             Console.SetCursorPosition(X, Y);
        //             Console.WriteLine("°");
        //         }
        //     }
        // }
        // static void EsperarInicio(int x, int y, Frame dimensiones)
        // {
        //     Console.ForegroundColor = ConsoleColor.Magenta;
        //     //Parte superior e inferior del marco
        //     for (int X = dimensiones.InicioAncho; X < dimensiones.FinalAncho + dimensiones.InicioAncho; X++)
        //     {

        //         Console.SetCursorPosition(X, dimensiones.InicioAlto);
        //         Console.Write("=");
        //         Console.SetCursorPosition(X, dimensiones.InicioAlto + dimensiones.FinalAlto);
        //         Console.Write("=");
        //     }

        //     //Parte lateral izquierdo y derecho del marco
        //     for (int Y = dimensiones.InicioAlto; Y < dimensiones.FinalAlto + dimensiones.InicioAlto; Y++)
        //     {
        //         Console.SetCursorPosition(dimensiones.InicioAncho, Y);
        //         Console.Write("║");
        //         Console.SetCursorPosition(dimensiones.InicioAncho + dimensiones.FinalAncho, Y);
        //         Console.Write("║");
        //     }
        //     //Caracteres del reloj
        //     string Chars = "|/-\\";
        //     int i = 0;

        //     //Ciclo activamiento/desactivamiento reloj
        //     while (!Console.KeyAvailable)
        //     {
        //         Console.SetCursorPosition(x, y);
        //         Console.WriteLine("Las Arañas cazadoras");
        //         Console.SetCursorPosition(x - 7, y + 1);
        //         Console.WriteLine("¡PULSA CUALQUIER TECLA PARA JUGAR!");
        //         Console.SetCursorPosition(x + 8, y + 2);
        //         Console.Write(Chars[i]);
        //         i++;
        //         if (i > 3) i = 0;
        //         Thread.Sleep(250);
        //     }

        //     //esperar tecla 
        //     Console.ReadKey(true);

        //     //Borrar reloj
        //     Console.SetCursorPosition(x, y);
        //     Console.Write(" ");
        // }
        // static Coord PintarMosquito(Coord coord2, Frame marco)
        // {
        //     Console.ForegroundColor = ConsoleColor.Red;
        //     var random = new Random();
        //     int valuex = random.Next(coord2.X);
        //     int valuey = random.Next(coord2.Y);
        //     coord2.X = valuex;
        //     coord2.Y = valuey;


        //     if (valuex <= marco.InicioAncho)
        //     {
        //         valuex = marco.InicioAncho + 10;
        //     }
        //     else if (valuey >= marco.FinalAncho)
        //     {
        //         valuey = marco.FinalAncho - 10;
        //     }
        //     if (valuey <= marco.InicioAlto)
        //     {
        //         valuey = marco.InicioAlto + 10;
        //     }
        //     else if (valuey >= marco.FinalAlto)
        //     {
        //         valuey = marco.FinalAlto - 10;
        //     }

        //     //Barrera Hueco1

        //     if (valuex <= marco.InicioAncho + 7 && valuey <= marco.InicioAlto + 6)
        //     {
        //         valuex = marco.InicioAncho + 20;
        //         valuey = marco.InicioAlto + 15;
        //     }

        //     //Barrera Hueco2
        //     if (valuex >= marco.InicioAncho + 113 && valuex <= marco.InicioAncho + 126 && valuey >= marco.InicioAlto + 11 && valuey <= marco.InicioAlto + 14)
        //     {
        //         valuex = marco.InicioAncho + 124;
        //         valuey = marco.InicioAlto + 25;
        //     }

        //     //Barrera Hueco3
        //     if (valuex >= marco.InicioAncho + 50 && valuex <= marco.InicioAncho + 66 && valuey >= marco.InicioAlto + 35 && valuey <= marco.InicioAlto + 38)
        //     {
        //         valuex = marco.InicioAncho + 65;
        //         valuey = marco.InicioAlto + 38;
        //     }

        //     //Barrera Hueco4
        //     if (valuex >= marco.InicioAncho + 138 && valuex <= marco.InicioAncho + 145 && valuey >= marco.InicioAlto + 30 && valuey <= marco.InicioAlto + 37)
        //     {
        //         valuex = marco.InicioAncho + 128;
        //         valuey = marco.InicioAlto + 39;
        //     }
        //     Console.SetCursorPosition(valuex, valuey);
        //     Console.Write("+");
        //     return coord2;


        // }

        // static void PintarAraña1(Coord coord1, ConsoleKey Teclapa, String playerNumber)
        // {

        //     Console.ForegroundColor = ConsoleColor.Yellow;
        //     /*Console.SetCursorPosition(coord1.X, coord1.Y);
        //     Console.Write("/ /");*/


        //     //(Araña completa con caracteres)
        //     switch (Teclapa)
        //     {
        //         case ConsoleKey.UpArrow:

        //             int yo = 0;
        //             foreach (var arañaup in Arañaarriba)
        //             {
        //                 Console.SetCursorPosition(coord1.X, coord1.Y + yo);

        //                 Console.WriteLine(arañaup);
        //                 yo++;
        //             }
        //             break;
        //         case ConsoleKey.DownArrow:
        //             int y1 = 0;
        //             foreach (var arañadown in Arañaabajo)
        //             {
        //                 Console.SetCursorPosition(coord1.X, coord1.Y + y1);

        //                 Console.WriteLine(arañadown);
        //                 y1++;
        //             }
        //             break;
        //         case ConsoleKey.LeftArrow:
        //             int y2 = 0;
        //             foreach (var arañaleft in Arañaizqui)
        //             {
        //                 Console.SetCursorPosition(coord1.X, coord1.Y + y2);

        //                 Console.WriteLine(arañaleft);
        //                 y2++;
        //             }
        //             break;
        //         case ConsoleKey.RightArrow:
        //             int y3 = 0;
        //             foreach (var arañaright in Arañadere)
        //             {
        //                 Console.SetCursorPosition(coord1.X, coord1.Y + y3);

        //                 Console.WriteLine(arañaright);
        //                 y3++;
        //             }
        //             break;
        //     }


        // }
        // static void PintarAraña2(Coord coord4, ConsoleKey Teclapa)
        // {
        //     Console.ForegroundColor = ConsoleColor.White;
        //     /*Console.SetCursorPosition(coord4.X, coord4.Y);
        //     Console.Write("| |");*/

        //     //(Araña completa caracteres)
        //     switch (Teclapa)
        //     {
        //         case ConsoleKey.W:

        //             int yo = 0;
        //             foreach (var arañaup in Arañaarriba)
        //             {
        //                 Console.SetCursorPosition(coord4.X, coord4.Y + yo);

        //                 Console.WriteLine(arañaup);
        //                 yo++;
        //             }
        //             break;
        //         case ConsoleKey.S:
        //             int y1 = 0;
        //             foreach (var arañadown in Arañaabajo)
        //             {
        //                 Console.SetCursorPosition(coord4.X, coord4.Y + y1);

        //                 Console.WriteLine(arañadown);
        //                 y1++;
        //             }
        //             break;
        //         case ConsoleKey.A:
        //             int y2 = 0;
        //             foreach (var arañaleft in Arañaizqui)
        //             {
        //                 Console.SetCursorPosition(coord4.X, coord4.Y + y2);

        //                 Console.WriteLine(arañaleft);
        //                 y2++;
        //             }
        //             break;
        //         case ConsoleKey.D:
        //             int y3 = 0;
        //             foreach (var arañaright in Arañadere)
        //             {
        //                 Console.SetCursorPosition(coord4.X, coord4.Y + y3);

        //                 Console.WriteLine(arañaright);
        //                 y3++;
        //             }
        //             break;

        //     }

        // }
        // static void Borrarmosquito(Coord coord)
        // {
        //     Console.SetCursorPosition(coord.X, coord.Y);
        //     Console.WriteLine(" ");
        // }
        // static ConsoleKey Esperartecla()
        // {
        //     ConsoleKeyInfo tecla_MOVIMIENTO = Console.ReadKey(true);
        //     return tecla_MOVIMIENTO.Key;
        // }
        // static void BorrarAraña1(Coord coord)
        // {
        //     // Console.ForegroundColor = ConsoleColor.Cyan;
        //     // Console.SetCursorPosition(coord.X, coord.Y);
        //     // Console.Write("###");

        //     //(Borrado de araña con caracteres)
        //     Console.Write("###############");
        //     Console.SetCursorPosition(coord.X, coord.Y + 1);
        //     Console.Write("###############");
        //     Console.SetCursorPosition(coord.X, coord.Y + 2);
        //     Console.Write("###############");
        //     Console.SetCursorPosition(coord.X, coord.Y + 3);
        //     Console.Write("###############");
        // }
        // static Coord MoverAraña1(ConsoleKey teclaMovimiento, Coord coord1, Frame frameDimension, Frame holesWeb, String whatSpider)
        // {
        //     if (whatSpider == "player1")
        //     {
        //         //Coindiciones movimiento en y,x del mosquito con letras(opcion con switch)
        //         switch (teclaMovimiento)
        //         {
        //             case ConsoleKey.UpArrow: coord1.Y--; break;
        //             case ConsoleKey.DownArrow: coord1.Y++; break;
        //             case ConsoleKey.LeftArrow: coord1.X--; break;
        //             case ConsoleKey.RightArrow: coord1.X++; break;
        //         }
        //         //Coindiciones limites del marco para el mosquito (Opcion if-else)
        //         if (coord1.X <= frameDimension.InicioAncho)
        //         {
        //             coord1.X = frameDimension.InicioAncho + 1;
        //         }
        //         else if (coord1.X >= frameDimension.FinalAncho)
        //         {
        //             coord1.X = frameDimension.FinalAncho - 1;
        //         }
        //         if (coord1.Y <= frameDimension.InicioAlto)
        //         {
        //             coord1.Y = frameDimension.InicioAlto + 1;
        //         }
        //         else if (coord1.Y >= frameDimension.FinalAlto)
        //         {
        //             coord1.Y = frameDimension.FinalAlto - 1;
        //         }

        //         //Barrera Hueco1

        //         if (coord1.X <= frameDimension.InicioAncho + 7 && coord1.Y <= frameDimension.InicioAlto + 6)
        //         {
        //             coord1.X = frameDimension.InicioAncho + 10;
        //             coord1.Y = frameDimension.InicioAlto + 7;
        //         }

        //         //Barrera Hueco2
        //         if (coord1.X >= frameDimension.InicioAncho + 111 && coord1.X <= frameDimension.InicioAncho + 126 && coord1.Y >= frameDimension.InicioAlto + 11 && coord1.Y <= frameDimension.InicioAlto + 14)
        //         {
        //             coord1.X = frameDimension.InicioAncho + 114;
        //             coord1.Y = frameDimension.InicioAlto + 15;
        //         }

        //         //Barrera Hueco3
        //         if (coord1.X >= frameDimension.InicioAncho + 48 && coord1.X <= frameDimension.InicioAncho + 66 && coord1.Y >= frameDimension.InicioAlto + 35 && coord1.Y <= frameDimension.InicioAlto + 38)
        //         {
        //             coord1.X = frameDimension.InicioAncho + 55;
        //             coord1.Y = frameDimension.InicioAlto + 34;
        //         }

        //         //Barrera Hueco4
        //         if (coord1.X >= frameDimension.InicioAncho + 136 && coord1.X <= frameDimension.InicioAncho + 145 && coord1.Y >= frameDimension.InicioAlto + 30 && coord1.Y <= frameDimension.InicioAlto + 37)
        //         {
        //             coord1.X = frameDimension.InicioAncho + 135;
        //             coord1.Y = frameDimension.InicioAlto + 35;
        //         }

        //         return coord1;
        //     }
        //     else
        //     {
        //         //Coindiciones movimiento en y,x del mosquito con letras(opcion con switch)
        //         switch (teclaMovimiento)
        //         {
        //             case ConsoleKey.W: coord1.Y--; break;
        //             case ConsoleKey.S: coord1.Y++; break;
        //             case ConsoleKey.A: coord1.X--; break;
        //             case ConsoleKey.D: coord1.X++; break;
        //         }
        //         //Coindiciones limites del marco para el mosquito (Opcion if-else)
        //         if (coord1.X <= frameDimension.InicioAncho)
        //         {
        //             coord1.X = frameDimension.InicioAncho + 1;
        //         }
        //         else if (coord1.X >= frameDimension.FinalAncho)
        //         {
        //             coord1.X = frameDimension.FinalAncho - 1;
        //         }
        //         if (coord1.Y <= frameDimension.InicioAlto)
        //         {
        //             coord1.Y = frameDimension.InicioAlto + 1;
        //         }
        //         else if (coord1.Y >= frameDimension.FinalAlto)
        //         {
        //             coord1.Y = frameDimension.FinalAlto - 1;
        //         }

        //         //Barrera Hueco1

        //         if (coord1.X <= frameDimension.InicioAncho + 7 && coord1.Y <= frameDimension.InicioAlto + 6)
        //         {
        //             coord1.X = frameDimension.InicioAncho + 10;
        //             coord1.Y = frameDimension.InicioAlto + 7;
        //         }

        //         //Barrera Hueco2
        //         if (coord1.X >= frameDimension.InicioAncho + 111 && coord1.X <= frameDimension.InicioAncho + 126 && coord1.Y >= frameDimension.InicioAlto + 11 && coord1.Y <= frameDimension.InicioAlto + 14)
        //         {
        //             coord1.X = frameDimension.InicioAncho + 114;
        //             coord1.Y = frameDimension.InicioAlto + 15;
        //         }

        //         //Barrera Hueco3
        //         if (coord1.X >= frameDimension.InicioAncho + 48 && coord1.X <= frameDimension.InicioAncho + 66 && coord1.Y >= frameDimension.InicioAlto + 35 && coord1.Y <= frameDimension.InicioAlto + 38)
        //         {
        //             coord1.X = frameDimension.InicioAncho + 55;
        //             coord1.Y = frameDimension.InicioAlto + 34;
        //         }

        //         //Barrera Hueco4
        //         if (coord1.X >= frameDimension.InicioAncho + 136 && coord1.X <= frameDimension.InicioAncho + 145 && coord1.Y >= frameDimension.InicioAlto + 30 && coord1.Y <= frameDimension.InicioAlto + 37)
        //         {
        //             coord1.X = frameDimension.InicioAncho + 135;
        //             coord1.Y = frameDimension.InicioAlto + 35;
        //         }

        //         return coord1;
        //     }

        // }
        // static Coord MoverAraña2(ConsoleKey teclaMovimiento, Coord coord1, Frame frameDimension, Frame holesWeb)
        // {
        //     //Coindiciones movimiento en y,x del mosquito con letras(opcion con switch)
        //     switch (teclaMovimiento)
        //     {
        //         case ConsoleKey.W: coord1.Y--; break;
        //         case ConsoleKey.S: coord1.Y++; break;
        //         case ConsoleKey.A: coord1.X--; break;
        //         case ConsoleKey.D: coord1.X++; break;
        //     }
        //     //Coindiciones limites del marco para el mosquito (Opcion if-else)
        //     if (coord1.X <= frameDimension.InicioAncho)
        //     {
        //         coord1.X = frameDimension.InicioAncho + 1;
        //     }
        //     else if (coord1.X >= frameDimension.FinalAncho)
        //     {
        //         coord1.X = frameDimension.FinalAncho - 1;
        //     }
        //     if (coord1.Y <= frameDimension.InicioAlto)
        //     {
        //         coord1.Y = frameDimension.InicioAlto + 1;
        //     }
        //     else if (coord1.Y >= frameDimension.FinalAlto)
        //     {
        //         coord1.Y = frameDimension.FinalAlto - 1;
        //     }

        //     //Barrera Hueco1

        //     if (coord1.X <= frameDimension.InicioAncho + 7 && coord1.Y <= frameDimension.InicioAlto + 6)
        //     {
        //         coord1.X = frameDimension.InicioAncho + 10;
        //         coord1.Y = frameDimension.InicioAlto + 7;
        //     }

        //     //Barrera Hueco2
        //     if (coord1.X >= frameDimension.InicioAncho + 111 && coord1.X <= frameDimension.InicioAncho + 126 && coord1.Y >= frameDimension.InicioAlto + 11 && coord1.Y <= frameDimension.InicioAlto + 14)
        //     {
        //         coord1.X = frameDimension.InicioAncho + 114;
        //         coord1.Y = frameDimension.InicioAlto + 15;
        //     }

        //     //Barrera Hueco3
        //     if (coord1.X >= frameDimension.InicioAncho + 48 && coord1.X <= frameDimension.InicioAncho + 66 && coord1.Y >= frameDimension.InicioAlto + 35 && coord1.Y <= frameDimension.InicioAlto + 38)
        //     {
        //         coord1.X = frameDimension.InicioAncho + 55;
        //         coord1.Y = frameDimension.InicioAlto + 34;
        //     }

        //     //Barrera Hueco4
        //     if (coord1.X >= frameDimension.InicioAncho + 136 && coord1.X <= frameDimension.InicioAncho + 145 && coord1.Y >= frameDimension.InicioAlto + 30 && coord1.Y <= frameDimension.InicioAlto + 37)
        //     {
        //         coord1.X = frameDimension.InicioAncho + 135;
        //         coord1.Y = frameDimension.InicioAlto + 35;
        //     }

        //     return coord1;
        // }
        // struct Frame
        // {
        //     public int InicioAncho;
        //     public int InicioAlto;
        //     public int FinalAncho;
        //     public int FinalAlto;

        //     public Frame(int inicioAncho, int inicioAlto, int finalAncho, int finalAlto)
        //     {
        //         InicioAncho = inicioAncho;
        //         InicioAlto = inicioAlto;
        //         FinalAncho = finalAncho;
        //         FinalAlto = finalAlto;
        //     }
        // }
        // struct Huecos
        // {
        //     public int InicioAncho;
        //     public int InicioAlto;
        //     public int FinalAncho;
        //     public int FinalAlto;

        //     public Huecos(int inicioAncho, int inicioAlto, int finalAncho, int finalAlto)
        //     {
        //         InicioAncho = inicioAncho;
        //         InicioAlto = inicioAlto;
        //         FinalAncho = finalAncho;
        //         FinalAlto = finalAlto;
        //     }
        // }
        // struct Coord //Estructura de coordenadas movimiento mosquito
        // {
        //     public int X;
        //     public int Y;
        //     public Coord(int x, int y)
        //     {
        //         X = x;
        //         Y = y;
        //     }

        // }

        // //Arreglos para las figuras de las arañas
        // static string[] Arañaarriba = {
        //     @"  ||    ||",
        //     @"   \\()// ",
        //     @"  //(__)\\",
        //     @" ||     ||",
        // };
        // static string[] Arañaabajo =
        // {
        //     @" ||     ||",
        //     @" \\(---)//",
        //     @"   //()\\  ",
        //     @"  ||    ||  ",
        // };
        // static string[] Arañaizqui =
        // {
        //     @"__           __",
        //     @"  ==  (| .|)=  ",
        //     @"   0 o(| .|)   ",
        //     @"__==  (| .|)=__",
        // };
        // static string[] Arañadere =
        // {
        //     @"          __",
        //     @"=(|.|)  ==  ",
        //     @"  (|.|)o 0  ",
        //     @"=(|.|   ==__",
        // };
    }
}
