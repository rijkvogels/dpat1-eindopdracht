using GameLibrary;

namespace FrontEnd.Modules
{
    internal class Header
    {
        private readonly string _title = "ATD Design Patterns 1 - Eindopdracht - Rijk Vogels & Martijn Vermeer";

        private readonly string _exit = "Press ESC to restart the puzzle.";
        private readonly string _validate = "Press C to toggle validation mode.";
        private readonly string _viewmode = "Press Spacebar to toggle editormode.";

        public IEnumerable<ColoredString> Render(IGame game)
        {
            yield return new("\n");

            yield return new($"{Display.MarginLeft}{_title}" + "\n");

            yield return new($"{Display.MarginLeft}Current puzzle type: ");
            yield return new($"{game.SudokuType}", ConsoleColor.Green);
            yield return new("\n");

            yield return new("\n");

            yield return new($"{Display.MarginLeft}{_exit}" + "\n");
            yield return new($"{Display.MarginLeft}{_validate}" + "\n");
            yield return new($"{Display.MarginLeft}{_viewmode}" + "\n");

            yield return new(new string('-', Console.WindowWidth) + "\n");

            yield return new("\n");
            yield return new("\n");
            yield return new("\n");
        }
    }
}
