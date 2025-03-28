﻿using GameLibrary;
using System.Numerics;

namespace FrontEnd.Modules
{
    internal class DefiniteViewFactory : IViewTypeFactory
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
                        yield return new ColoredString("   "); // Display an empty cell for Samurai puzzles.

                    else
                    {
                        string topBorder = "   ";
                        if (row > 0 && sudoku.Grid[row - 1, col] is not null && cell.Field != sudoku.Grid[row - 1, col].Field)
                            topBorder = "—--";
                        yield return new ColoredString(topBorder, Display.BorderColor, Display.BackgroundColor);
                    }
                }
                yield return new ColoredString(Environment.NewLine);

                // Yield the row's Value and Left and Right Border.
                for (int col = 0; col < size; col++)
                {
                    ICell? cell = sudoku.Grid[row, col];
                    if (cell == null)
                        yield return new ColoredString("   "); // Display an empty cell for Samurai puzzles.

                    else
                    {
                        string leftBorder = " ";
                        if (col > 0 && sudoku.Grid[row, col - 1] is not null && cell.Field != sudoku.Grid[row, col - 1].Field)
                            leftBorder = "|";
                        yield return new ColoredString(leftBorder, Display.BorderColor, Display.BackgroundColor);

                        // Check if validation is on and if the cell is not valid.
                        ConsoleColor valueColor = Display.ValueColor;
                        if (sudoku.ValidationMode && cell.Validate(sudoku, row, col) is not true)
                            valueColor = Display.WarningColor;

                        // Hightlight the player's current position.
                        ConsoleColor backgroundColor = Display.BackgroundColor;
                        if (game.Player.HorizontalPosition == row && game.Player.VerticalPosition == col)
                            backgroundColor = Display.PlayerColor;

                        string cellValue = cell.Value == 0 ? " " : cell.Value.ToString();
                        yield return new ColoredString(cellValue, valueColor, backgroundColor);

                        string rightBorder = " ";
                        if (col < size - 1 && sudoku.Grid[row, col + 1] is not null && cell.Field != sudoku.Grid[row, col + 1].Field)
                            rightBorder = "|";

                        yield return new ColoredString(rightBorder, Display.BorderColor, Display.BackgroundColor);
                    }
                }
                yield return new ColoredString(Environment.NewLine);

                // Yield the row's Bottom Border.
                for (int col = 0; col < size; col++)
                {
                    ICell? cell = sudoku.Grid[row, col];
                    if (cell is null)
                        yield return new ColoredString("   "); // Display an empty cell for Samurai puzzles.

                    else
                    {
                        string bottomBorder = "   ";
                        if (row < size - 1 && sudoku.Grid[row + 1, col] is not null && cell is not null && cell.Field != sudoku.Grid[row + 1, col].Field)
                            bottomBorder = "—--";
                        yield return new ColoredString(bottomBorder, Display.BorderColor, Display.BackgroundColor);
                    }
                }
                yield return new ColoredString(Environment.NewLine);
            }
        }
    }
}
