using NUnit.Framework;
using GameLibrary;
using GameLibrary.Validators;
using Moq;
using GameLibrary.Enumerations;

namespace Tests
{
    public class SamuraiValidatorTests
    {
        private Mock<IValidator> _baseValidatorMock;
        private ISudoku _sampleSudoku;

        [SetUp]
        public void Setup()
        {
            _baseValidatorMock = new Mock<IValidator>();
            _baseValidatorMock.Setup(v => v.ValidateCell(It.IsAny<ICell>(), It.IsAny<ISudoku>(), It.IsAny<int>(), It.IsAny<int>())).Returns(true);

            _sampleSudoku = CreateSampleSudoku();
        }

        [Test]
        public void SamuraiValidator_ShouldReturnFalse_WhenDuplicateInRowInSubGrid()
        {
            // Arrange.
            ICell cell = _sampleSudoku.Grid[0, 0];
            cell.Value = 5;

            SamuraiValidator samuraiValidator = new(_baseValidatorMock.Object);

            // Act.
            bool result = samuraiValidator.ValidateCell(cell, _sampleSudoku, 0, 0);

            // Assert.
            Assert.That(result, Is.False);
        }

        [Test]
        public void SamuraiValidator_ShouldReturnFalse_WhenDuplicateInColumnInSubGrid()
        {
            // Arrange.
            var cell = _sampleSudoku.Grid[0, 0];
            cell.Value = 5;
            _sampleSudoku.Grid[1, 0].Value = 5; // Duplicate in the same column.

            var samuraiValidator = new SamuraiValidator(_baseValidatorMock.Object);

            // Act.
            var result = samuraiValidator.ValidateCell(cell, _sampleSudoku, 0, 0);

            // Assert.
            Assert.That(result, Is.False);
        }

        [Test]
        public void SamuraiValidator_ShouldReturnTrue_WhenNoDuplicatesInSubGrid()
        {
            // Arrange.
            var cell = _sampleSudoku.Grid[0, 0];
            cell.Value = 4;

            var samuraiValidator = new SamuraiValidator(_baseValidatorMock.Object);

            // Act.
            var result = samuraiValidator.ValidateCell(cell, _sampleSudoku, 0, 0);

            // Assert.
            Assert.That(result, Is.True);
        }

        private static ISudoku CreateSampleSudoku()
        {
            ICell[,] grid = new ICell[21, 21];
            for (int i = 0; i < 21; i++)
            {
                for (int j = 0; j < 21; j++)
                {
                    grid[i, j] = new Cell(0, GetField(i, j));
                }
            }
            grid[0, 1].Value = 5;

            return new Sudoku(grid, SudokuType.SudokuSamurai);
        }

        private static int GetField(int row, int col)
        {
            return (row / 3) * 3 + (col / 3);
        }
    }
}
