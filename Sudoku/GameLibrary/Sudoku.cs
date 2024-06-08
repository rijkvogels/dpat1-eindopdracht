namespace GameLibrary
{
    public class Sudoku : ISudoku
    {
        public ICell[,] Grid { get; }

        public bool HelpMode { get; set; }
        public bool CheckMode { get; set; }

        public Sudoku(ICell[,] grid) {
            this.Grid = grid;

            this.HelpMode = false;
            this.CheckMode = false;
        }
    }

    public interface ISudoku
    {
        ICell[,] Grid { get; }
        bool HelpMode { get; set; }
        bool CheckMode { get; set; }
    }
}
