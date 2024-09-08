
namespace FuncionesCiclos
{
    public class FrameModel
    {
        public int InicioAncho { get; set; }
        public int InicioAlto { get; set; }
        public int FinalAncho { get; set; }
        public int FinalAlto { get; set; }

        public FrameModel(int inicioAncho, int inicioAlto, int finalAncho, int finalAlto)
        {
            InicioAncho = inicioAncho;
            InicioAlto = inicioAlto;
            FinalAncho = finalAncho;
            FinalAlto = finalAlto;
        }
    }
}