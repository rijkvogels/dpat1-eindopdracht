using GameLibrary;
using GameLibrary.Enumerations;

namespace FrontEnd
{
    internal class Input
    {
        public static KeyData GetDirection(ConsoleKey input)
        {
            KeyData keyData = new();

            switch (input)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    keyData.Move = Direction.UP;
                    break;

                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    keyData.Move = Direction.RIGHT;
                    break;

                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    keyData.Move = Direction.DOWN;
                    break;

                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    keyData.Move = Direction.LEFT;
                    break;

                case ConsoleKey.Escape:
                    keyData.Exit = true;
                    break;
            }

            return keyData;
        }
    }
}
