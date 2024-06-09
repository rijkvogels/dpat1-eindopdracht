using GameLibrary;

namespace FrontEnd.Modules.Factories
{
    internal class NoteView : IViewType
    {
        public IEnumerable<ColoredString> Show(IGame game)
        {
            var sudoku = game.Sudoku;
            int size = (int)Math.Sqrt(sudoku.Grid.Length);

            for (int row = 0; row < size; row++)
            {
                // Yield the row's Top Border.
                for (int col = 0; col < size; col++)
                {
                    ICell? cell = sudoku.Grid[row, col];
                    if (cell is null)
                    {
                        yield return new ColoredString("     ", Display.BorderColor, Display.BackgroundColor);
                    }
                    else
                    {
                        string topBorder = "     ";
                        if (row > 0 && sudoku.Grid[row - 1, col] is not null && cell.Field != sudoku.Grid[row - 1, col].Field)
                            topBorder = "—————";
                        yield return new ColoredString(topBorder, Display.BorderColor, Display.BackgroundColor);
                    }
                }
                yield return new ColoredString(Environment.NewLine, ConsoleColor.White, ConsoleColor.Black);

                // Yield the cell content by creating three SubRows.
                for (int subRow = 0; subRow < 3; subRow++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        ICell? cell = sudoku.Grid[row, col];
                        if (cell is null)
                        {
                            yield return new ColoredString("     ", Display.BorderColor, Display.BackgroundColor);
                        }
                        else
                        {
                            string leftBorder = " ";
                            if (col > 0 && sudoku.Grid[row, col - 1] is not null && cell.Field != sudoku.Grid[row, col - 1].Field)
                                leftBorder = "|";

                            yield return new ColoredString(leftBorder, Display.BorderColor, Display.BackgroundColor);

                            // Check if the cell has a value if true display this. Else set the Auxillaries and display them.
                            string cellContent;
                            ConsoleColor contentColor = Display.AuxiliaryColor;
                            if (cell.Value is not 0)
                            {
                                cellContent = subRow == 1 ? $" {cell.Value} " : "   "; // Make sure the cell Value is centered in the middle row.
                                contentColor = Display.ValueColor;
                            }
                            else
                            {
                                // Setting up the Auxiliaries.
                                string auxValue1 = cell.Auxiliaries.Length > (subRow * 3) ? (cell.Auxiliaries[subRow * 3] != 0 ? cell.Auxiliaries[subRow * 3].ToString() : " ") : " ";
                                string auxValue2 = cell.Auxiliaries.Length > (subRow * 3 + 1) ? (cell.Auxiliaries[subRow * 3 + 1] != 0 ? cell.Auxiliaries[subRow * 3 + 1].ToString() : " ") : " ";
                                string auxValue3 = cell.Auxiliaries.Length > (subRow * 3 + 2) ? (cell.Auxiliaries[subRow * 3 + 2] != 0 ? cell.Auxiliaries[subRow * 3 + 2].ToString() : " ") : " ";
                                cellContent = auxValue1 + auxValue2 + auxValue3;
                            }

                            yield return new ColoredString(cellContent, contentColor, Display.BackgroundColor);

                            string rightBorder = " ";
                            if (col < size - 1 && sudoku.Grid[row, col + 1] is not null && cell.Field != sudoku.Grid[row, col + 1].Field)
                                rightBorder = "|";
                            yield return new ColoredString(rightBorder, Display.BorderColor, Display.BackgroundColor);
                        }
                    }
                    yield return new ColoredString(Environment.NewLine, ConsoleColor.White, ConsoleColor.Black);
                }

                // Yield the row's Bottom Border.
                for (int col = 0; col < size; col++)
                {
                    ICell? cell = sudoku.Grid[row, col];
                    if (cell is null)
                    {
                        yield return new ColoredString("     ", Display.BorderColor, Display.BackgroundColor);
                    }
                    else
                    {
                        string bottomBorder = "     ";
                        if (row < size - 1 && sudoku.Grid[row + 1, col] is not null && cell.Field != sudoku.Grid[row + 1, col].Field)
                            bottomBorder = "—————";
                        yield return new ColoredString(bottomBorder, Display.BorderColor, Display.BackgroundColor);
                    }
                }
                yield return new ColoredString(Environment.NewLine, ConsoleColor.White, ConsoleColor.Black);
            }
        }
    }
}
