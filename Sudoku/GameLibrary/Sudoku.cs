using GameLibrary.Enumerations;

namespace GameLibrary
{
    public class Sudoku : ISudoku
    {
        public ICell[,] Grid { get; }

        public ViewType ViewType { get; set; }
        public bool IndicationMode { get; set; }

        public Sudoku(ICell[,] grid) {
            this.Grid = grid;

            this.ViewType = ViewType.Note;
            this.IndicationMode = false; // TODO: If we set this to true cells will be validated. Create a function Game to change this value.
        }
    }

    public interface ISudoku
    {
        ICell[,] Grid { get; }
        ViewType ViewType { get; set; }
        bool IndicationMode { get; set; }
    }
}
