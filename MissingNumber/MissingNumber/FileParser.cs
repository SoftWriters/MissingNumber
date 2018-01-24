using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MissingNumber
{
    /// <summary>
    /// Parses a file of the right format and creates NumberLine objects from it
    /// </summary>
    public class FileParser
    {
        /// <summary>
        /// Parses a file with the correct format and returns a list of NumberLine objects
        /// </summary>
        /// <param name="filePath">Full path to the file to read</param>
        /// <returns>IList of NumberLine objects created from the file</returns>
        /// <exception cref="FileNotFoundException">Thrown if the file passed can not be located</exception>
        public IList<NumberLine> ParseFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                return parseLines(File.ReadAllLines(filePath));
            }
            else
            {
                throw new FileNotFoundException($"Invalid file passed to FileParser, file {filePath} does not exist.");
            }
        }

        private IList<NumberLine> parseLines(string [] lines)
        {
            List <NumberLine> numberLines = new List<NumberLine>();
            NumberLine tmp; 
            foreach (string line in lines.Where(l => !string.IsNullOrEmpty(l)))
            {
                tmp = parseLine(line);
                if (tmp != null)
                {
                    numberLines.Add(tmp);
                }
            }
            return numberLines;
        }

        private NumberLine parseLine(string line)
        {
            try
            {
                return new NumberLine(line, ',');
            }
            catch (ArgumentException e)
            {
                return null;
            }
        }
    }
}
