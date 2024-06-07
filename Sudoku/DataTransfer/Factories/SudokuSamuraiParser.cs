using DataTransfer;
using DataTransfer.Factories;

public class SudokuSamuraiParser : ISudokuParser
{
    public Sudoku Parse(string sudokuData)
    {
        // Make sure we remove all the unused data.
        var grids = sudokuData.Replace("\r", "").Split('\n');
        if (grids.Length != 5)
        {
            throw new ArgumentException("Invalid Samurai Sudoku data. The data must contain exactly 5 grids.");
        }

        Sudoku sudoku = new() { Grid = new Cell[21, 21] };

        (int rowOffset, int colOffset)[] gridPositions =
        [
            (0, 0),
            (0, 12),
            (6, 6),
            (12, 0),
            (12, 12)
        ];

        for (int g = 0; g < 5; g++)
        {
            int[,] grid = Parse9x9Grid(grids[g]);
            (int rowOffset, int colOffset) = gridPositions[g];

            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    sudoku.Grid[row + rowOffset, col + colOffset] = new Cell
                    {
                        Value = grid[row, col],
                        Field = GetField(row + rowOffset, col + colOffset, g),
                        Auxiliaries = []
                    };
                }
            }
        }

        return sudoku;
    }

    private static int[,] Parse9x9Grid(string gridData)
    {
        if (gridData.Length != 81)
        {
            throw new ArgumentException("Invalid grid data. Each grid must contain exactly 81 characters.");
        }

        int[,] grid = new int[9, 9];
        for (int i = 0; i < 81; i++)
        {
            int row = i / 9;
            int col = i % 9;
            grid[row, col] = gridData[i] - '0';
        }

        return grid;
    }

    private static int GetField(int row, int col, int grid)
    {
        // Logic to determine the field, for a 9X9 Sudoku it's 3X3. We paste the grid number before the fieldData to make sure we do not get duplicates.
        return grid + Int32.Parse(grid.ToString() + ((row / 3) * 3 + (col / 3)).ToString());
    }
}
