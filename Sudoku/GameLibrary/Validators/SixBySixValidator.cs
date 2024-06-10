namespace GameLibrary.Validators
{
    internal class SixBySixValidator : ValidatorDecorator
    {
        public SixBySixValidator(IValidator validator) : base(validator) { }
        
        public override bool ValidateCell(ICell cell, ISudoku sudoku, int horizontalPosition, int verticalPosition)
        {
            throw new NotImplementedException();
        }
    }
}
