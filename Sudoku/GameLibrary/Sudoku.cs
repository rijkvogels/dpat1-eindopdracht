using GameLibrary.Enumerations;

namespace GameLibrary
{
    public class Sudoku : ISudoku
    {
        public ICell[,] Grid { get; }
        public SudokuType Type { get; }

        public ViewType ViewType { get; set; }
        public bool ValidationMode { get; set; }

        public Sudoku(ICell[,] grid, SudokuType type) {
            this.Grid = grid;
            this.Type = type;

            this.ViewType = ViewType.Definite;
            this.ValidationMode = false;
        }
    }

    public interface ISudoku
    {
        ICell[,] Grid { get; }
        SudokuType Type { get; }
        ViewType ViewType { get; set; }
        bool ValidationMode { get; set; }
    }
}
