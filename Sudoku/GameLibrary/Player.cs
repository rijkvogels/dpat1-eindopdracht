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

        public bool UpdateCellValue(int value, ViewType viewType)
        {
            if (viewType == ViewType.Definite)
            {
                // If Value is equal to the current Cell Value or 0 set the Cell Value to 0.
                if (value == this.CurrentCell.Value || value == 0)
                {
                    this.CurrentCell.Value = 0;
                }

                // if the Value is new update the Cell Value.
                else
                {
                    this.CurrentCell.Value = value;
                }

                return true;
            }

            if (viewType == ViewType.Note)
            {
                // if the Value is 0 reset all the Cell Auxiliaries.
                if (value == 0)
                {
                    this.CurrentCell.Auxiliaries = [];
                }

                // if the Auxiliary already has the Value remove it.
                else if (this.CurrentCell.Auxiliaries.Contains(value))
                {
                    this.CurrentCell.Auxiliaries = this.CurrentCell.Auxiliaries.Where(aux => aux != value).ToArray();
                }

                // Else add the new Value to Auxiliary.
                else
                {
                    // Change the Array to a list so we can easily add the new Value.
                    List<int> auxiliariesList = [.. this.CurrentCell.Auxiliaries];
                    auxiliariesList.Add(value);
                    auxiliariesList.Sort(); // Sort the list for readability.
                    this.CurrentCell.Auxiliaries = [.. auxiliariesList];
                }

                return true;
            }

            return false;
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

        bool UpdateCellValue(int value, ViewType viewType);
        bool Move(Direction direction, ISudoku sudoku);
    }
}
