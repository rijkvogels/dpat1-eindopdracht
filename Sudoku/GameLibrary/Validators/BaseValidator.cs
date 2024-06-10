namespace GameLibrary.Validators
{
    internal class BaseValidator : IValidator
    {
        public bool ValidateCell(ICell cell, ISudoku sudoku, int HorizontalPosition, int VerticalPosition)
        {
            return false;
        }
    }
}
