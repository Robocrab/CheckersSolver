using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
namespace CheckersSolver
{
    public class UIHandler
    {
        //FIELDS----
        Graphics graphics;
        PictureBox pictureBox;
        Label resultLabel;
        int cellSize;
        int boardSize;
        public UIHandler(PictureBox pictureBox, Label resultLabel, int cellSize = 1)
        {
            this.pictureBox = pictureBox;
            graphics = pictureBox.CreateGraphics();
            this.cellSize = cellSize;
            this.resultLabel = resultLabel;

        }
        //EVENTS-----
        public void OnSizeChosen(int size)
        {
            boardSize = size;
            cellSize = pictureBox.Width / size;
            DrawEmptyBoard();
        }
        //DRAWING-----
        public void DrawCell(Point position, Cell cell)
        {
            DrawCellEmpty(position.X, position.Y);
            if (!cell.empty)
            {
                if (cell.white)
                {
                    DrawChecker(position, Color.LightGray);
                }
                else
                {
                    DrawChecker(position, Color.Red);
                }
            }
        }
        public void DrawCellEmpty(int X, int Y)
        {
            Brush brush = new SolidBrush(ColorFromCellPos(X, Y));
            graphics.FillRectangle(brush, X * cellSize, Y * cellSize, cellSize, cellSize);
        }
        public void DrawChecker(Point position, Color color)
        {
            
            graphics.FillEllipse(new SolidBrush(color),
                position.X * cellSize, position.Y * cellSize, cellSize, cellSize);
        }
        public void DrawEmptyBoard()
        {
            for (int x = 0; x < pictureBox.Width / cellSize; x++)
            {
                for (int y = 0; y < pictureBox.Width / cellSize; y++)
                {
                    DrawCellEmpty(x, y);
                }
            }
        }
        public void UpdateCell(Point Position)
        {
            int cellIndex = CellMath.PlayableCellIndexFromPos(Position, MainClass.boardSize);
            DrawCell(Position, MainClass.displayedCells[cellIndex]);
        }
        public void UpdateBoard()
        {
            Thread.Sleep(100);
            foreach (var cell in MainClass.displayedCells)
            {
                if (cell != null)
                {
                    UpdateCell(new Point(cell.X, cell.Y));
                }
            }
        }
        Color ColorFromCellPos(int X, int Y)
        {
            if ((X + Y) % 2 == 0)
            {
                return Color.White;
            }
            else return Color.Black;
        }
        //OTHER------
        public Point CellPosFromMousePos(Point mousePosition)
        {
            Point CellPos = new Point();
            CellPos.X = mousePosition.X / cellSize; 
            CellPos.Y = mousePosition.Y / cellSize;
            return CellPos;
        }
        public void DisplayResult(bool whiteHaveWon)
        {
            if (whiteHaveWon)
            {
                resultLabel.Text = "result: white have a winning strategy.";
            }
            else
            {
                resultLabel.Text = "result: red have a winning strategy.";
            }
        }
    }
}