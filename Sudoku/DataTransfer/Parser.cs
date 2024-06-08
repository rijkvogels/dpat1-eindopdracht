using DataTransfer.Factories;
using GameLibrary;

namespace DataTransfer
{
    public static class Parser
    {
        private const int currentPuzzle = 4;

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

            var (sudokuData, sudokuType) = new Reader().Read(puzzles[currentPuzzle]);

            if (sudokuType.HasValue && sudokuData is not null)
            {
                ISudokuParser parser = SudokuParserFactory.GetParser(sudokuType.Value);
                sudoku = parser.Parse(sudokuData);

                return new Game(sudoku, sudokuType.Value);
            }

            throw new ArgumentNullException("Sudoku is missing values.");
        }
    }
}
