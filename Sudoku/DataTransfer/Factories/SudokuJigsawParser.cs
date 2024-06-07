namespace DataTransfer.Factories
{
    internal class SudokuJigsawParser : ISudokuParser
    {
        public Sudoku Parse(string sudokuData)
        {
            // Remove the prefix if it exists
            const string prefix = "SumoCueV1=";
            if (sudokuData.StartsWith(prefix))
            {
                sudokuData = sudokuData.Substring(prefix.Length);
            }

            var sudoku = new Sudoku
            {
                Grid = new Cell[9, 9]
            };

            var parts = sudokuData.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != 81)
            {
                throw new ArgumentException("Invalid Jigsaw Sudoku data. The data must contain exactly 81 parts.");
            }

            for (int i = 0; i < parts.Length; i++)
            {
                var segments = parts[i].Split('J');
                if (segments.Length != 2) continue;

                int value = int.Parse(segments[0]);
                int field = int.Parse(segments[1]);

                int row = i / 9;
                int col = i % 9;

                sudoku.Grid[row, col] = new Cell
                {
                    Value = value,
                    Field = field,
                    Auxiliaries = new int[] { }
                };
            }

            return sudoku;
        }
    }
}
