namespace FrontEnd.Modules
{
    public class ColoredString(string text, ConsoleColor foregroundColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black)
    {
        public string Text { get; set; } = text;
        public ConsoleColor ForegroundColor { get; } = foregroundColor;
        public ConsoleColor BackgroundColor { get; } = backgroundColor;
    }
}
