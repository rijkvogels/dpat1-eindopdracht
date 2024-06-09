using FrontEnd.Modules;
using GameLibrary;

namespace FrontEnd
{
    internal class Display
    {
        public static readonly ConsoleColor BackgroundColor = ConsoleColor.DarkGray;
        public static readonly ConsoleColor BorderColor = ConsoleColor.Black;

        public static readonly ConsoleColor ValueColor = ConsoleColor.Yellow;
        public static readonly ConsoleColor ErrorColor = ConsoleColor.Red;
        public static readonly ConsoleColor AuxiliaryColor = ConsoleColor.White;
        public static readonly ConsoleColor PlayerColor = ConsoleColor.Magenta;

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

            IViewType display = ViewTypeFactory.Create(game.Sudoku.ViewType);
            foreach (ColoredString item in display.Show(game))
            {
                Write(item);
            }

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
