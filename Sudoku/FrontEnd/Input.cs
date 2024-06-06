using GameLibrary;

namespace FrontEnd
{
    internal class Input
    {
        public static KeyData GetDirection(ConsoleKey input)
        {
            KeyData keyData = new();

            switch (input)
            {
                case ConsoleKey.Escape:
                    keyData.Exit = true;
                    break;
            }

            return keyData;
        }
    }
}
