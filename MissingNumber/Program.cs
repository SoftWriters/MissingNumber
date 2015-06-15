using System;
using MissingNumberUtilities;

namespace MissingNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var consoleKeyInfo = new ConsoleKeyInfo();
            
            while (consoleKeyInfo.Key != ConsoleKey.Escape)
            {
                Console.WriteLine("Enter path to file.");
                var filePath = Console.ReadLine();

                var fileHelper = new FileHelper();
                var lists = fileHelper.GetListsFromFile(filePath);

                if (lists == null)
                {
                    Console.WriteLine("Press Escape to exit or another key to try again.");
                    consoleKeyInfo = Console.ReadKey(true);
                    continue;
                }

                var numberHelper = new NumberHelper();
                foreach (var list in lists)
                {
                    Console.WriteLine(numberHelper.FindMissingNumber(list));
                }

                Console.WriteLine("Press Escape key to exit or another key to read another file.");
                consoleKeyInfo = Console.ReadKey(true);
            }
        }
    }
}
