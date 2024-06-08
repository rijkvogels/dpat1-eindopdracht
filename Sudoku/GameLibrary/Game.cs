namespace GameLibrary
{
    public class Game : IGame
    {
        public event EventHandler<Game>? GameUpdated;
        public bool Exit { get; private set; }

        public ISudoku Sudoku { get; }
        
        public string PuzzlelUrl { get; }

        public Game(ISudoku sudoku, string puzzleUrl) {
            this.Sudoku = sudoku;
            this.PuzzlelUrl = puzzleUrl;
        }

        public void NextFrame(KeyData input)
        {
            if (input.Exit)
            {
                this.EndGame();
                return;
            }

            // TODO: Handle the game logic here.
            // TODO: Remove this print-testing data.
            /*
            int rows = this.Sudoku.Grid.GetLength(0);
            int cols = this.Sudoku.Grid.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    ICell? cell = this.Sudoku.Grid[i, j];
                    if (cell is not null)
                    {
                        Console.Write($"({cell.Value}, {cell.Field}) ");
                    } else
                    {
                        Console.Write("( , ) ");
                    }

                }
                Console.WriteLine();
            }
            */

            // Update the game.
            this.UpdateGame();
        }

        public void EndGame()
        {
            this.Exit = true;
        }

        private void UpdateGame() => this.GameUpdated?.Invoke(this, this);
    }

    public interface IGame
    {
        ISudoku Sudoku { get; }
        event EventHandler<Game> GameUpdated;
        bool Exit { get; }
        string PuzzlelUrl { get; }

        void NextFrame(KeyData input);
        void EndGame();
    }
}
