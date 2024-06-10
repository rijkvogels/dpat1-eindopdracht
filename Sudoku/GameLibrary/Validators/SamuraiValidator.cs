namespace GameLibrary.Validators
{
    public class SamuraiValidator : ValidatorDecorator
    {
        public SamuraiValidator(IValidator validator) : base(validator) { }

        public override bool ValidateCell(ICell cell, ISudoku sudoku, int horizontalPosition, int verticalPosition)
        {
            // If an earlier validator has returned false, we can short-circuit this validator.
            if (!base.ValidateCell(cell, sudoku, horizontalPosition, verticalPosition))
                return false;

            // Instead of Validating the entire Sudoku we only Validate the Subgrid the current cell belongs to.
            return ValidateRowInSubGrid(cell, sudoku, horizontalPosition, verticalPosition) &&
                   ValidateColumnInSubGrid(cell, sudoku, horizontalPosition, verticalPosition);
        }

        private static bool ValidateRowInSubGrid(ICell cell, ISudoku sudoku, int horizontalPosition, int verticalPosition)
        {
            (_, int startCol) = GetSubGridPosition(horizontalPosition, verticalPosition);

            for (int col = startCol; col < startCol + 9; col++)
            {
                if (col != horizontalPosition && sudoku.Grid[verticalPosition, col] != null && sudoku.Grid[verticalPosition, col].Value == cell.Value)
                {
                    return false;
                }
            }
            return true;
        }

        private static bool ValidateColumnInSubGrid(ICell cell, ISudoku sudoku, int horizontalPosition, int verticalPosition)
        {
            (int startRow, _) = GetSubGridPosition(horizontalPosition, verticalPosition);

            for (int row = startRow; row < startRow + 9; row++)
            {
                if (row != verticalPosition && sudoku.Grid[row, horizontalPosition] != null && sudoku.Grid[row, horizontalPosition].Value == cell.Value)
                {
                    return false;
                }
            }
            return true;
        }

        private static (int, int) GetSubGridPosition(int horizontalPosition, int verticalPosition)
        {
            // Determine the starting coordinates of the 5 9x9 Grids.
            if (horizontalPosition < 9 && verticalPosition < 9) return (0, 0); // Top-left
            if (horizontalPosition >= 12 && verticalPosition < 9) return (0, 12); // Top-right
            if (horizontalPosition >= 6 && horizontalPosition < 15 && verticalPosition >= 6 && verticalPosition < 15) return (6, 6); // Center
            if (horizontalPosition < 9 && verticalPosition >= 12) return (12, 0); // Bottom-left
            if (horizontalPosition >= 12 && verticalPosition >= 12) return (12, 12); // Bottom-right

            throw new ArgumentOutOfRangeException("Invalid cell position for the Samurai Sudoku.");
        }
    }
}
