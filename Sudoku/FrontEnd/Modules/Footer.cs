using GameLibrary;

namespace FrontEnd.Modules
{
    internal class Footer
    {
        public IEnumerable<ColoredString> Render(IGame game)
        {
            yield return new("\n");

            yield return new(new string('-', Console.WindowWidth) + "\n");

            yield return new("\n");
        }
    }
}
