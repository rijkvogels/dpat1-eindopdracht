using GameLibrary.Enumerations;

namespace GameLibrary
{
    public class Sudoku : ISudoku
    {
        public ICell[,] Grid { get; }

        public ViewType ViewType { get; set; }
        public bool ValidationMode { get; set; }

        public Sudoku(ICell[,] grid) {
            this.Grid = grid;

            this.ViewType = ViewType.Definite;
            this.ValidationMode = false;
        }
    }

    public interface ISudoku
    {
        ICell[,] Grid { get; }
        ViewType ViewType { get; set; }
        bool ValidationMode { get; set; }
    }
}
