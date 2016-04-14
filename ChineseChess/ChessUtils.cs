using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChineseChess.ChessItems;
using System.Windows.Forms;

namespace ChineseChess
{
    public class ChessUtils
    {
        public static void getMinMax(int val1, int val2, out int min, out int max)
        {
            if (val1 < val2)
            {
                min = val1;
                max = val2;
            }
            else
            {
                min = val2;
                max = val1;
            }
        }

       
    }
}
