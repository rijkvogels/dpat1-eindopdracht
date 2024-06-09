using GameLibrary.Enumerations;

namespace GameLibrary
{
    internal class Player : IPlayer
    {
        public int HorizontalPosition { get; private set; }
        public int VerticalPosition { get; private set; }
        private ICell CurrentCell { get; set; }

        public Player(ISudoku sudoku)
        {
            this.HorizontalPosition = 0;
            this.VerticalPosition = 0;

            // Set CellPosition to the first Cell in the Sudoku.
            this.CurrentCell = sudoku.Grid[this.HorizontalPosition, this.VerticalPosition];
        }

        public bool Move(Direction direction, ISudoku sudoku)
        {
            int newHorizontalPosition = HorizontalPosition;
            int newVerticalPosition = VerticalPosition;

            switch (direction)
            {
                case Direction.UP:
                    newHorizontalPosition--;
                    break;

                case Direction.RIGHT:
                    newVerticalPosition++;
                    break;

                case Direction.DOWN:
                    newHorizontalPosition++;
                    break;

                case Direction.LEFT:
                    newVerticalPosition--;
                    break;
            }

            // Check if the new Player Position is within the Sudoku bounds and if the Cell exists.
            if (newHorizontalPosition >= 0 && newHorizontalPosition < sudoku.Grid.GetLength(0) &&
                newVerticalPosition >= 0 && newVerticalPosition < sudoku.Grid.GetLength(1) &&
                sudoku.Grid[newHorizontalPosition, newVerticalPosition] is not null)
            {
                HorizontalPosition = newHorizontalPosition;
                VerticalPosition = newVerticalPosition;
                CurrentCell = sudoku.Grid[HorizontalPosition, VerticalPosition];
                return true;
            }

            return false;
        }
    }

    public interface IPlayer
    {
        int HorizontalPosition { get; }
        int VerticalPosition { get; }

        bool Move(Direction direction, ISudoku sudoku);
    }
}
