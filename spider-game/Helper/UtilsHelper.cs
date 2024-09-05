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
}