namespace GameLibrary.Validators
{
    internal class RowValidator : ValidatorDecorator
    {
        public RowValidator(IValidator validator) : base(validator) { }
        
        public override bool ValidateCell(ICell cell, ISudoku sudoku, int horizontalPosition, int verticalPosition)
        {
            return ValidateRow(cell, sudoku, horizontalPosition, verticalPosition) &&
                   ValidateColumn(cell, sudoku, horizontalPosition, verticalPosition);
        }

        private static bool ValidateRow(ICell cell, ISudoku sudoku, int horizontalPosition, int verticalPosition)
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

        private static bool ValidateColumn(ICell cell, ISudoku sudoku, int horizontalPosition, int verticalPosition)
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
