public interface ISpiderGame
{
    public void WaitStart(int x, int y, FrameModel dimensiones);
    public void DrawWeb(FrameModel frameDimensions, FrameModel holesWeb);
    public CoordModel DrawMosquito(CoordModel rangePosition, FrameModel frameSpider, FrameModel frameSpider2);
    public void DrawSpider(CoordModel coord1, ConsoleKey Teclapa, String playerNumber);
    public ConsoleKey WaitKey();
    public void DeleteSpider(CoordModel coord);
    public CoordModel MoveSpider(ConsoleKey teclaMovimiento, CoordModel coord1, CoordModel positionSpider2, FrameModel frameDimension, FrameModel holesWeb, string whatSpider);
    public int ScoreOne(int score, bool operatorScore);
    public int ScoreTwo(int score, bool operatorScore);
}