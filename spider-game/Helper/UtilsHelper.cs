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

    public CoordModel Spider1Eaten(CoordModel positionPlayer1, CoordModel positionPlayer2, FrameModel rangeSpider)
    {
        if (rangeSpider.FinalAlto == positionPlayer2.Y && rangeSpider.FinalAlto == positionPlayer2.X)
        {
            // arriba
            positionPlayer1.X--;
            positionPlayer1.Y--;
        }
        if (rangeSpider.FinalAncho == positionPlayer2.X && rangeSpider.FinalAncho == positionPlayer2.Y)
        {
            // izquierda
            positionPlayer1.X--;
            positionPlayer1.Y--;

        }
        if (rangeSpider.InicioAncho == positionPlayer2.X + 12 && (rangeSpider.InicioAlto >= positionPlayer2.Y && rangeSpider.InicioAlto <= positionPlayer2.Y + 3
            || rangeSpider.FinalAlto >= positionPlayer2.Y && rangeSpider.FinalAlto <= positionPlayer2.Y + 3))
        {
            // derecha
            positionPlayer1.X++;
            positionPlayer1.Y++;
        }
        if (rangeSpider.InicioAlto == positionPlayer2.X + 3 && rangeSpider.InicioAncho == positionPlayer2.X + 3)
        {
            // abajo
            positionPlayer1.X++;
            positionPlayer1.Y++;
        }

        return positionPlayer1;
    }

}