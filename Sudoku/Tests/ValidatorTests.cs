using NUnit.Framework;
using GameLibrary;
using GameLibrary.Validators;
using GameLibrary.Enumerations;

namespace Tests
{
    public class ValidatorTests
    {
        private ISudoku sudoku;

        [SetUp]
        public void Setup()
        {
            sudoku = new Sudoku(new ICell[9, 9], SudokuType.Sudoku9x9);
        }

        [Test]
        public void TestGridValidator()
        {
            IValidator gridValidator = new GridValidator(new BaseValidator());

            // Create a valid cell
            ICell validCell = new Cell(5, 1);
            sudoku.Grid[0, 0] = validCell;

            // Create an invalid cell with a duplicate value in the same row
            ICell invalidCell = new Cell(5, 1);
            sudoku.Grid[0, 1] = invalidCell;

            Assert.That(gridValidator.ValidateCell(invalidCell, sudoku, 0, 1), Is.False);

            // Create another invalid cell with a duplicate value in the same column
            invalidCell = new Cell(5, 1);
            sudoku.Grid[1, 0] = invalidCell;

            Assert.That(gridValidator.ValidateCell(invalidCell, sudoku, 1, 0), Is.False);

            // Create a valid cell with a unique value
            ICell anotherValidCell = new Cell(3, 1);
            sudoku.Grid[1, 1] = anotherValidCell;

            Assert.That(gridValidator.ValidateCell(anotherValidCell, sudoku, 1, 1), Is.True);
        }

        [Test]
        public void TestValueValidator()
        {
            IValidator valueValidator = new BaseValidator();

            // Create a valid cell with a value between 1 and 9
            ICell validCell = new Cell(5, 1);
            Assert.IsTrue(valueValidator.ValidateCell(validCell, sudoku, 0, 0));

            // Create an invalid cell with a value outside the range [1, 9]
            ICell invalidCell = new Cell(10, 1);
            Assert.IsFalse(valueValidator.ValidateCell(invalidCell, sudoku, 0, 0));

            // Create another invalid cell with a value outside the range [1, 9]
            invalidCell = new Cell(0, 1);
            Assert.IsFalse(valueValidator.ValidateCell(invalidCell, sudoku, 0, 0));
        }
    }
}
