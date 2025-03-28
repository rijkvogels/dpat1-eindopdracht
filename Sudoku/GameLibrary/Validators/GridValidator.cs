﻿namespace GameLibrary.Validators
{
    public class GridValidator : ValidatorDecorator
    {
        public GridValidator(IValidator validator) : base(validator) { }

        public override bool ValidateCell(ICell cell, ISudoku sudoku, int horizontalPosition, int verticalPosition)
        {
            // If an earlier validator has returned false we can short-circuit this validator.
            if (!base.ValidateCell(cell, sudoku, horizontalPosition, verticalPosition))
                return false;

            // Validate if the Grid has no duplicates.
            foreach (ICell? sudokuCell in sudoku.Grid)
            {
                // Check if the Cell has the same Field and the same Value but is not the same Cell being validated.
                if (sudokuCell is not null && sudokuCell.Field == cell.Field && sudokuCell.Value == cell.Value && sudokuCell != cell)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
