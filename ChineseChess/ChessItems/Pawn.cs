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
            if (Type == ChessType.Red)
            {
                if (GridY <= 4)
                {
                    if (gridY - GridY == 1 && GridX == gridX)
                    {
                        isObey = true;
                    }
                }
                else
                {
                    if ((gridY - GridY == 1 && GridX == gridX) ||
                        (Math.Abs(GridX - gridX) == 1 && GridY == gridY))
                    {
                        isObey = true;
                    }
                }
            }
            else
            {
                if (GridY >= 5)
                {
                    if (GridY - gridY == 1 && GridX == gridX)
                    {
                        isObey = true;
                    }
                }
                else
                {
                    if ((GridY - gridY == 1 && GridX == gridX) ||
                        (Math.Abs(GridX - gridX) == 1 && GridY == gridX))
                    {
                        isObey = true;
                    }
                }
            }

            return isObey;

        }
    }
}
