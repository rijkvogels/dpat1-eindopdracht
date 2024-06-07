namespace DataTransfer.Factories
{
    internal class Sudoku6x6Parser : ISudokuParser
    {
        public Sudoku Parse(string sudokuData)
        {
            if (sudokuData.Length != 36)
            {
                throw new ArgumentOutOfRangeException("Invalid Sudoku data. The data must contain exactly 36 characters.");
            }

            var sudoku = new Sudoku
            {
                Grid = new Cell[6, 6]
            };

            for (int i = 0; i < 36; i++)
            {
                int row = i / 6;
                int col = i % 6;
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
            // Logic to determine the field, for a 6X6 Sudoku it's 2X3.
            return (row / 2) * 3 + (col / 3);
        }
    }
}
