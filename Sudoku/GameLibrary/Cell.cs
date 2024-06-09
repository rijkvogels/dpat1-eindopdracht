namespace GameLibrary
{
    public class Cell : ICell
    {
        public int Value { get; set; }
        public int Field { get; private set; }
        public int[] Auxiliaries { get; set; }

        public Cell(int value, int field) {
            this.Value = value;
            this.Field = field;

            this.Auxiliaries = [];
        }

        public bool Validate()
        {
            // TODO: Create a Validator for the cell.
            // TODO: This validator should have the paramteres, sudoku, positionHorizontal and positionVertical.

            // TODO: I THINK WE SHOULD MOVE VALIDATE FROM VIEWS TO GAME AFTER A NEW VALUE GETS UPDATED TO LIMIT THE AMOUNT OF TIMES IT GETS CALLED AND FOR MVC.
            return false;
        }
    }

    public interface ICell
    {
        int Value { get; set; }
        int Field { get; }
        int[] Auxiliaries { get; set; }

        bool Validate();
    }
}
