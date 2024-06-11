using NUnit.Framework;
using GameLibrary;
using GameLibrary.Enumerations;
using DataTransfer.Factories;
using System;

namespace Tests
{
    public class ParserFactoryTests
    {
        [Test]
        public void TestNineByNineParserFactory_ValidData()
        {
            // Arrange.
            NineByNineParserFactory factory = new();
            string validData = "000302000090705060003090400450000078008000500730000094005020100040108030000907000";

            // Act.
            ISudoku sudoku = factory.Parse(validData, SudokuType.Sudoku9x9);

            // Assert.
            Assert.That(sudoku, Is.Not.Null);
            Assert.That(sudoku.Type, Is.EqualTo(SudokuType.Sudoku9x9));
        }

        [Test]
        public void TestNineByNineParserFactory_InvalidDataLength()
        {
            // Arrange.
            NineByNineParserFactory factory = new();
            string invalidData = "12345678912345678912345678912345678912345678912345678912345678912345678912345678";

            // Act & Assert.
            Assert.Throws<ArgumentOutOfRangeException>(() => factory.Parse(invalidData, SudokuType.Sudoku9x9));
        }

        [Test]
        public void TestJigsawParserFactory_ValidData()
        {
            // Arrange.
            JigsawParserFactory factory = new();
            string validData = "0J0=0J0=0J0=0J1=7J1=4J1=0J2=0J2=0J2=0J0=5J0=0J0=7J0=0J1=0J2=4J2=0J2=0J2=0J3=0J0=0J0=0J1=8J1=0J1=0J2=7J2=0J4=0J3=8J3=0J5=0J5=5J1=0J5=0J5=0J4=6J4=7J3=0J3=1J3=9J5=0J1=5J5=8J4=0J4=2J4=2J3=0J3=0J3=0J5=4J5=0J5=0J4=5J4=0J4=0J6=9J6=0J6=0J6=1J7=0J8=0J8=0J8=0J8=0J6=0J6=8J6=0J7=0J7=7J7=0J8=1J8=0J8=0J6=0J6=0J7=4J7=6J7=0J7=0J7=0J8=0J8";

            // Act.
            ISudoku sudoku = factory.Parse(validData, SudokuType.SudokuJigsaw);

            // Assert.
            Assert.That(sudoku, Is.Not.Null);
            Assert.That(sudoku.Type, Is.EqualTo(SudokuType.SudokuJigsaw));
        }

        [Test]
        public void TestJigsawParserFactory_InvalidDataLength()
        {
            // Arrange.
            JigsawParserFactory factory = new();
            string invalidData = "12345678912345678912345678912345678912345678912345678912345678912345678912345678";

            // Act & Assert.
            Assert.Throws<ArgumentException>(() => factory.Parse(invalidData, SudokuType.SudokuJigsaw));
        }

        [Test]
        public void TestFourByFourParserFactory_ValidData()
        {
            // Arrange.
            FourByFourParserFactory factory = new();
            string validData = "0040003140203200";

            // Act.
            ISudoku sudoku = factory.Parse(validData, SudokuType.Sudoku4x4);

            // Assert.
            Assert.That(sudoku, Is.Not.Null);
            Assert.That(sudoku.Type, Is.EqualTo(SudokuType.Sudoku4x4));
        }

        [Test]
        public void TestFourByFourParserFactory_InvalidDataLength()
        {
            // Arrange.
            FourByFourParserFactory factory = new();
            string invalidData = "12345678912345678912345678912345678912345678912345678912345678912345678912345678";

            // Act & Assert.
            Assert.Throws<ArgumentOutOfRangeException>(() => factory.Parse(invalidData, SudokuType.Sudoku4x4));
        }
    }
}
