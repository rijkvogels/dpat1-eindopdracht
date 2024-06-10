namespace GameLibrary.Validators
{
    internal class SamuraiValidator : ValidatorDecorator
    {
        public SamuraiValidator(IValidator validator) : base(validator) { }
        
        public override bool ValidateCell(ICell cell, ISudoku sudoku, int horizontalPosition, int verticalPosition)
        {
            throw new NotImplementedException();
        }
    }
}
