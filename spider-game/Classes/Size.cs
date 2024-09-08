using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spider_game.Classes
{
    internal class Size
    {
        public int StartWeight { get; set; }
        public int StartHeigh { get; set; }
        public int EndWeight { get; set; }

        public int EndHeigh { get; set; }
        public Size(int startWeight, int startHeigh, int endWeight, int endHeigh)
        {
            StartHeigh = startHeigh;
            StartWeight = startWeight;
            EndHeigh = endHeigh;
            EndWeight = endWeight;
        }
    }
}
