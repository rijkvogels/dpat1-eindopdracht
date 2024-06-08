using GameLibrary;

namespace FrontEnd.Modules
{
    internal class DefiniteView : IViewType
    {
        public IEnumerable<ColoredString> Show(IGame game)
        {
            var sudoku = game.Sudoku;
            int size = (int)Math.Sqrt(sudoku.Grid.Length);

            for (int row = 0; row < size; row++)
            {
                // Yield the row's Tottom Border.
                for (int col = 0; col < size; col++)
                {
                    ICell? cell = sudoku.Grid[row, col];
                    string topBorder = " ";
                    if (row > 0 && sudoku.Grid[row - 1, col] is not null && cell is not null && cell.Field != sudoku.Grid[row - 1, col].Field)
                        topBorder = "—";

                    yield return new ColoredString(" " + topBorder + " ", ConsoleColor.White, Display.BackgroundColor);
                }
                yield return new ColoredString(Environment.NewLine, ConsoleColor.White, ConsoleColor.Black);

                // Yield the row's Value and Left and Right Border.
                for (int col = 0; col < size; col++)
                {
                    ICell? cell = sudoku.Grid[row, col];
                    if (cell == null)
                        yield return new ColoredString("   ", ConsoleColor.White, ConsoleColor.Black); // Display an empty cell for Samurai puzzles.

                    else
                    {
                        string leftBorder = " ";
                        if (col > 0 && sudoku.Grid[row, col - 1] is not null && cell.Field != sudoku.Grid[row, col - 1].Field)
                            leftBorder = "|";

                        string rightBorder = " ";
                        if (col < size - 1 && sudoku.Grid[row, col + 1] is not null && cell.Field != sudoku.Grid[row, col + 1].Field)
                            rightBorder = "|";

                        yield return new ColoredString(leftBorder, ConsoleColor.White, Display.BackgroundColor);
                        yield return new ColoredString(cell.Value.ToString(), ConsoleColor.Black, Display.ValueColor);
                        yield return new ColoredString(rightBorder, ConsoleColor.White, Display.BackgroundColor);
                    }
                }
                yield return new ColoredString(Environment.NewLine, ConsoleColor.White, ConsoleColor.Black);

                // Yield the row's Bottom Border.
                for (int col = 0; col < size; col++)
                {
                    ICell? cell = sudoku.Grid[row, col];
                    string bottomBorder = " ";
                    if (row < size - 1 && sudoku.Grid[row + 1, col] is not null && cell is not null && cell.Field != sudoku.Grid[row + 1, col].Field)
                        bottomBorder = "—";

                    yield return new ColoredString(" " + bottomBorder + " ", ConsoleColor.White, Display.BackgroundColor);
                }
                yield return new ColoredString(Environment.NewLine, ConsoleColor.White, ConsoleColor.Black);
            }
        }
    }
}
