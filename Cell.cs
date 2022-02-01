using System.Drawing;
namespace CheckersSolver
{
    public class Cell
    {
        public bool empty;
        public bool white;
        public Cell[] Neighbours = new Cell[4];
        public int X { get; private set; }
        public int Y { get; private set; }
        public int index { get; private set; }
        public Cell(int X, int Y, int index)
        {
            this.X = X;
            this.Y = Y;
            this.index = index;
            empty = true;
            white = true;

        }
        //DEEP COPY CONSTRUCTOR
        public Cell(Cell originalToDeepCopy)
        {
            index = originalToDeepCopy.index;
            X = originalToDeepCopy.X;
            Y = originalToDeepCopy.Y;
            empty = originalToDeepCopy.empty;
            white = originalToDeepCopy.white;
            Neighbours = (Cell[])originalToDeepCopy.Neighbours.Clone();
        }
        public void NextState()
        {
            if (empty)
            {
                empty = false;
                white = true;
                return;
            }
            else if (white)
            {
                white = false;
                return;
            }
            else
            {
                empty = true;
                return;
            }
        }
        public Cell GetNeighbour(Direction direction)
        {
            return Neighbours[(int)direction];
        }
        public bool MovePossible(bool left)
        {
            Cell neighbour =
                Neighbours[(int)CellMath.DirectionFromColorAndSide(white, left)];

            if (neighbour == null)
                return false;
            if (neighbour.empty)
                return true;
            else
                return false;
        }
        public bool CapturePossible(bool left)
        {
            Cell neighbour =
                Neighbours[(int)CellMath.DirectionFromColorAndSide(white, left)];
            if (neighbour == null)
            { return false; }

            Cell neighboursNeighbour = 
                neighbour.Neighbours[(int)CellMath.DirectionFromColorAndSide(white, left)];
            if (neighboursNeighbour == null)
            { return false; }

            if (neighbour.empty == false && neighbour.white != white && neighboursNeighbour.empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public enum Direction
    {
        NW,
        NE,
        SE,
        SW
    }
}