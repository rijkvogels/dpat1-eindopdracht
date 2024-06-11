using GameLibrary.Enumerations;

namespace DataTransfer.Factories
{
    public static class SudokuParserFactory
    {
        public static ISudokuParserFactory GetParser(SudokuType sudokuType)
        {
            return sudokuType switch
            {
                SudokuType.Sudoku9x9 => new NineByNineParserFactory(),
                SudokuType.Sudoku6x6 => new SixBySixParserFactory(),
                SudokuType.Sudoku4x4 => new FourByFourParserFactory(),
                SudokuType.SudokuJigsaw => new JigsawParserFactory(),
                SudokuType.SudokuSamurai => new SamuraiParserFactory(),
                _ => throw new ArgumentException("Unknown Sudoku type.")
            };
        }
    }
}
