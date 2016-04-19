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
        public Advisor()
        {
            _pieceType = ChessPieceType.ADVISOR;
        }
        public override bool obeyTheLimit(int gridX, int gridY)
        {
            if (!base.obeyTheLimit(gridX, gridY))
            {
                return false;
            }
            if (isInSquareBox(gridX, gridY))
            {
                if (Math.Abs(gridX - GridX) == 1 && Math.Abs(gridY - GridY) == 1)
                {
                    return true;
                }
            }
            
            return false;

        }
    }
}
