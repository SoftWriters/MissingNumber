using System;
using System.Collections.Generic;
using System.IO;
using NumberSolver;

    class Program
    {
        static void Main(string[] args)
        {
            var file = GetFile();
            List<int> missing_numbers_list = MissingNumber.GetNumberList(file);
            foreach (var number in missing_numbers_list)
            {
                Console.WriteLine(number);
            }
            var pause = Console.Read();
        }
        public static StreamReader GetFile()
        {
            var path = "c:\\test.txt";
            try
            {
                return new StreamReader(path);
            }
            catch (System.IO.FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }
}
