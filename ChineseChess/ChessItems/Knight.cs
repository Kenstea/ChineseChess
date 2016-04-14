using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChineseChess.ChessItems
{
    /// <summary>
    /// 马
    /// </summary>
    public class Knight : BaseChess
    {
        public override bool obeyTheLimit(int gridX, int gridY)
        {

            if (base.obeyTheLimit(gridX, gridY))
            {
                if (this.Type == ChessType.Black)
                {
                    //¸öÐÔ»¯ÅÐ¶Ï
                    if ((Math.Abs(GridX - gridX) == 2 && Math.Abs(GridY - gridY) == 1))
                    {
                        if (!hasChessOnPoint((GridX + gridX) / 2, GridY))
                        {
                            return true;
                        }
                        else return false;
                    }
                    if (((Math.Abs(GridX - gridX) == 1 && Math.Abs(GridY - gridY) == 2)))
                    {
                        if (!hasChessOnPoint(GridX, (GridY + gridY) / 2))
                        {
                            return true;
                        }
                        else return false;
                    }
                }
                else if (this.Type == ChessType.Red)
                {
                    //¸öÐÔ»¯ÅÐ¶Ï
                    if (((Math.Abs(GridX - gridX) == 1 && Math.Abs(GridY - gridY) == 2)))
                    {
                        if (!hasChessOnPoint(GridX, (GridY + gridY) / 2))
                        {
                            return true;
                        }
                        else return false;
                    }
                    if ((Math.Abs(GridX - gridX) == 2 && Math.Abs(GridY - gridY) == 1))
                    {
                        if (!hasChessOnPoint((GridX + gridX) / 2, GridY))
                        {
                            return true;
                        }
                        else return false;
                    }
                }
                return false;
            }
            return false;
        }
    }
}
