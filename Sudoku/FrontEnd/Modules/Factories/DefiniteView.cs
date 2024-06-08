using GameLibrary;

namespace FrontEnd.Modules.Factories
{
    internal class DefiniteView : IViewType
    {
        public void Show(IGame game)
        {
            var sudoku = game.Sudoku;
            int size = (int)Math.Sqrt(sudoku.Grid.Length);

            for (int row = 0; row < size; row++)
            {
                Console.Write(Display.MarginLeft);

                for (int col = 0; col < size; col++)
                {
                    ICell? cell = sudoku.Grid[row, col];
                    if (cell is not null)
                    {
                        Console.Write(cell?.Value + " ");
                    } else
                    {
                        Console.Write("  ");
                    }
                    
                }
                Console.WriteLine();
            }
        }
    }
}
