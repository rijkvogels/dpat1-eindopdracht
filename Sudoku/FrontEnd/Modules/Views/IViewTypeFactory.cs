using GameLibrary;

namespace FrontEnd.Modules
{
    internal interface IViewTypeFactory
    {
        IEnumerable<ColoredString> Show(IGame game);
    }
}
