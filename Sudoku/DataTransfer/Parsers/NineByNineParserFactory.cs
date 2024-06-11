using GameLibrary;
using GameLibrary.Enumerations;

namespace DataTransfer.Factories
{
    public class NineByNineParserFactory : ISudokuParserFactory
    {
        public ISudoku Parse(string sudokuData, SudokuType sudokuType)
        {
            if (sudokuData.Length != 81)
            {
                throw new ArgumentOutOfRangeException("Invalid Sudoku data. The data must contain exactly 81 characters.");
            }

            ICell[,] grid = new ICell[9, 9];

            for (int i = 0; i < 81; i++)
            {
                int row = i / 9;
                int col = i % 9;

                grid[row, col] = new Cell(sudokuData[i] - '0', GetField(row, col));
            }

            return new Sudoku(grid, sudokuType);
        }

        private static int GetField(int row, int col)
        {
            // Logic to determine the field, for a 9X9 Sudoku it's 3X3.
            return (row / 3) * 3 + (col / 3);
        }
    }
}
