namespace GameLibrary.Validators
{
    internal class NineByNineValidator : ValidatorDecorator
    {
        public NineByNineValidator(IValidator validator) : base(validator) { }
        
        public override bool ValidateCell(ICell cell, ISudoku sudoku, int horizontalPosition, int verticalPosition)
        {
            throw new NotImplementedException();
        }
    }
}
