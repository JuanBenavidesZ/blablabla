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
    public bool Araña1Eaten(CoordModel positionPlayer1, CoordModel positionPlayer2)
    {
        return positionPlayer1.X >= positionPlayer2.X && positionPlayer1.X >= positionPlayer2.X+11 &&
                positionPlayer1.Y <= positionPlayer2.Y +3 && positionPlayer1.Y >= positionPlayer2.Y;
    }
}