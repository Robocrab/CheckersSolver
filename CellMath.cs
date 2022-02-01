using System.Drawing;
using System;
namespace CheckersSolver
{
    public static class CellMath
    {
        public static int PlayableCellIndexFromPos(int X, int Y, int boardSize)
        {
            return PlayableCellIndexFromPos(new Point(X, Y), boardSize);
        }
        public static bool PositionPlayable(Point position, int boardSize)
        {
            return !((position.X + position.Y) % 2 == 0);
        }
        public static int PlayableCellIndexFromPos(Point Position, int boardSize)
        {
            int X = Position.X + 1;
            int Y = Position.Y + 1;
            if (X < 1 || Y < 1 || X > boardSize || Y > boardSize)
            {
                return -1;
            }
            int size = boardSize;
            if ((X + Y) % 2 == 0)
            {
                throw new System.ArgumentException("Given position is not a playable position.");
            }

            if (Y % 2 == 0)
            {
                return (X - 1) / 2 + (Y - 1) * size / 2;
            }
            else
            {
                return (X) / 2 + (Y - 1) * size / 2 - 1;
            }
        }
        public static Point PlayableCellPosFromIndex(int i, int boardSize)
        {
            Point point = new Point();
            point.Y = (i) * 2 / boardSize;
            if (point.Y % 2 == 0)
            {
                point.X = ((i + 1) * 2 - 1) % (boardSize);
            }
            else
            {
                point.X = (i * 2) % boardSize;
            }
            return point;
        }
        public static void BuildCellArray(Cell[] cells)
        {
            int boardSize = (int)Math.Sqrt((double)cells.Length * 2);

            for (int i = 0; i < cells.Length; i++)
            {
                Point position = PlayableCellPosFromIndex(i, boardSize);
                cells[i] = new Cell(position.X, position.Y, i);
            }

            SetCellArrayNeighbours(cells, boardSize);
        }
        public static bool IndexInsideArray(int i, int boardSize)
        {
            return i > -1 && i < boardSize * boardSize / 2;
        }
        public static Cell[] DeepCloneCellArray(Cell[] initialArray)
        {
            Cell[] DeepCloneArray = new Cell[initialArray.Length];
            int boardSize = (int)Math.Sqrt((double)initialArray.Length * 2);

            for (int i = 0; i < initialArray.Length; i++)
            {
                DeepCloneArray[i] = new Cell(initialArray[i]);
            }
            SetCellArrayNeighbours(DeepCloneArray, boardSize);
            return DeepCloneArray;
        }
        public static void SetCellArrayNeighbours(Cell[] cells, int boardSize)
        {
            //SET NEIGHBOURS
            for (int i = 0; i < cells.Length; i++)
            {
                Point pos = PlayableCellPosFromIndex(i, boardSize);
                int NW_NeighbourIndex = PlayableCellIndexFromPos(pos.X - 1, pos.Y - 1, boardSize);
                int NE_NeighbourIndex = PlayableCellIndexFromPos(pos.X + 1, pos.Y - 1, boardSize);
                int SE_NeighbourIndex = PlayableCellIndexFromPos(pos.X + 1, pos.Y + 1, boardSize);
                int SW_NeighbourIndex = PlayableCellIndexFromPos(pos.X - 1, pos.Y + 1, boardSize);


                //NW
                if (IndexInsideArray(NW_NeighbourIndex, boardSize))
                    cells[i].Neighbours[0] = cells[NW_NeighbourIndex];
                //NE
                if (IndexInsideArray(NE_NeighbourIndex, boardSize))
                    cells[i].Neighbours[1] = cells[NE_NeighbourIndex];
                //SE
                if (IndexInsideArray(SE_NeighbourIndex, boardSize))
                    cells[i].Neighbours[2] = cells[SE_NeighbourIndex];
                //SW
                if (IndexInsideArray(SW_NeighbourIndex, boardSize))
                    cells[i].Neighbours[3] = cells[SW_NeighbourIndex];
            }
        }
        public static Direction DirectionFromColorAndSide(bool white, bool left)
        {
            if (white)
            {
                if (left)
                {
                    return Direction.NW;
                }
                else
                {
                    return Direction.NE;
                }
            }
            else
            {
                if (left)
                {
                    return Direction.SW;
                }
                else
                {
                    return Direction.SE;
                }
            }
        }
    }
}