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
            // Arrange
            GridValidator gridValidator = new(new BaseValidator());

            // Act & Assert
            // Test with a valid cell
            ICell validCell = new Cell(5, 1);
            sudoku.Grid[0, 0] = validCell;
            Assert.That(gridValidator.ValidateCell(validCell, sudoku, 0, 0), Is.True);

            // Test with an invalid cell (duplicate value in the same row)
            ICell invalidCellInRow = new Cell(5, 1);
            sudoku.Grid[0, 1] = invalidCellInRow;
            Assert.That(gridValidator.ValidateCell(invalidCellInRow, sudoku, 0, 1), Is.False);

            // Test with an invalid cell (duplicate value in the same column)
            ICell invalidCellInColumn = new Cell(5, 1);
            sudoku.Grid[1, 0] = invalidCellInColumn;
            Assert.That(gridValidator.ValidateCell(invalidCellInColumn, sudoku, 1, 0), Is.False);

            // Test with another valid cell (unique value)
            ICell anotherValidCell = new Cell(3, 1);
            sudoku.Grid[1, 1] = anotherValidCell;
            Assert.That(gridValidator.ValidateCell(anotherValidCell, sudoku, 1, 1), Is.True);
        }

        [Test]
        public void TestValueValidator()
        {
            // Arrange.
            BaseValidator valueValidator = new();

            // Act & Assert.
            // Test with a valid cell (value between 1 and 9).
            ICell validCell = new Cell(5, 1);
            bool isValid = valueValidator.ValidateCell(validCell, sudoku, 0, 0);
            Assert.That(isValid, Is.True);

            // Test with an invalid cell (value outside the range [1, 9]).
            ICell invalidCellOutOfRangeHigh = new Cell(10, 1);
            bool isInvalidHigh = valueValidator.ValidateCell(invalidCellOutOfRangeHigh, sudoku, 0, 0);
            Assert.That(isInvalidHigh, Is.False);

            // Test with another invalid cell (value outside the range [1, 9]).
            ICell invalidCellOutOfRangeLow = new Cell(0, 1);
            bool isInvalidLow = valueValidator.ValidateCell(invalidCellOutOfRangeLow, sudoku, 0, 0);
            Assert.That(isInvalidLow, Is.False);
        }
    }
}
