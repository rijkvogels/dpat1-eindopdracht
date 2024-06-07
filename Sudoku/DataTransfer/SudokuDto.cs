namespace DataTransfer
{
    public class Sudoku
    {
        public required Cell[,] Grid { get; set; }
        public bool HelpMode { get; set; }
        public bool CheckMode { get; set; }
    }

    public class Cell
    {
        public int Value { get; set; }
        public int Field { get; set; }
        public required int[] Auxiliaries { get; set; }
    }
}
