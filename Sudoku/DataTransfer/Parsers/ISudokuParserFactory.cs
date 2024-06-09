using GameLibrary;

namespace DataTransfer.Factories
{
    internal interface ISudokuParserFactory
    {
        ISudoku Parse(string sudokuData);
    }
}
