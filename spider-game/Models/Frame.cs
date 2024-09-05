public struct FrameModel
{
    public int InicioAncho;
    public int InicioAlto;
    public int FinalAncho;
    public int FinalAlto;

    public FrameModel(int inicioAncho, int inicioAlto, int finalAncho, int finalAlto)
    {
        InicioAncho = inicioAncho;
        InicioAlto = inicioAlto;
        FinalAncho = finalAncho;
        FinalAlto = finalAlto;
    }
}

public struct CoordModel //Estructura de coordenadas movimiento mosquito
{
    public int X;
    public int Y;
    public CoordModel(int x, int y)
    {
        X = x;
        Y = y;
    }

}