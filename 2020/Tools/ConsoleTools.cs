using System;

namespace Tools
{
    public class ConsoleTools:IConsoleTools
    {
        public string GetStr(string message)
        {
            Console.WriteLine(message);
            var line = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(line))
            {
                return line;
            }
            
            Console.WriteLine(@"an error occured, try again");
            Console.ReadLine();
            return GetStr(message);

        }
    }
}