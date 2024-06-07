namespace DataTransfer.Factories
{
    internal class Sudoku4x4Parser : ISudokuParser
    {
        public Sudoku Parse(string sudokuData)
        {
            if (sudokuData.Length != 16)
            {
                throw new ArgumentOutOfRangeException("Invalid Sudoku data. The data must contain exactly 16 characters.");
            }

            Sudoku sudoku = new() { Grid = new Cell[4, 4] };

            for (int i = 0; i < 16; i++)
            {
                int row = i / 4;
                int col = i % 4;
                sudoku.Grid[row, col] = new Cell
                {
                    Value = sudokuData[i] - '0',
                    Field = GetField(row, col),
                    Auxiliaries = []
                };
            }

            return sudoku;
        }

        private static int GetField(int row, int col)
        {
            // Logic to determine the field, for a 4X4 Sudoku it's 2X2.
            return (row / 2) * 2 + (col / 2);
        }
    }
}
