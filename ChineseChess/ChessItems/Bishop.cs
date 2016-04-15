using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChineseChess.ChessItems
{
    /// <summary>
    ///象 
    /// </summary>
    public class Bishop : BaseChess
    {
        public override bool obeyTheLimit(int gridX, int gridY)
        {
            if (!base.obeyTheLimit(gridX, gridY))
            {
                return false;
            }
            if (Type == ChessType.Red && gridY <= 4
                && Math.Abs(gridX - GridX) == 2 && Math.Abs(gridY - GridY) == 2
                && !hasChessOnPoint((gridX + GridX) / 2, (gridY + GridY) / 2))
            {
                return true;
            }
            else if (Type == ChessType.Black && gridY > 5
                && Math.Abs(gridX - GridX) == 2 && Math.Abs(gridY - GridY) == 2
                && !hasChessOnPoint((gridX + GridX) / 2, (gridY + GridY) / 2))
            {
                return true;
            }
            return false;

        }
    }
}
