namespace GameLibrary.Validators
{
    internal abstract class ValidatorDecorator : IValidator
    {
        protected IValidator _validator;

        public ValidatorDecorator(IValidator validator)
        {
            _validator = validator;
        }

        public virtual bool ValidateCell(ICell cell, ISudoku sudoku, int horizontalPosition, int verticalPosition)
        {
            return _validator.ValidateCell(cell, sudoku, horizontalPosition, verticalPosition);
        }
    }
}