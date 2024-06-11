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
        private Player _player;

        [SetUp]
        public void Setup()
        {
            _sampleSudoku = CreateSampleSudoku();
            _player = new Player(_sampleSudoku);
        }

        [Test]
        public void UpdateCellValue_ShouldUpdateDefiniteValue_WhenViewTypeIsDefinite()
        {
            // Arrange.
            var cell = _sampleSudoku.Grid[_player.HorizontalPosition, _player.VerticalPosition];
            var newValue = 5;

            // Act.
            _player.UpdateCellValue(newValue, ViewType.Definite);

            // Assert.
            Assert.That(cell.Value, Is.EqualTo(newValue));
        }

        [Test]
        public void UpdateCellValue_ShouldClearCellValue_WhenValueMatchesCurrentCellValue()
        {
            // Arrange.
            var cell = _sampleSudoku.Grid[_player.HorizontalPosition, _player.VerticalPosition];
            var originalValue = cell.Value;

            // Act.
            _player.UpdateCellValue(originalValue, ViewType.Definite);

            // Assert.
            Assert.That(cell.Value, Is.EqualTo(0));
        }

        [Test]
        public void Move_ShouldMovePlayerRight_WhenDirectionIsUpAndValidMove()
        {
            // Arrange.
            int originalVerticalPosition = _player.VerticalPosition;

            // Act.
            _player.Move(Direction.RIGHT, _sampleSudoku);

            // Assert.
            Assert.That(_player.VerticalPosition, Is.EqualTo(originalVerticalPosition + 1));
        }

        private static Sudoku CreateSampleSudoku()
        {
            ICell[,] grid = new ICell[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    grid[i, j] = new Cell(0, GetField(i, j));
                }
            }

            return new Sudoku(grid, SudokuType.Sudoku9x9);
        }

        private static int GetField(int row, int col)
        {
            return (row / 3) * 3 + (col / 3);
        }
    }
}
