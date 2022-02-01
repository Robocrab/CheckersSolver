using System.Collections.Generic;

namespace CheckersSolver
{
    class Solver
    {
        bool whiteGoFirst;
        Cell[] InitialState;
        Tree ResultTree;
        bool visualize;
        public Solver(Cell[] InitialState, bool whiteGoFirst)
        {
            this.InitialState = InitialState;
            this.whiteGoFirst = whiteGoFirst;
            ResultTree = new Tree(whiteGoFirst);
        }

        public bool Solve(bool visualize)
        {
            this.visualize = visualize;
            Iterate(InitialState,whiteGoFirst,ResultTree.Origin);
            return ResultTree.WhiteCertainlyWin();
        }
        void Iterate(Cell[] state, bool whiteGo, Node currentNode)
        {
            Cell[][] possibleTurns = GetPossibleTurns(state, whiteGo);
            bool validMovesPresent = false;

            if (visualize)
            {
                foreach (Cell[] cells in possibleTurns)
                {
                    MainClass.displayedCells = cells;
                    MainClass.UpdateDisplay();

                }
            }
            foreach (Cell[] newState in possibleTurns)
            {
                validMovesPresent = true;
                Iterate(newState, !whiteGo,currentNode.AddChild(new MoveInfo()));
            }
            if (!validMovesPresent)
            {
                currentNode.whiteHaveWon = !whiteGo;
                return;
            }
        }
        Cell[][] GetPossibleTurns(Cell[] state, bool whiteGo)
        {
            List<Cell[]> PossibleTurns = new List<Cell[]>(InitialState.Length * 4);
            bool canCapture = false;
            foreach (Cell cell in GetColouredCells(state, whiteGo))
            {
                Cell[] CaptureLeft = GenerateCapturedState(cell, state, true);
                Cell[] CaptureRight = GenerateCapturedState(cell, state, false);

                if (CaptureLeft != null)
                {
                    PossibleTurns.Add(CaptureLeft);
                    canCapture = true;
                }
                if (CaptureRight != null)
                {
                    PossibleTurns.Add(CaptureRight);
                    canCapture = true;
                }
            }
            if (canCapture)
            {
                return PossibleTurns.ToArray();
            }
            foreach (Cell cell in GetColouredCells(state, whiteGo))
            {
                Cell[] MoveLeft = GenerateMovedState(cell, state, true);
                Cell[] MoveRight = GenerateMovedState(cell, state, false);

                if (MoveLeft != null)
                {
                    PossibleTurns.Add(MoveLeft);
                }
                if (MoveRight != null)
                {
                    PossibleTurns.Add(MoveRight);
                }
            }
            return PossibleTurns.ToArray();
        }
        Cell[] GetColouredCells(Cell[] state, bool white)
        {
            if (white)
            {
                return GetWhiteCells(state);
            }
            else
            {
                return GetRedCells(state);
            }
        }
        Cell[] GetWhiteCells(Cell[] state)
        {
            Cell[] whiteCells = new Cell[state.Length];

            int counter = 0;
            for (int i = 0; i < state.Length; i++)
            {
                if (state[i].empty == false && state[i].white)
                {
                    whiteCells[counter] = state[i];
                    counter++;
                }
            }
            return whiteCells;

        }
        Cell[] GetRedCells(Cell[] state)
        {
            Cell[] redCells = new Cell[state.Length];

            int counter = 0;
            for (int i = 0; i < state.Length; i++)
            {
                if (state[i].empty == false && !state[i].white)
                {
                    redCells[counter] = state[i];
                    counter++;
                }
            }
            return redCells;
        }
        Cell[] GenerateMovedState(Cell cell, Cell[] state, bool left)
        {
            if (cell==null)
            {
                return null;
            }
            if (cell.MovePossible(left))
            {
                Cell[] clonedState = CellMath.DeepCloneCellArray(state);
                Cell clonedCell = clonedState[cell.index];

                Direction MoveDirection =
                  CellMath.DirectionFromColorAndSide(clonedCell.white, left);

                Cell clonedNeighbour =
                    clonedCell.Neighbours[(int)MoveDirection];
                clonedCell.empty = true;
                clonedNeighbour.empty = false;
                clonedNeighbour.white = clonedCell.white;
                return clonedState;
            }
            else
            {
                return null;
            }
        }
        Cell[] GenerateCapturedState(Cell cell, Cell[] initialState, bool left)
        {
            if (cell == null)
            {
                return null;
            }
            if (cell.CapturePossible(left))
            {
                
                Cell[] clonedState = CellMath.DeepCloneCellArray(initialState);
                Cell clonedCell = clonedState[cell.index];

                Direction CaptureDirection =
                    CellMath.DirectionFromColorAndSide(clonedCell.white, left);

                Cell clonedNeighbour = clonedCell.Neighbours[(int)CaptureDirection];
                Cell clonedNeiboursNeighbour = clonedNeighbour.Neighbours[(int)CaptureDirection];

                clonedCell.empty = true;
                clonedNeighbour.empty = true;
                clonedNeiboursNeighbour.empty = false;
                clonedNeiboursNeighbour.white = clonedCell.white;
                return clonedState;
            }
            else
            {
                return null;
            }
        }
    }
}