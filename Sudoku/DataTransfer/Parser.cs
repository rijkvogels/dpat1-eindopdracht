using DataTransfer.Factories;
using GameLibrary;
using GameLibrary.Enumerations;

namespace DataTransfer
{
    public static class Parser
    {
        private const int currentPuzzle = 2;

        private static readonly string[] puzzles =
        [
            "puzzle.4x4",
            "puzzle.6x6",
            "puzzle.9x9",
            "puzzle.jigsaw",
            "puzzle.samurai",
            "puzzle2.4x4",
            "puzzle2.6x6",
            "puzzle2.9x9",
            "puzzle2.jigsaw",
            "puzzle2.samuari",
            "puzzle3.4x4",
            "puzzle3.6x6",
            "puzzle3.9x9",
            "puzzle3.jigsaw",
            "puzzle3.samuari",
        ];

        public static IGame Create()
        {
            ISudoku sudoku;

            (string? sudokuData, SudokuType? sudokuType) = new Reader().Read(puzzles[currentPuzzle]);

            if (sudokuType.HasValue && sudokuData is not null)
            {
                ISudokuParserFactory parser = SudokuParserFactory.GetParser(sudokuType.Value);
                sudoku = parser.Parse(sudokuData, sudokuType.Value);

                return new Game(sudoku);
            }

            throw new ArgumentNullException("Sudoku is missing values.");
        }
    }
}
