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

}