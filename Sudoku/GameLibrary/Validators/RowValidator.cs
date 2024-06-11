namespace GameLibrary.Validators
{
    public class RowValidator : ValidatorDecorator
    {
        public RowValidator(IValidator validator) : base(validator) { }
        
        public override bool ValidateCell(ICell cell, ISudoku sudoku, int horizontalPosition, int verticalPosition)
        {
            // If an earlier validator has returned false we can short-circuit this validator.
            if (!base.ValidateCell(cell, sudoku, horizontalPosition, verticalPosition))
                return false;

            return ValidateHorizontalRow(cell, sudoku, horizontalPosition, verticalPosition) &&
                   ValidateVerticalRow(cell, sudoku, horizontalPosition, verticalPosition);
        }

        private static bool ValidateHorizontalRow(ICell cell, ISudoku sudoku, int horizontalPosition, int verticalPosition)
        {
            for (int row = 0; row < sudoku.Grid.GetLength(1); row++)
            {
                if (row != horizontalPosition && sudoku.Grid[verticalPosition, row].Value == cell.Value)
                {
                    return false;
                }
            }
            return true;
        }

        private static bool ValidateVerticalRow(ICell cell, ISudoku sudoku, int horizontalPosition, int verticalPosition)
        {
            for (int row = 0; row < sudoku.Grid.GetLength(0); row++)
            {
                if (row != verticalPosition && sudoku.Grid[row, horizontalPosition].Value == cell.Value)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
