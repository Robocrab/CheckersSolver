using System.Windows.Forms;
using System.Drawing;
using System;
namespace CheckersSolver
{
    public partial class MainClass : Form
    {
        //MAKE UI HANDLER PRIVATE
        static UIHandler UI;
        public static Cell[] displayedCells { get; set; }
        public static int boardSize { get; private set; }
        public MainClass()
        {
            InitializeComponent();
            UI = new UIHandler(pictureBox, resultLabel);
        }
        private void SizeSelectionComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            int size = -1;
            if (SizeSelectionComboBox.SelectedIndex == 0)
            {
                size = 4;
            }
            else if (SizeSelectionComboBox.SelectedIndex == 1)
            {
                size = 6;
            }
            else if (SizeSelectionComboBox.SelectedIndex == 2)
            {
                size = 8;
            }
            UI.OnSizeChosen(size);
            boardSize = size;
            displayedCells = new Cell[size * size / 2];
            CellMath.BuildCellArray(displayedCells);
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            var mouseEventArgs = e as MouseEventArgs;
            Point SelectedCellPos = UI.CellPosFromMousePos(mouseEventArgs.Location);
            if (CellMath.PositionPlayable(SelectedCellPos, boardSize)) {
                int SelectedCellIndex = CellMath.PlayableCellIndexFromPos(SelectedCellPos, boardSize);

                displayedCells[SelectedCellIndex].NextState();
                UI.UpdateCell(SelectedCellPos);
            }
        }
        private void solveButton_Click(object sender, EventArgs e)
        {
            Cell[] InitialState = CellMath.DeepCloneCellArray(displayedCells);

            Solver solver = new Solver(displayedCells, firstTurnCheckBox.Checked);
            bool whiteDefinetlyWin = solver.Solve(visualizeCheckBox.Checked);

            //RETURN TO INITIAL DISPLAY STATE
            UI.DisplayResult(whiteDefinetlyWin);
            displayedCells = InitialState;
            UI.UpdateBoard();
        }
        public static void UpdateDisplay()
        {
            UI.UpdateBoard();
        }
    }
}