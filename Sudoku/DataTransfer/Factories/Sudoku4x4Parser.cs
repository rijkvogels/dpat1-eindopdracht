using GameLibrary;

namespace DataTransfer.Factories
{
    internal class Sudoku4x4Parser : ISudokuParser
    {
        public ISudoku Parse(string sudokuData)
        {
            if (sudokuData.Length != 16)
            {
                throw new ArgumentOutOfRangeException("Invalid Sudoku data. The data must contain exactly 16 characters.");
            }

            var grid = new ICell[4, 4];

            for (int i = 0; i < 16; i++)
            {
                int row = i / 4;
                int col = i % 4;

                grid[row, col] = new Cell(sudokuData[i] - '0', GetField(row, col));
            }

            return new Sudoku(grid);
        }

        private static int GetField(int row, int col)
        {
            // Logic to determine the field, for a 4X4 Sudoku it's 2X2.
            return (row / 2) * 2 + (col / 2);
        }
    }
}
