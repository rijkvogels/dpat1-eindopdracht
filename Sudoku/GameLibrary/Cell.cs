using GameLibrary.Enumerations;
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

        public bool Validate(ISudoku sudoku, int VerticalPosition, int HorizontalPosition)
        {
            IValidator validator = new BaseValidator();

            validator = new GridValidator(validator);

            if (sudoku.Type == SudokuType.Sudoku9x9 || sudoku.Type == SudokuType.Sudoku6x6 || sudoku.Type == SudokuType.Sudoku4x4 || sudoku.Type == SudokuType.SudokuJigsaw)
            {
                validator = new RowValidator(validator);
            }
            
            if (sudoku.Type == SudokuType.SudokuSamurai)
            {
                validator = new SamuraiValidator(validator);
            }

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
