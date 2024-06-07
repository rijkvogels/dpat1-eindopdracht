namespace DataTransfer.Factories
{
    internal class SudokuJigsawParser : ISudokuParser
    {
        public Sudoku Parse(string sudokuData)
        {
            if (sudokuData.StartsWith("SumoCueV1="))
            {
                sudokuData = sudokuData["SumoCueV1=".Length..];
            }

            Sudoku sudoku = new() { Grid = new Cell[9, 9] };

            string[] parts = sudokuData.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != 81)
            {
                throw new ArgumentException("Invalid Jigsaw Sudoku data. The data must contain exactly 81 parts.");
            }

            for (int i = 0; i < parts.Length; i++)
            {
                string[] segments = parts[i].Split('J');
                if (segments.Length != 2) continue;

                int value = int.Parse(segments[0]);
                int field = int.Parse(segments[1]);

                int row = i / 9;
                int col = i % 9;

                sudoku.Grid[row, col] = new Cell
                {
                    Value = value,
                    Field = field,
                    Auxiliaries = []
                };
            }

            return sudoku;
        }
    }
}
