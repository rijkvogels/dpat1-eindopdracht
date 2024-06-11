using FrontEnd.Modules.Factories;
using GameLibrary.Enumerations;

namespace FrontEnd.Modules
{
    internal class ViewTypeFactory
    {
        public static IViewTypeFactory Create(ViewType type)
        {
            return type switch
            {
                ViewType.Definite => new DefiniteViewFactory(),
                ViewType.Note => new NoteViewFactory(),
                _ => throw new ArgumentException("Invalid View type."),
            };
        }
    }
}
