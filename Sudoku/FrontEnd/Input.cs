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
                case ConsoleKey.Escape:
                    keyData.Exit = true;
                    break;

                case ConsoleKey.C:
                    keyData.ToggleIndicationMode = true;
                    break;

                case ConsoleKey.Spacebar:
                    keyData.ToggleViewMode = true;
                    break;

                case ConsoleKey.D0:
                case ConsoleKey.Backspace:
                    keyData.Value = 0;
                    break;

                case ConsoleKey.D1:
                    keyData.Value = 1;
                    break;

                case ConsoleKey.D2:
                    keyData.Value = 2;
                    break;

                case ConsoleKey.D3:
                    keyData.Value = 3;
                    break;

                case ConsoleKey.D4:
                    keyData.Value = 4;
                    break;

                case ConsoleKey.D5:
                    keyData.Value = 5;
                    break;

                case ConsoleKey.D6:
                    keyData.Value = 6;
                    break;

                case ConsoleKey.D7:
                    keyData.Value = 7;
                    break;

                case ConsoleKey.D8:
                    keyData.Value = 8;
                    break;

                case ConsoleKey.D9:
                    keyData.Value = 9;
                    break;

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
            }

            return keyData;
        }
    }
}
