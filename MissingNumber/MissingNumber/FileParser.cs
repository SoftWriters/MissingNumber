using System;
using System.Collections.Generic;
using System.IO;

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
        public IList<NumberLine> ParseFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                return parseLines(File.ReadAllLines(filePath));
            }
            else
            {
                throw new ArgumentException($"Invalid file passed to FileParser, file {filePath} does not exist.");
            }
        }

        private IList<NumberLine> parseLines(string [] lines)
        {
            List <NumberLine> numberLines = new List<NumberLine>();
            foreach (string line in lines)
            {
                numberLines.Add(parseLine(line));
            }
            return numberLines;
        }

        private NumberLine parseLine(string line)
        {
            return new NumberLine(line, ',');
        }
    }
}
