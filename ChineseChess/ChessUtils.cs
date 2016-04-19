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
        public static AtackDirection ChessboardDirection = AtackDirection.BlackUpRedDown;

        public static string getMoveString(int gridX, int gridY, int previousGirdX, int previousGirdY)
        {
            string move = "";
            move += getConvertedX(previousGirdX) + getConvertedY(previousGirdY) + getConvertedX(gridX) + getConvertedY(gridY);
            return move;
        }
        public static char getConvertedX(int X)
        {
            switch (X)
            {
                case 0 :
                    return 'a';
                case 1:
                    return 'b';
                case 2:
                    return 'c';
                case 3:
                    return 'd';
                case 4:
                    return 'e';
                case 5:
                    return 'f';
                case 6:
                    return 'g';
                case 7:
                    return 'h';
                case 8:
                    return 'i';
                default:
                    return ' ';  
            }
        }
        public static char getConvertedY(int Y)
        {
            int convertedX = 9 - Y;
            return convertedX.ToString()[0];
        }

        public static char getTypeForUcci(int theType)
        {
            if (theType == 1)
            {
                //红方
                return 'w';
            }
            else if (theType == 0)
            {
                //黑方
                return 'b';
            }
            return ' ';
        }

    }
}
