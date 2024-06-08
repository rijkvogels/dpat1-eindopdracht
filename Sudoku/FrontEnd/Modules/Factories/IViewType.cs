using GameLibrary;

namespace FrontEnd.Modules
{
    internal interface IViewType
    {
        IEnumerable<ColoredString> Show(IGame game);
    }
}
