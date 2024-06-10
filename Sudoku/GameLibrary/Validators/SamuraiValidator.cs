namespace GameLibrary.Validators
{
    internal class SamuraiValidator : ValidatorDecorator
    {
        public SamuraiValidator(IValidator validator) : base(validator) { }
        
        public override bool ValidateCell(ICell cell, ISudoku sudoku, int horizontalPosition, int verticalPosition)
        {
            // If an earlier validator has returned false we can short-circuit this validator.
            if (!base.ValidateCell(cell, sudoku, horizontalPosition, verticalPosition))
                return false;

            throw new NotImplementedException();
        }
    }
}
