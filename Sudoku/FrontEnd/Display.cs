using FrontEnd.Modules;
using GameLibrary;

namespace FrontEnd
{
    internal class Display
    {
        public static readonly ConsoleColor BackgroundColor = ConsoleColor.DarkGray;
        public static readonly string MarginLeft = "   ";

        private readonly Header _header;
        private readonly Footer _footer;

        public Display()
        {
            _header = new();
            _footer = new();

            Console.CursorVisible = false;
        }

        public void UpdateGame(IGame game)
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);

            foreach (ColoredString item in _header.Render(game))
            {
                Write(item);
            }
            
            // TODO: Add the sudoku display here.

            foreach (ColoredString item in _footer.Render(game))
            {
                Write(item);
            }
                
        }

        private static void Write(ColoredString stringColor)
        {
            Console.BackgroundColor = stringColor.BackgroundColor;
            Console.ForegroundColor = stringColor.ForegroundColor;
            Console.Write(stringColor.Text);
        }
    }
}
