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
        public override bool obeyTheLimit(int gridX, int gridY)
        {
            bool isObey = false;
            if (!base.obeyTheLimit(gridX, gridY))
            {
                return false;
            }
            if (Type == ChessType.Red)
            {
                if (GridX<=4)
                {
                    if (gridX-GridX==1 && GridY == gridY)
                    {
                        isObey = true;
                    }
                }
                else
                {
                    if ((gridX - GridX == 1 && GridY == gridY) ||
                        (Math.Abs(GridY - gridY) == 1 && GridX == gridX))
                    {
                        isObey = true;
                    }
                }
            }
            else
            {
                if (GridX >= 5)
                {
                    if (GridX - gridX == 1 && GridY == gridY)
                    {
                        isObey = true;
                    }
                }
                else
                {
                    if ((GridX - gridX == 1 && GridY == gridY) ||
                        (Math.Abs(GridY - gridY) == 1 && GridX == gridX))
                    {
                        isObey = true;
                    }
                }
            }

            return isObey;

        }
    }
}
