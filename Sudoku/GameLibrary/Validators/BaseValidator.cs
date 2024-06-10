namespace GameLibrary.Validators
{
    public class BaseValidator : IValidator
    {
        public bool ValidateCell(ICell cell, ISudoku sudoku, int HorizontalPosition, int VerticalPosition)
        {
            // Validate if the Cell Value is between 1 and 9.
            if (cell.Value < 1 || cell.Value > 9)
            {
                return false;
            }

            return true;
        }
    }
}
