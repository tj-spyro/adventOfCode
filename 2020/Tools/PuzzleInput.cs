using System;
using System.Linq;
using System.Net;

namespace Tools
{
    public class PuzzleInput:IPuzzleInput
    {
        private readonly ICookieRequestor _cookieRequestor;

        public PuzzleInput(ICookieRequestor cookieRequestor)
        {
            _cookieRequestor = cookieRequestor;
        }

        public string GetPuzzleInput(string url)
        {
            using var client = new WebClient();
            client.Headers.Add("cookie", _cookieRequestor.GetCookie());

            try
            {
                var webpage = client.DownloadString(url);
                return webpage;

            }
            catch(WebException e) when (e.Message.Equals("The remote server returned an error: (400) Bad Request.", StringComparison.InvariantCultureIgnoreCase ))
            {
                Console.WriteLine("The Cookie is likely to be incorrect, please read the readme on how to get the correct cookie.");
                throw;
            }
        }

        public string[] GetPuzzleInputAsArray(string url)
        {
            var webpage = GetPuzzleInput(url);
            var lines = webpage.Split("\n");

            return string.IsNullOrEmpty(lines[^1]) ? lines[..^1] : lines;
        }
    }
}