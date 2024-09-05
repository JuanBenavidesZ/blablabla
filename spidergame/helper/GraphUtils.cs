using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_gibby.helper
{
    internal class GraphUtils
    {
        public static void PrintXY(int x,int y, string Message)
        {
            Console.SetCursorPosition(x,y);
            Console.Write(Message);
        }
    }
}
