using DataTransfer;
using DataTransfer.Factories;

public class SudokuSamuraiParser : ISudokuParser
{
    public Sudoku Parse(string sudokuData)
    {
        var grids = sudokuData.Split('\n');
        if (grids.Length != 5)
        {
            throw new ArgumentException("Invalid Samurai Sudoku data. The data must contain exactly 5 grids.");
        }

        var sudoku = new Sudoku
        {
            Grid = new Cell[21, 21]
        };

        var gridPositions = new (int rowOffset, int colOffset)[]
        {
            (0, 0),
            (0, 12),
            (6, 6),
            (12, 0),
            (12, 12)
        };

        for (int g = 0; g < 5; g++)
        {
            int[,] grid = Parse9x9Grid(grids[g]);
            var (rowOffset, colOffset) = gridPositions[g];

            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    sudoku.Grid[row + rowOffset, col + colOffset] = new Cell
                    {
                        Value = grid[row, col],
                        Field = GetField(row + rowOffset, col + colOffset),
                        Auxiliaries = []
                    };
                }
            }
        }

        return sudoku;
    }

    private int[,] Parse9x9Grid(string gridData)
    {
        if (gridData.Length != 81)
        {
            throw new ArgumentException("Invalid grid data. Each grid must contain exactly 81 characters.");
        }

        var grid = new int[9, 9];
        for (int i = 0; i < 81; i++)
        {
            int row = i / 9;
            int col = i % 9;
            grid[row, col] = gridData[i] - '0';
        }

        return grid;
    }

    private static int GetField(int row, int col)
    {
        // Logic to determine the field for Samurai Sudoku
        // Needs specific logic based on the puzzle's design
        return 0; // Placeholder logic
    }
}
