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
            } else
            {
                throw new ArgumentNullException("Sudoku is missing values.");
            }

            int rows = sudoku.Grid.GetLength(0);
            int cols = sudoku.Grid.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    ICell? cell = sudoku.Grid[i, j];
                    if (cell is not null)
                    {
                        Console.Write($"({cell.Value}, {cell.Field}) ");
                    }
                    else
                    {
                        Console.Write("( , ) ");
                    }

                }
                Console.WriteLine();
            }

            return new Game(sudoku, puzzles[currentPuzzle]);
        }
    }
}
