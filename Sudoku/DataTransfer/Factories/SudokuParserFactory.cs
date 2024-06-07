using GameLibrary.Enumerations;

namespace DataTransfer.Factories
{
    internal static class SudokuParserFactory
    {
        public static ISudokuParser GetParser(SudokuType sudokuType)
        {
            return sudokuType switch
            {
                SudokuType.Sudoku9x9 => new Sudoku9x9Parser(),
                SudokuType.Sudoku6x6 => new Sudoku6x6Parser(),
                SudokuType.Sudoku4x4 => new Sudoku4x4Parser(),
                SudokuType.SudokuJigsaw => new SudokuJigsawParser(),
                SudokuType.SudokuSamurai => new SudokuSamuraiParser(),
                _ => throw new ArgumentException("Unknown Sudoku type.")
            };
        }
    }
}
