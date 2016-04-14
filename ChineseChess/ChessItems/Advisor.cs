using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChineseChess.ChessItems
{
    /// <summary>
    /// 士
    /// </summary>
    public class Advisor : BaseChess
    {
        public override bool obeyTheLimit(int gridX, int gridY)
        {
            if (!base.obeyTheLimit(gridX, gridY))
            {
                return false;
            }
            if(Math.Abs(gridX-GridX)==1 && Math.Abs(gridY-GridY)==1 
                && gridY >= 3 && gridY <= 5)
            {
                if (gridX <=2 && Type == ChessType.Red)
                {
                    return true;
                } 
                else if(gridX>=7 && Type== ChessType.Black)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            return false;

        }
    }
}
