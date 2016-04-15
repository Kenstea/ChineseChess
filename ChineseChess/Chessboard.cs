using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ChineseChess.ChessItems;
using System.Diagnostics;

namespace ChineseChess
{
    public enum PostionLineType
    {
        Full = 0,
        UpPart = 1,
        DownPart = 2,
        RightPart = 3,
        LeftPart = 4
    }
    //|------------------------------------------------------------------------------|
    //|                                                                              |
    //|------------------------------------------------------------------------------|
    //|
    //|
    //|
    public partial class Chessboard : Form
    {
        private Point leftTopPoint;
        private Point leftBottomPoint;
        private Point rightTopPoint;
        private Point rightBottomPoint;
        Graphics g;
        Pen p;
        private int iniX = 60;
        private int iniY = 60;
        private const int chessRow = 9;
        private const int chessCol = 8;
        private static int _pieceWidth = 60;
        private ChessType _currentActionType = ChessType.Red;
        private BaseChess _selectChess;
        private bool canUndo = false;

        private King jiang;
        private King shuai;
        //Button startButton;

        private List<BaseChess> _chessPieces = new List<BaseChess>();

        private EngineClient _theEngineClient = null;


        public List<BaseChess> ChessPieces
        {
            get { return _chessPieces; }
            set { _chessPieces = value; }
        }
        public Chessboard()
        {
            InitializeComponent();
        }
        private void drawChessBoard()
        {

            int screenWidth = this.panel1.Width;
            int screenHeight = this.panel1.Height;

            // int wei = 50;
            //Point point = new Point(25, 25);
            //_pieceWidth = (int)Math.Round((decimal)(screenHeight) / chessRow) -10;
            iniX = 30;
            iniY = 30;

            leftTopPoint = new Point(iniX, iniY);
            leftBottomPoint = new Point(iniX, iniY + _pieceWidth * chessRow);
            rightTopPoint = new Point(iniX + _pieceWidth * chessCol, iniY);
            rightBottomPoint = new Point(iniX + _pieceWidth * chessCol, iniY + _pieceWidth * chessRow);
            //this.panel1.Width = iniY + _pieceWidth * chessRow + 50;
            //this.panel1.Height = screenHeight;

            g = this.panel1.CreateGraphics();
            p = new Pen(Color.Black, 2);
            int x1, x2, y1, y2;

            //Horizontal line
            x1 = leftTopPoint.X;
            y1 = leftTopPoint.Y;
            x2 = rightTopPoint.X;
            y2 = rightTopPoint.Y;
            for (int i = 0; i <= chessRow; i++)
            {
                g.DrawLine(p, x1, y1, x2, y2);
                y1 += _pieceWidth;
                y2 = y1;
            }
            g.DrawLine(p, leftTopPoint, leftBottomPoint);
            g.DrawLine(p, rightTopPoint, rightBottomPoint);

            //upper vertical  line
            x1 = leftTopPoint.X + _pieceWidth;
            y1 = leftTopPoint.Y;
            x2 = x1;
            y2 = y1 + _pieceWidth * 4;
            for (int i = 1; i < chessCol; i++)
            {
                g.DrawLine(p, x1, y1, x2, y2);
                x1 += _pieceWidth;
                x2 = x1;
            }
            //lower vertical line
            x1 = leftBottomPoint.X;
            y1 = leftBottomPoint.Y;
            x2 = leftBottomPoint.X;
            y2 = leftBottomPoint.Y - _pieceWidth * 4;
            for (int i = 1; i < chessRow; i++)
            {
                g.DrawLine(p, x1, y1, x2, y2);
                x1 += _pieceWidth;
                x2 = x1;
            }

            //upper cross line
            x1 = leftTopPoint.X + _pieceWidth * 3;
            y1 = leftTopPoint.Y;
            x2 = x1 + _pieceWidth * 2;
            y2 = y1 + _pieceWidth * 2;
            g.DrawLine(p, x1, y1, x2, y2);

            x1 = x1 + _pieceWidth * 2;
            x2 = x1 - _pieceWidth * 2;
            g.DrawLine(p, x1, y1, x2, y2);

            //lower cross line
            x1 = leftBottomPoint.X + _pieceWidth * 3;
            y1 = leftBottomPoint.Y;
            x2 = x1 + _pieceWidth * 2;
            y2 = y1 - _pieceWidth * 2;
            g.DrawLine(p, x1, y1, x2, y2);

            x1 = x1 + _pieceWidth * 2;
            x2 = x1 - _pieceWidth * 2;
            g.DrawLine(p, x1, y1, x2, y2);

            //draw position line for special chess pieces
            //upper left Cannon
            x1 = leftTopPoint.X + _pieceWidth;
            y1 = leftTopPoint.Y + _pieceWidth * 2;
            drawPostion(x1, y1);
            //left Pawn 1
            x1 = leftTopPoint.X;
            y1 = leftTopPoint.Y + _pieceWidth * 3;
            drawPostion(x1, y1, PostionLineType.RightPart);
            //left Pawn 2
            x1 += (_pieceWidth * 2);
            drawPostion(x1, y1);
            //left Pawn 3
            x1 += (_pieceWidth * 2);
            drawPostion(x1, y1);
            //left Pawn 4
            x1 += (_pieceWidth * 2);
            drawPostion(x1, y1);
            //left Pawn 5
            x1 += (_pieceWidth * 2);
            drawPostion(x1, y1, PostionLineType.LeftPart);
            //upper right Cannon's position
            x1 = rightTopPoint.X - _pieceWidth;
            y1 = rightTopPoint.Y + _pieceWidth * 2;
            drawPostion(x1, y1);

            //lower left Cannon
            x1 = leftBottomPoint.X + _pieceWidth;
            y1 = leftBottomPoint.Y - _pieceWidth * 2;
            drawPostion(x1, y1);
            //lower Pawn 1
            x1 = leftBottomPoint.X;
            y1 = leftBottomPoint.Y - _pieceWidth * 3;
            drawPostion(x1, y1, PostionLineType.RightPart);
            //lower Pawn 2
            x1 += (_pieceWidth * 2);
            drawPostion(x1, y1);
            //lower Pawn 3
            x1 += (_pieceWidth * 2);
            drawPostion(x1, y1);
            //lower Pawn 4
            x1 += (_pieceWidth * 2);
            drawPostion(x1, y1);
            //lower Pawn 5
            x1 += (_pieceWidth * 2);
            drawPostion(x1, y1, PostionLineType.LeftPart);
            //lower right Cannon
            x1 = rightBottomPoint.X - _pieceWidth;
            y1 = rightBottomPoint.Y - _pieceWidth * 2;
            drawPostion(x1, y1);

            ////"楚河","汉界"字
            //FontFamily fm = new FontFamily("黑体");
            //Font f = new Font(fm, 30);
            //StringFormat sf = new StringFormat();
            //sf.Alignment = StringAlignment.Near;
            //g.DrawString("楚", f, Brushes.Black, (float)(leftTopPoint.X + _pieceWidth * 4.1), (float)(leftTopPoint.Y + _pieceWidth * 1.3), sf);
            //g.DrawString("河", f, Brushes.Black, (float)(leftTopPoint.X + _pieceWidth * 4.1), (float)(leftTopPoint.Y + _pieceWidth * 2.3), sf);

            //g.DrawString("汉", f, Brushes.Black, (float)(leftTopPoint.X + _pieceWidth * 4.1), (float)(leftTopPoint.Y + _pieceWidth * 4.3), sf);
            //g.DrawString("界", f, Brushes.Black, (float)(leftTopPoint.X + _pieceWidth * 4.1), (float)(leftTopPoint.Y + _pieceWidth * 5.3), sf);
            //g.DrawString("", f, Brushes.Black, leftTopPoint.X + _pieceWidth * 5, leftTopPoint.Y + _pieceWidth * 4, sf);
            //f.Dispose();


            //draw the frame
            //p = new Pen(Color.Black, 10);
            //g.DrawLine(p, leftTopPoint.X - 15, leftTopPoint.Y - 10, rightTopPoint.X + 15, rightTopPoint.Y - 10);
            //g.DrawLine(p, leftBottomPoint.X - 15, leftBottomPoint.Y + 10, rightBottomPoint.X + 15, rightBottomPoint.Y + 10);
            //g.DrawLine(p, leftTopPoint.X - 10, leftTopPoint.Y - 15, leftBottomPoint.X - 10, leftBottomPoint.Y + 15);
            //g.DrawLine(p, rightTopPoint.X + 10, rightTopPoint.Y - 15, rightBottomPoint.X + 10, rightBottomPoint.Y + 15);
            //------------------------
            g.Dispose();
            //g.DrawLine(p, point.X, point.Y, point.X, point.Y + wei * 9);
            //g.DrawLine(p, point.X + wei * 8, point.Y, point.X + wei * 8, point.Y + wei * 9);

            ////上半边的竖向线
            //for (int i = 1; i <= 7; i++)
            //{
            //    g.DrawLine(p, point.X + wei * i, point.Y, point.X + wei * i, point.Y + wei * 4);
            //}
            ////下半边的竖向线
            //for (int i = 1; i <= 7; i++)
            //{
            //    g.DrawLine(p, point.X + wei * i, point.Y + wei * 5, point.X + wei * i, point.Y + wei * 9);
            //}
            ////两边的交叉线
            //g.DrawLine(p, point.X + wei * 3, point.Y, point.X + wei * 5, point.Y + wei * 2);
            //g.DrawLine(p, point.X + wei * 5, point.Y, point.X + wei * 3, point.Y + wei * 2);

            //g.DrawLine(p, point.X + wei * 3, point.Y + wei * 9, point.X + wei * 5, point.Y + wei * 7);
            //g.DrawLine(p, point.X + wei * 5, point.Y + wei * 9, point.X + wei * 3, point.X + wei * 7);
        }

        private void _changeType(bool isReset = false)
        {
            if (isReset)
            {
                _currentActionType = ChessType.Red;
            }
            else
            {
                _currentActionType = _getOppositeType(_currentActionType);
            }
            TypeStatus.Text = Enum.GetName(typeof(ChessType), _currentActionType);
            if (_currentActionType == ChessType.Red)
            {
                TypeStatus.ForeColor = Color.Red;
            }
            else
            {
                TypeStatus.ForeColor = Color.Black;
            }
        }
        private void drawPostion(Point thePoint)
        {
            drawPostion(thePoint.X, thePoint.Y);
        }
        /// <summary>
        /// the position line of chess piece
        /// _||_
        /// -||-
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void drawPostion(int x, int y, PostionLineType theType = PostionLineType.Full)
        {
            int offset = 5;
            int lineWidth = 20;
            //if (theType == PostionLineType.Full || theType == PostionLineType.UpPart)
            //{
            //    //left top
            //    Point temp11 = new Point(x - offset, y - offset);
            //    Point temp12 = new Point(x - offset - lineWidth, y - offset);
            //    Point temp13 = new Point(x - offset, y - offset - lineWidth);
            //    g.DrawLine(p, temp11, temp12);
            //    g.DrawLine(p, temp11, temp13);
            //    //right top
            //    Point temp21 = new Point(x + offset, y - offset);
            //    Point temp22 = new Point(x + offset, y - offset - lineWidth);
            //    Point temp23 = new Point(x + offset + lineWidth, y - offset);
            //    g.DrawLine(p, temp21, temp22);
            //    g.DrawLine(p, temp21, temp23);
            //}
            //if (theType == PostionLineType.Full || theType == PostionLineType.DownPart)
            //{
            //    //left bottom
            //    Point temp31 = new Point(x - offset, y + offset);
            //    Point temp32 = new Point(x - offset, y + offset + lineWidth);
            //    Point temp33 = new Point(x - offset - lineWidth, y + offset);
            //    g.DrawLine(p, temp31, temp32);
            //    g.DrawLine(p, temp31, temp33);
            //    //right bottom
            //    Point temp41 = new Point(x + offset, y + offset);
            //    Point temp42 = new Point(x + offset + lineWidth, y + offset);
            //    Point temp43 = new Point(x + offset, y + offset + lineWidth);
            //    g.DrawLine(p, temp41, temp42);
            //    g.DrawLine(p, temp41, temp43);
            //}

            if (theType == PostionLineType.Full || theType == PostionLineType.RightPart)
            {

                //right top
                Point temp21 = new Point(x + offset, y - offset);
                Point temp22 = new Point(x + offset, y - offset - lineWidth);
                Point temp23 = new Point(x + offset + lineWidth, y - offset);
                g.DrawLine(p, temp21, temp22);
                g.DrawLine(p, temp21, temp23);
                //right bottom
                Point temp41 = new Point(x + offset, y + offset);
                Point temp42 = new Point(x + offset + lineWidth, y + offset);
                Point temp43 = new Point(x + offset, y + offset + lineWidth);
                g.DrawLine(p, temp41, temp42);
                g.DrawLine(p, temp41, temp43);
            }
            if (theType == PostionLineType.Full || theType == PostionLineType.LeftPart)
            {
                //left top
                Point temp11 = new Point(x - offset, y - offset);
                Point temp12 = new Point(x - offset - lineWidth, y - offset);
                Point temp13 = new Point(x - offset, y - offset - lineWidth);
                g.DrawLine(p, temp11, temp12);
                g.DrawLine(p, temp11, temp13);
                //left bottom
                Point temp31 = new Point(x - offset, y + offset);
                Point temp32 = new Point(x - offset, y + offset + lineWidth);
                Point temp33 = new Point(x - offset - lineWidth, y + offset);
                g.DrawLine(p, temp31, temp32);
                g.DrawLine(p, temp31, temp33);

            }




        }

        public static int PieceWidth
        {
            get { return _pieceWidth; }
        }
        private void Chessboard_Load(object sender, EventArgs e)
        {
            //drawChessBoard();
            //startButton = new Button();
            //startButton.Location = new Point(rightBottomPoint.X+100,rightBottomPoint.Y-100);
            //startButton.Text = "Start";
            //startButton.Size = new System.Drawing.Size(100, 100);
            //startButton.Visible = true;
            //this.Controls.Add(startButton);
            //TypeStatus.Text = Enum.GetName(typeof(ChessType), _currentActionType);
            //createDangerLabel();
            //_previousChess = new Pawn();
            //_previousChess.Disposed += new EventHandler(_previousChess_Disposed);

            _theEngineClient = EngineClient.DefaultEngineClient;
            _theEngineClient.ReceviedEngineData += new DataReceivedEventHandler(_theEngineClient_ReceviedEngineData);
        }

        private void _previousChess_Disposed(object sender, EventArgs e)
        {

        }

        private void _theEngineClient_ReceviedEngineData(object sender, DataReceivedEventArgs e)
        {

        }

        public BaseChess hasChessOnPoint(int gridX, int gridY)
        {
            BaseChess theChess = null;
            foreach (BaseChess curChess in _chessPieces)
            {
                if (curChess.GridX == gridX && curChess.GridY == gridY)
                {
                    theChess = curChess;
                }
            }

            return theChess;

        }
        //public List<BaseChess> hasChessBetweenPointsInLine(Point pointA, Point pointB)
        //{
        //    List<BaseChess> theList = new List<BaseChess>();
        //    bool isInVerticalline = (pointA.X ==pointB.X);
        //    if (pointA.X ==pointB.X )
        //    {
        //        //int MinX = pointA.X < pointB.X ? pointA.X : pointB.X;
        //        int MinY = pointA.Y < pointB.Y ? pointA.Y : pointB.Y;
        //        //int MaxX = pointA.X > pointB.X ? pointA.X : pointB.X;
        //        int MaxY = pointA.Y > pointB.Y ? pointA.Y : pointB.Y;
        //        foreach (BaseChess curChess in _chessPieces)
        //        {
        //            if (curChess.CurrentPoint.Y > MinY && curChess.CurrentPoint.Y < MaxY)
        //            {
        //                theList.Add(curChess);
        //            }
        //        }
        //    }
        //    else if (pointA.Y == pointB.Y)
        //    {
        //        int minX = pointA.X < pointB.X ? pointA.X : pointB.X;

        //        int maxX = pointA.X > pointB.X ? pointA.X : pointB.X;

        //        foreach (BaseChess curChess in _chessPieces)
        //        {
        //            if (curChess.CurrentPoint.X > minX && curChess.CurrentPoint.X < maxX)
        //            {
        //                theList.Add(curChess);
        //            }
        //        }
        //    }

        //    return theList;

        //}

        //public BaseChess hasChessOnPointInField(Point targetPoint, BaseChess selectChess)
        //{
        //    BaseChess theChess = null;
        //    int minX = targetPoint.X < selectChess.CurrentPoint.X ? targetPoint.X : selectChess.CurrentPoint.X;
        //    int minY = targetPoint.Y < selectChess.CurrentPoint.Y ? targetPoint.Y : selectChess.CurrentPoint.Y;
        //    foreach (BaseChess curChess in _chessPieces)
        //    {
        //        if (curChess.CurrentPoint.X == minX + _pieceWidth && curChess.CurrentPoint.Y == minY + _pieceWidth)
        //        {
        //            theChess = curChess;
        //            break;
        //        }
        //    }
        //    return theChess;

        //}
        //public BaseChess hasChessOnPointInSun(int gridX,int gridY, BaseChess theKnight)
        //{
        //    BaseChess theChess = null;
        //    if (Math.Abs(gridX-theKnight.GridX)==2 && Math.Abs(gridY-theKnight.GridY)==1)
        //    {
        //        theChess = hasChessOnPoint((gridX + theKnight.GridX) / 2, gridY);
        //    }
        //    else if (Math.Abs(gridY - theKnight.GridY) == 2 && Math.Abs(gridX - theKnight.GridX) == 1)
        //    {
        //        theChess = hasChessOnPoint(gridX, (gridY + theKnight.GridX) / 2);
        //    }

        //    return theChess;

        //}
        private void loadChessPieces()
        {

        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            //_previousChess.remove();
            this.panel1.Controls.Clear();
            timer1.Enabled = true;
            timer1.Start();
            _changeType(true);
            //_currentActionType = ChessType.Red;
            //TypeStatus.Text = Enum.GetName(typeof(ChessType), _currentActionType);

            #region 放置棋子,红方
            for (int i = 0; i <= 8; i += 8)
            {
                Rook ju1 = new Rook();
                ju1.Type = ChessType.Red;
                ju1.GridX = i;
                ju1.GridY = 0;
                ju1.PreviousGridX = i;
                ju1.PreviousGridY = 0;
                ju1.Text = "车";
                ju1.InitChess();
                this.panel1.Controls.Add(ju1);
                ju1.MouseClick += new MouseEventHandler(chessItem_MouseClick);


            }

            for (int i = 1; i <= 7; i += 6)
            {
                Knight ma = new Knight();
                ma.Type = ChessType.Red;
                ma.GridX = i;
                ma.GridY = 0;
                ma.PreviousGridX = i;
                ma.PreviousGridY = 0;
                ma.Text = "马";
                ma.InitChess();
                this.panel1.Controls.Add(ma);
                ma.MouseClick += new MouseEventHandler(chessItem_MouseClick);

                //因为“炮”与“马”的位置都类似，循环次数也一样
                Cannon pao = new Cannon();
                pao.Type = ChessType.Red;
                pao.GridX = i;
                pao.GridY = 2;
                pao.PreviousGridX = i;
                pao.PreviousGridY = 2;
                pao.Text = "炮";
                pao.InitChess();
                this.panel1.Controls.Add(pao);
                pao.MouseClick += new MouseEventHandler(chessItem_MouseClick);
            }

            for (int i = 2; i <= 6; i += 4)
            {
                Bishop xiang = new Bishop();
                xiang.Type = ChessType.Red;
                xiang.GridX = i;
                xiang.GridY = 0;
                xiang.PreviousGridX = i;
                xiang.PreviousGridY = 0;
                xiang.Text = "相";
                xiang.InitChess();
                this.panel1.Controls.Add(xiang);
                xiang.MouseClick += new MouseEventHandler(chessItem_MouseClick);
            }

            for (int i = 3; i <= 6; i += 2)
            {
                Advisor shi = new Advisor();
                shi.Type = ChessType.Red;
                shi.GridX = i;
                shi.GridY = 0;
                shi.PreviousGridX = i;
                shi.PreviousGridY = 0;
                shi.Text = "士";
                shi.InitChess();
                this.panel1.Controls.Add(shi);
                shi.MouseClick += new MouseEventHandler(chessItem_MouseClick);
            }

            jiang = new King();
            jiang.Type = ChessType.Red;
            jiang.GridX = 4;
            jiang.GridY = 0;
            jiang.PreviousGridX = 4;
            jiang.PreviousGridY = 0;
            jiang.Text = "将";
            jiang.InitChess();
            this.panel1.Controls.Add(jiang);
            jiang.MouseClick += new MouseEventHandler(chessItem_MouseClick);
            jiang.BeRemoved += new EventHandler(_beRemovedEventHandler);
            //jiang.IsMoved += new EventHandler(checkKingFaceToFace);

            for (int i = 0; i <= 8; i += 2)
            {
                Pawn bing = new Pawn();
                bing.Type = ChessType.Red;
                bing.GridX = i;
                bing.GridY = 3;
                bing.PreviousGridX = i;
                bing.PreviousGridY = 3;
                bing.Text = "兵";
                bing.InitChess();
                this.panel1.Controls.Add(bing);
                bing.MouseClick += new MouseEventHandler(chessItem_MouseClick);
            }
            #endregion

            #region 放置棋子,黑方
            for (int i = 0; i <= 8; i += 8)
            {
                Rook ju1 = new Rook();
                ju1.Type = ChessType.Black;
                ju1.GridX = i;
                ju1.GridY = 9;
                ju1.PreviousGridX = i;
                ju1.PreviousGridY = 9;
                ju1.Text = "車";
                ju1.InitChess();
                this.panel1.Controls.Add(ju1);
                ju1.MouseClick += new MouseEventHandler(chessItem_MouseClick);
            }

            for (int i = 1; i <= 7; i += 6)
            {
                Knight ma = new Knight();
                ma.Type = ChessType.Black;
                ma.GridX = i;
                ma.GridY = 9;
                ma.PreviousGridX = i;
                ma.PreviousGridY = 9;
                ma.Text = "馬";
                ma.InitChess();
                this.panel1.Controls.Add(ma);
                ma.MouseClick += new MouseEventHandler(chessItem_MouseClick);

                //因为“炮”与“马”的位置都类似，循环次数也一样
                Cannon pao = new Cannon();
                pao.Type = ChessType.Black;
                pao.GridX = i;
                pao.GridY = 7;
                pao.PreviousGridX = i;
                pao.PreviousGridY = 7;
                pao.Text = "炮";
                pao.InitChess();
                this.panel1.Controls.Add(pao);
                pao.MouseClick += new MouseEventHandler(chessItem_MouseClick);
            }

            for (int i = 2; i <= 6; i += 4)
            {
                Bishop xiang = new Bishop();
                xiang.Type = ChessType.Black;
                xiang.GridX = i;
                xiang.GridY = 9;
                xiang.PreviousGridX = i;
                xiang.PreviousGridY = 9;
                xiang.Text = "象";
                xiang.InitChess();
                this.panel1.Controls.Add(xiang);
                xiang.MouseClick += new MouseEventHandler(chessItem_MouseClick);
            }

            for (int i = 3; i <= 6; i += 2)
            {
                Advisor shi = new Advisor();
                shi.Type = ChessType.Black;
                shi.GridX = i;
                shi.GridY = 9;
                shi.PreviousGridX = i;
                shi.PreviousGridY = 9;
                shi.Text = "仕";
                shi.InitChess();
                this.panel1.Controls.Add(shi);
                shi.MouseClick += new MouseEventHandler(chessItem_MouseClick);
            }

            shuai = new King();
            shuai.Type = ChessType.Black;
            shuai.GridX = 4;
            shuai.GridY = 9;
            shuai.PreviousGridX = 4;
            shuai.PreviousGridY = 9;
            shuai.Text = "帅";
            shuai.InitChess();
            this.panel1.Controls.Add(shuai);
            shuai.MouseClick += new MouseEventHandler(chessItem_MouseClick);
            shuai.BeRemoved += new EventHandler(_beRemovedEventHandler);
            //shuai.IsMoved += new EventHandler(checkKingFaceToFace);

            for (int i = 0; i <= 8; i += 2)
            {
                Pawn bing = new Pawn();
                bing.Type = ChessType.Black;
                bing.GridX = i;
                bing.GridY = 6;
                bing.PreviousGridX = i;
                bing.PreviousGridY = 6;
                bing.Text = "卒";
                bing.InitChess();
                this.panel1.Controls.Add(bing);
                bing.MouseClick += new MouseEventHandler(chessItem_MouseClick);
            }
            StartButton.Enabled = false;
            #endregion

        }

        private void chessItem_MouseClick(object sender, EventArgs e)
        {
            BaseChess _tempChess = (BaseChess)sender;
            //if (_selectChess != null && _tempChess != _selectChess)
            //{
            //    _selectChess.IsChecked = false;
            //}


            if (_selectChess == null)
            {
                //第一次选择棋子
                if (_tempChess.Type == _currentActionType)
                {
                    _selectChess = _tempChess;
                    //_previousChess = _selectChess;
                }
                else
                {
                    //选择错了棋子
                    _tempChess.IsChecked = false;
                }


            }
            else
            {
                //已经选择了一个棋子，再次选择时是对方棋子
                if (_tempChess.Type != _currentActionType)
                {
                    BaseChess beAttackChess = (BaseChess)sender;
                    if (_selectChess.move(beAttackChess.Location))
                    {

                        _previousOppositeChess = beAttackChess.Clone();
                        beAttackChess.remove();
                        doSomeAfterMove();
                    }

                }
                else
                {
                    //如果再次选择时还是己方棋子,更改check状态
                    _selectChess.IsChecked = false;
                    //更换当前引用
                    _selectChess = _tempChess;

                }
            }

            //else
            //{
            //    _selectChess.IsChecked = false;
            //    // _tempChess.IsChecked = false;
            //}

        }
        /// <summary>
        /// when king is killed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _beRemovedEventHandler(object sender, EventArgs e)
        {
            King theloseKing = (King)sender;
            ChessType theWinnerType = _getOppositeType(theloseKing.Type);
            string type = Enum.GetName(typeof(ChessType), theWinnerType);
            if (MessageBox.Show(type + " side Win!!! Do you want new game?", "Game over", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                //重新开具
                StartButton_Click(null, null);
            }
            else
            {
                StartButton.Enabled = true;
            }
        }
        private bool isKingDanger()
        {
            //to do
            int gridX, gridY;
            gridX = gridY = -1;
            if (_currentActionType == ChessType.Red)
            {
                gridX = jiang.GridX;
                gridY = jiang.GridY;

            }
            else if (_currentActionType == ChessType.Black)
            {
                gridX = shuai.GridX;
                gridY = shuai.GridY;
            }

            if (_selectChess != null && _selectChess.obeyTheLimit(gridX, gridY))
            {
                return true;
            }
            return false;
        }
        private void checkKingFaceToFace(object sender, EventArgs e)
        {
            bool hasChessBetweenKing = false;
            if (jiang.GridY == shuai.GridY)
            {
                foreach (Control curCtr in this.panel1.Controls)
                {
                    if (curCtr is BaseChess)
                    {
                        BaseChess tempChess = (BaseChess)curCtr;
                        if (tempChess.GridY == jiang.GridY
                            && tempChess != jiang
                            && tempChess != shuai)
                        {
                            hasChessBetweenKing = true;
                            break;
                        }
                    }
                }
                if (!hasChessBetweenKing)
                {
                    showDangerInfo();
                }
            }
        }
        private bool isKingDangerFromOtherChess(King theKing)
        {

            foreach (Control curCtr in this.panel1.Controls)
            {
                if (curCtr is BaseChess)
                {
                    BaseChess tempChess = (BaseChess)curCtr;
                    ChessType oppositeType = _getOppositeType(theKing.Type);
                    if (tempChess.Type == oppositeType)
                    {
                        if (tempChess.obeyTheLimit(theKing.GridX, theKing.GridY))
                        {

                            showDangerInfo();
                            return true;

                        }

                    }
                }
            }
            return false;
        }


        private King getOppoisteKing(ChessType theType)
        {
            if (theType == ChessType.Red)
            {
                return shuai;
            }
            else
            {
                return jiang;
            }

        }

        private King getOwnKing(ChessType theType)
        {
            if (theType == ChessType.Red)
            {
                return jiang;
            }
            else
            {
                return shuai;
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            drawChessBoard();
        }

        private void panel1_Click(object sender, EventArgs e)
        {

        }

        private void Chessboard_MouseClick(object sender, MouseEventArgs e)
        {
            XCoordinate.Text = e.X.ToString();
            YCoordinate.Text = e.Y.ToString();
        }

        private void Chessboard_MouseMove(object sender, MouseEventArgs e)
        {
            XCoordinate.Text = e.X.ToString();
            YCoordinate.Text = e.Y.ToString();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            XCoordinate.Text = e.X.ToString();
            YCoordinate.Text = e.Y.ToString();
        }



        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (_selectChess != null && _selectChess.Type == _currentActionType)
            {
                if (_selectChess.move(e.Location))
                {
                    //_selectChess.IsChecked = false;
                    doSomeAfterMove();
                }
            }
        }
        //private void createDangerLabel()
        //{
        //    dangerLabel = new Label();
        //    dangerLabel.Text = "  将!  ";
        //    dangerLabel.ForeColor = Color.Red;
        //    dangerLabel.BackColor = Color.Sienna;
        //    //设置相关属性
        //    dangerLabel.Width = 60;
        //    dangerLabel.Height = 60;
        //    dangerLabel.TextAlign = ContentAlignment.MiddleCenter;
        //    dangerLabel.Font = new System.Drawing.Font("黑体", 30F, FontStyle.Bold);
        //    dangerLabel.Location = new Point(720,80);

        //    dangerLabel.AutoSize = true;
        //    //this.label1.Location = new System.Drawing.Point(752, 200);
        //    dangerLabel.Name = "dangerLabel";
        //    //dangerLabel.Size = new System.Drawing.Size(60, 100);
        //    //this.label1.TabIndex = 6;
        //    //this.label1.Text = "label1";

        //    this.Controls.Add(dangerLabel);
        //    dangerLabel.Visible = false;
        //}

        //Label dangerLabel;
        private void showDangerInfo()
        {
            dangerLabel.Visible = true;
            //System.Threading.Thread.Sleep(1500);


        }
        private void threadPro()
        {
            MethodInvoker MethInvo = new MethodInvoker(showDangerInfo);
            BeginInvoke(MethInvo);
        }

        private void doSomeAfterMove()
        {
            _changeType();
            //两种将的方式都会显示dangerLabel
            checkKingFaceToFace(null, null);
            if (!isKingDangerFromOtherChess(jiang) && !isKingDangerFromOtherChess(shuai))
            {
                dangerLabel.Visible = false;
            }

            UndoButton.Enabled = true;
            _previousChess = _selectChess;
            _selectChess.IsChecked = false;
            _selectChess = null;
        }

        private ChessType _getOppositeType(ChessType currentType)
        {
            if (currentType == ChessType.Black)
            {
                return ChessType.Red;
            }
            else if (currentType == ChessType.Red)
            {
                return ChessType.Black;
            }
            return ChessType.Red;
        }

        private void UndoButton_Click(object sender, EventArgs e)
        {
            try
            {
                _changeType();
                if (_previousChess != null)
                {
                    _previousChess.GridX = _previousChess.PreviousGridX;
                    _previousChess.GridY = _previousChess.PreviousGridY;
                    _previousChess.InitChess();
                }
                if (_previousOppositeChess != null)
                {
                    //Type theType = _previousOppositeChess.GetType();
                    //object theChess = Activator.CreateInstance(theType);

                    //BaseChess newChess = _previousOppositeChess.Clone();
                    //int index = this.panel1.Controls.GetChildIndex(_previousOppositeChess, false);
                    //Pawn theBing = new Pawn();
                    //theBing.GridX = 6;
                    //theBing.GridY = 4;
                    //theBing.Type = ChessType.Black;
                    //theBing.Text = "卒";
                    _previousOppositeChess.MouseClick += new MouseEventHandler(chessItem_MouseClick);
                    this.panel1.Controls.Add(_previousOppositeChess);
                    _previousOppositeChess = null;
                }
                if (dangerLabel.Visible)
                {
                    dangerLabel.Visible = false;
                }
                UndoButton.Enabled = false;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }

        private BaseChess _previousChess;
        private BaseChess _previousOppositeChess;

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
        //private void Chessboard_Resize(object sender, EventArgs e)
        //{
        //    drawChessBoard();
        //}






    }
}
