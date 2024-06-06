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

        public string? Read(string fileName)
        {
            try
            {
                if (DirectoryPath() is not null)
                    if (File.Exists(DirectoryPath() + fileName))
                        return File.ReadAllText(DirectoryPath() + fileName);
            }
            catch (Exception exception)
            {
                throw new JsonException("The provided text file is invalid. ERROR: ", exception);
            }

            return null;
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
    }
}
