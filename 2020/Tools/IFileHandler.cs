namespace Tools
{
    public interface IFileHandler
    {
        string GetFileContents(string path);
        void SetFileContents(string path,string contents);
    }
}