using GameLibrary.Enumerations;

namespace GameLibrary
{
    public class KeyData
    {
        public bool Exit { get; set; }
        public bool ToggleViewMode { get; set; }
        public bool ToggleIndicationMode { get; set; }

        public Direction? Move { get; set; }
        public int? Value { get; set; }
    }
}
