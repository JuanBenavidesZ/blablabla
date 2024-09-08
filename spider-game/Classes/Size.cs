using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spider_game.Classes
{
    internal class Size
    {
        public int InicioAncho { get; set; }
        public int InicioAlto { get; set; }
        public int FinalAncho { get; set; }

        public int FinalAlto { get; set; }
        public Size(int inicioAncho, int inicioAlto, int finalAncho, int finalAlto)
        {
            InicioAlto = inicioAlto;
            InicioAncho = inicioAncho;
            FinalAlto = finalAlto;
            FinalAncho = finalAncho;
        }
    }
}
