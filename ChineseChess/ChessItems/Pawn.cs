using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChineseChess.ChessItems
{
    /// <summary>
    /// 兵
    /// </summary>
    public class Pawn : BaseChess
    {
        public Pawn()
        {
            _pieceType = ChessPieceType.PAWN;
        }
        public override bool obeyTheLimit(int gridX, int gridY)
        {
            bool isObey = false;
            if (!base.obeyTheLimit(gridX, gridY))
            {
                return false;
            }
            if (isInOwnSide(gridX, gridY))
            {
                if (gridY - GridY == 1 && GridX == gridX)
                {
                    return true;
                }
            }
            else
            {
                if ((gridY - GridY == 1 && GridX == gridX) ||
                        (Math.Abs(GridX - gridX) == 1 && GridY == gridY))
                {
                    return true;
                }
            }

            return isObey;

        }
    }
}
