using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChineseChess.ChessItems
{
    /// <summary>
    /// 车
    /// </summary>
    public class Rook : BaseChess
    {
        public Rook()
        {
            _pieceType = ChessPieceType.ROOK;
        }
        public override bool obeyTheLimit(int gridX, int gridY)
        {
            int min;
            int max;
            if (!base.obeyTheLimit(gridX, gridY))
            {
                return false;
            }
            if (GridX == gridX)
            {
                ChessUtils.getMinMax(GridY, gridY, out min, out max);
                for (int i = min + 1; i < max; i++)
                {
                    if (hasChessOnPoint(GridX, i) && i != GridY)
                    {
                        return false;
                    }
                }


            }
            else if (GridY == gridY)
            {
                ChessUtils.getMinMax(GridX, gridX, out min, out max);
                for (int i = min + 1; i < max; i++)
                {
                    if (hasChessOnPoint(i, GridY) && i != GridX)
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
            return true;

        }



    }
}
