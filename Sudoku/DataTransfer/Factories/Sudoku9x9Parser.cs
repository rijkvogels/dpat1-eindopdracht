using DataTransfer.Factories;
using DataTransfer;

public class Sudoku9x9Parser : ISudokuParser
{
    public Sudoku Parse(string sudokuData)
    {
        if (sudokuData.Length != 81)
        {
            throw new ArgumentOutOfRangeException("Invalid Sudoku data. The data must contain exactly 81 characters.");
        }

        var sudoku = new Sudoku
        {
            Grid = new Cell[9, 9]
        };

        for (int i = 0; i < 81; i++)
        {
            int row = i / 9;
            int col = i % 9;
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
        // Logic to determine the field, for a 9X9 Sudoku it's 3X3.
        return (row / 3) * 3 + (col / 3);
    }
}
