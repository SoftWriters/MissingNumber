using System;
using System.Collections.Generic;
using System.IO;

namespace MissingNumberUtilities
{
    public class FileHelper
    {
        public List<List<int>> GetListsFromFile(string filePath)
        {
            var returnList = new List<List<int>>();
            try
            {
                var numLine = string.Empty;
                var file = new StreamReader(filePath);
                while ((numLine = file.ReadLine()) != null)
                {
                    var numArray = numLine.Split(',');
                    var numList = new List<int>();
                    foreach (var s in numArray)
                    {
                        numList.Add(Convert.ToInt32(s));
                    }

                    returnList.Add(numList);
                }
            }
            catch (ArgumentException argumentException)
            {
                Console.WriteLine("The path supplied is an empty string.");
                return null;
            }
            catch (FileNotFoundException fileNotFoundException)
            {
                Console.WriteLine("The file cannot be found.");
                return null;
            }
            catch (OverflowException overflowException)
            {
                Console.WriteLine("Number too large.");
                return null;
            }
            catch (FormatException formatException)
            {
                Console.WriteLine("Input not a number.");
                return null;
            }
            
            return returnList;
        }
    }
}
