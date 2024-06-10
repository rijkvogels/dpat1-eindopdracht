using NUnit.Framework;
using GameLibrary;
using GameLibrary.Enumerations;
using Moq;
using System.Numerics;

namespace Tests
{
    public class PlayerTests
    {
        private ISudoku _sampleSudoku;
        private IPlayer _player;

        [SetUp]
        public void Setup()
        {
            _sampleSudoku = CreateSampleSudoku();
            _player = new Player(_sampleSudoku);
        }

        [Test]
        public void UpdateCellValue_ShouldUpdateDefiniteValue_WhenViewTypeIsDefinite()
        {
            // Arrange
            var cell = _sampleSudoku.Grid[_player.HorizontalPosition, _player.VerticalPosition];
            var originalValue = cell.Value;
            var newValue = 5;

            // Act
            _player.UpdateCellValue(newValue, ViewType.Definite);

            // Assert
            Assert.That(cell.Value, Is.EqualTo(newValue));
        }

        [Test]
        public void UpdateCellValue_ShouldClearCellValue_WhenValueMatchesCurrentCellValue()
        {
            // Arrange
            var cell = _sampleSudoku.Grid[_player.HorizontalPosition, _player.VerticalPosition];
            var originalValue = cell.Value;

            // Act
            _player.UpdateCellValue(originalValue, ViewType.Definite);

            // Assert
            Assert.That(cell.Value, Is.EqualTo(0));
        }

        [Test]
        public void Move_ShouldMovePlayerUp_WhenDirectionIsUpAndValidMove()
        {
            // Arrange
            var originalHorizontalPosition = _player.HorizontalPosition;
            var originalVerticalPosition = _player.VerticalPosition;

            // Act
            _player.Move(Direction.DOWN, _sampleSudoku);

            // Assert
            Assert.That(_player.HorizontalPosition, Is.EqualTo(originalHorizontalPosition - 1));
        }

        private ISudoku CreateSampleSudoku()
        {
            return new Sudoku(new ICell[9, 9], SudokuType.Sudoku9x9);
        }
    }
}
