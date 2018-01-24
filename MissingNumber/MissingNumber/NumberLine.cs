using System;
using System.Collections.Generic;
using System.Linq;

namespace MissingNumber
{
    /// <summary>
    /// Class that represents a sequential list of numbers and provides the ability to detect which number is missing
    /// </summary>
    public class NumberLine
    {
        private int _sum = 0;

        /// <summary>
        /// Creats a new NumberLine object
        /// </summary>
        /// <exception cref="ArgumentException">Thrown if the string given is not of the correct format</exception>
        public NumberLine(string line, char delimiter)
        {
            Min = int.MaxValue;
            Max = int.MinValue;
            Numbers = populateNumbers(line, delimiter);
            MissingNumber = getMissingNumber(); 
        }

        /// <summary>
        /// Collection of Numbers generated, unordered
        /// </summary>
        public IReadOnlyList<int> Numbers { get; private set; }

        /// <summary>
        /// Smallest Number in sequence
        /// </summary>
        public int Min { get; private set; }

        /// <summary>
        /// Largest Number in sequence
        /// </summary>
        public int Max { get; private set; } 

        /// <summary>
        /// The Number missing from the Number sequence
        /// </summary>
        public int MissingNumber { get; private set; }
        
        private int getMissingNumber()
        {
            int expectedSum = (Numbers.Count + 1) * (Min + Max) / 2;
            return expectedSum - _sum;
        }

        private IReadOnlyList<int> populateNumbers(string line, char delimiter)
        {
            string[] nums = line.Split(delimiter);
            return new List<int>(nums.Select(n => intFromString(n)));
        }

        private int intFromString(string s)
        {
            try
            {
                int newNum = int.Parse(s);
                updateMinMax(newNum);
                _sum += newNum;
                return newNum;
            }
            catch(Exception e)
            {
                throw new ArgumentException($"Invalid string line passed to NumberLine, {s} can not convert to a number.", e);
            }
        }
        
        private void updateMinMax(int num)
        {
            if (num < Min)
            {
                Min = num; 
            }
            if (num > Max)
            {
                Max = num;
            }
        }
    }
}
