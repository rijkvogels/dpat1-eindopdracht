using GameLibrary.Enumerations;
using System.Text.Json;

namespace DataTransfer
{
    internal class Reader
    {
        private readonly string _projectPath;
        private readonly string _directoryPath;

        public Reader()
        {
            _projectPath = "DPAT1\\dpat1-eindopdracht\\Sudoku";
            _directoryPath = "DataTransfer\\Puzzles\\";
        }

        public (string? content, SudokuType? sudokuType) Read(string fileName)
        {
            try
            {
                string? directoryPath = this.DirectoryPath();

                if (directoryPath is not null)
                    if (File.Exists(directoryPath + fileName))
                    {
                        string content = File.ReadAllText(directoryPath + fileName);
                        SudokuType? type = GetSudokuType(fileName);

                        return (content, type);
                    }
                        
            }
            catch (Exception exception)
            {
                throw new JsonException("The provided text file is invalid. ERROR: ", exception);
            }

            return (null, null);
        }

        private string? DirectoryPath()
        {
            string path = Environment.CurrentDirectory;

            int index = path.IndexOf(_projectPath) + _projectPath.Length + 1;

            if (index >= 0)
                path = path[..index];

            path += _directoryPath;

            if (Directory.Exists(path))
                return path;

            return null;
        }

        private static SudokuType? GetSudokuType(string fileName)
        {
            return Path.GetExtension(fileName).TrimStart('.') switch
            {
                "4x4" => SudokuType.Sudoku4x4,
                "6x6" => SudokuType.Sudoku6x6,
                "9x9" => SudokuType.Sudoku9x9,
                "jigsaw" => SudokuType.SudokuJigsaw,
                "samuari" => SudokuType.SudokuSamurai,
                _ => null
            };
        }
    }
}
