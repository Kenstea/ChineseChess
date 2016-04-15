using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ChineseChess.ChessItems
{
    /// <summary>
    /// 将军
    /// </summary>
    public class King : BaseChess
    {
        public King(Chessboard theChessBoard)
            : base(theChessBoard)
        {

        }
        public King()
        {

        }
        public event EventHandler BeRemoved;
        public event EventHandler IsMoved;
        public override bool obeyTheLimit(int gridX, int gridY)
        {
            if (!base.obeyTheLimit(gridX, gridY))
            {
                return false;
            }

            if (gridX < 3 || gridX > 5)
            {
                return false;
            }
            if ((Type == ChessType.Red && gridY <= 2) ||
                (Type == ChessType.Black && gridY >= 7))
            {
                if (GridX == gridX && (Math.Abs(GridY - gridY) == 1)
                    || GridY == gridY && (Math.Abs(GridX - gridX) == 1))
                {

                    return true;
                }

            }
            return false;

        }

        //public override bool move(Point nextLocation)
        //{
        //    if (base.move(nextLocation))
        //    {
        //        //IsMoved(this, null);
        //        return true;
        //    }
        //    return false;
        //}


        public override void remove()
        {
            BeRemoved(this, null);
            base.remove();
        }
    }
}
