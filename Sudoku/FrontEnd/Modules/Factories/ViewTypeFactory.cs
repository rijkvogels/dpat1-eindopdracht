using FrontEnd.Modules.Factories;
using GameLibrary.Enumerations;

namespace FrontEnd.Modules
{
    internal class ViewTypeFactory
    {
        public static IViewType Create(ViewType type)
        {
            return type switch
            {
                ViewType.Definite => new DefiniteView(),
                ViewType.Note => new NoteView(),
                ViewType.Indication => new IndicationView(),
                _ => throw new ArgumentException("Invalid display type"),
            };
        }
    }
}
