public interface ISpiderGame
{
    public void WaitStart(int x, int y, FrameModel dimensiones);
    public void DrawWeb(FrameModel frameDimensions, FrameModel holesWeb);
    public CoordModel DrawMosquito(CoordModel coord2, FrameModel marco);
    public void DrawSpider(CoordModel coord1, ConsoleKey Teclapa, String playerNumber);
    public ConsoleKey WaitKey();
    public void DeleteSpider(CoordModel coord);
    public CoordModel MoveSpider(ConsoleKey teclaMovimiento, CoordModel coord1, FrameModel frameDimension, FrameModel holesWeb, string whatSpider);
    public int ScoreOne(CoordModel coord, int score);
    public int ScoreTwo(CoordModel coord, int score);
}