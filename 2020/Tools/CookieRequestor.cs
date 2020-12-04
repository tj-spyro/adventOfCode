// ReSharper disable IdentifierTypo

namespace Tools
{
    public class CookieRequestor:ICookieRequestor
    {
        private readonly IFileHandler _fileHandler;
        private readonly IConsoleTools _consoleTools;

        public CookieRequestor(IFileHandler fileHandler, IConsoleTools consoleTools)
        {
            _fileHandler = fileHandler;
            _consoleTools = consoleTools;
        }

        public string GetCookie()
        {
            var fileContents = _fileHandler.GetFileContents(Constants.CookieLocation);
            if (!string.IsNullOrWhiteSpace(fileContents))
            {
                return fileContents;
            }
            
            var details = _consoleTools.GetStr("What is the cookie details?");
            _fileHandler.SetFileContents(Constants.CookieLocation,details);

            return details;
        }

    }
}