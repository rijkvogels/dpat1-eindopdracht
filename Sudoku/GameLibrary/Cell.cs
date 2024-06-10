using GameLibrary.Validators;

namespace GameLibrary
{
    public class Cell : ICell
    {
        public int Value { get; set; }
        public int Field { get; private set; }
        public int[] Auxiliaries { get; set; }

        public Cell(int value, int field) {
            this.Value = value;
            this.Field = field;

            this.Auxiliaries = [];
        }

        public bool Validate(ISudoku sudoku, int HorizontalPosition, int VerticalPosition)
        {
            IValidator validator = new BaseValidator();

            // TODO: Wrap with additional validators based on the sudoku type.

            return validator.ValidateCell(this, sudoku, HorizontalPosition, VerticalPosition);
        }
    }

    public interface ICell
    {
        int Value { get; set; }
        int Field { get; }
        int[] Auxiliaries { get; set; }

        bool Validate(ISudoku sudoku, int HorizontalPosition, int VerticalPosition);
    }
}
