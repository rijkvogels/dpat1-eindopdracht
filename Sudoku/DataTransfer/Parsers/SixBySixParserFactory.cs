using GameLibrary;
using GameLibrary.Enumerations;

namespace DataTransfer.Factories
{
    public class SixBySixParserFactory : ISudokuParserFactory
    {
        public ISudoku Parse(string sudokuData, SudokuType sudokuType)
        {
            if (sudokuData.Length != 36)
            {
                throw new ArgumentOutOfRangeException("Invalid Sudoku data. The data must contain exactly 36 characters.");
            }

            ICell[,] grid = new ICell[6, 6];

            for (int i = 0; i < 36; i++)
            {
                int row = i / 6;
                int col = i % 6;

                grid[row, col] = new Cell(sudokuData[i] - '0', GetField(row, col));
            }

            return new Sudoku(grid, sudokuType);
        }

        private static int GetField(int row, int col)
        {
            // Logic to determine the field, for a 6X6 Sudoku it's 2X3.
            return (row / 2) * 3 + (col / 3);
        }
    }
}
