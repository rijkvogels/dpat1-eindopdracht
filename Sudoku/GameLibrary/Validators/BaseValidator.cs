namespace GameLibrary.Validators
{
    internal class BaseValidator : IValidator
    {
        public bool ValidateCell(ICell cell, ISudoku sudoku, int HorizontalPosition, int VerticalPosition)
        {
            // Validate if the Grid is valid.
            foreach (var sudokuCell in sudoku.Grid)
            {
                // Check if the Cell has the same Field and the same Value but is not the same Cell being validated.
                if (sudokuCell.Field == cell.Field && sudokuCell.Value == cell.Value && sudokuCell != cell)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
