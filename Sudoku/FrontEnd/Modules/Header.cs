using GameLibrary;

namespace FrontEnd.Modules
{
    internal class Header
    {
        private readonly string _title = "ATD Design Patterns 1 - Eindopdracht - Rijk Vogels & Martijn Vermeer";

        private readonly string _exitButton = "ESC";
        private readonly string _validateButton = "C";
        private readonly string _viewmodeButton = "Spacebar";

        public IEnumerable<ColoredString> Render(IGame game)
        {
            yield return new("\n");

            yield return new($"{Display.MarginLeft}{_title}" + "\n");

            yield return new($"{Display.MarginLeft}Current puzzle type: ");
            yield return new($"{game.SudokuType}", ConsoleColor.Green);
            yield return new("\n");

            yield return new("\n");

            yield return new($"{Display.MarginLeft}Press ");
            yield return new($"{_exitButton}", ConsoleColor.DarkRed);
            yield return new($" to restart the puzzle." + "\n");

            yield return new($"{Display.MarginLeft}Press ");
            yield return new($"{_validateButton}", ConsoleColor.DarkRed);
            yield return new($" to toggle validation mode." + "\n");

            yield return new($"{Display.MarginLeft}Press ");
            yield return new($"{_viewmodeButton}", ConsoleColor.DarkRed);
            yield return new($" to toggle editor mode." + "\n");

            yield return new("\n");

            yield return new(new string('-', Console.WindowWidth) + "\n");

            yield return new("\n");
            yield return new("\n");
            yield return new("\n");
        }
    }
}
