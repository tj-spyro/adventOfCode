using System.IO.Abstractions;

namespace Tools
{
    public class FileHandler : IFileHandler
    {
        private readonly IFileSystem _fileSystem;

        public FileHandler(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public string GetFileContents(string path)
        {
            CheckOrCreateFile(path);
            return _fileSystem.File.ReadAllText(path);
        }

        public void SetFileContents(string path, string contents)
        {
            CheckOrCreateFile(path);
            _fileSystem.File.WriteAllText(path, contents);
        }

        private void CheckOrCreateFile(string path)
        {
            if (_fileSystem.File.Exists(path))
            {
                return;
            }

            var fileInfo = _fileSystem.FileInfo.FromFileName(path);
            if (fileInfo.Directory != null && !fileInfo.Directory.Exists)
            {
                _fileSystem.Directory.CreateDirectory(fileInfo.Directory.FullName);
            }

            using (_fileSystem.File.Create(path)){}
        }
    }
}