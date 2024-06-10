namespace GameLibrary.Validators
{
    public interface IValidator
    {
        bool ValidateCell(ICell cell, ISudoku sudoku, int horizontalPosition, int verticalPosition);
    }
}
