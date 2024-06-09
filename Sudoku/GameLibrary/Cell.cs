namespace GameLibrary
{
    public class Cell : ICell
    {
        public int Value { get; set; }
        public int Field { get; set; }
        public int[] Auxiliaries { get; }

        public Cell(int value, int field) {
            this.Value = value;
            this.Field = field;

            this.Auxiliaries = [1,2,9];
        }

        public bool Validate()
        {
            // TODO: Create a Validator for the cell.
            return true;
        }
    }

    public interface ICell
    {
        int Value { get; set; }
        int Field { get; set; }
        int[] Auxiliaries { get; }

        bool Validate();
    }
}
