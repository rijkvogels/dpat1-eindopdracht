namespace GameLibrary.Validators
{
    internal class GridValidator : ValidatorDecorator
    {
        public GridValidator(IValidator validator) : base(validator) { }

        public override bool ValidateCell(ICell cell, ISudoku sudoku, int horizontalPosition, int verticalPosition)
        {
            // Validate if the Grid has no duplicates.
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
