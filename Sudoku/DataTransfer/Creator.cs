using GameLibrary;

namespace DataTransfer
{
    public static class Creator
    {
        public static IGame Create()
        {
            return new Game();
        }
    }
}