using GameLibrary;

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
            var (sudokuData, sudokuType) = new Reader().Read(puzzles[currentPuzzle]);

            Console.WriteLine(sudokuData);
            Console.WriteLine(sudokuType);

            return new Game();
        }
    }
}
