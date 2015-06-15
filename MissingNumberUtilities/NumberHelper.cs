using System.Collections.Generic;
using System.Linq;

namespace MissingNumberUtilities
{
    public class NumberHelper
    {
        /// <summary>
        /// Takes a list of ints, sorts, then sums the numbers. 
        /// Finds sum of range of ints using max and min values in the int list.
        /// Determines expected (missing) number by subtracting the sum of the 
        /// ints passed in versus the sum of the range using max/min values.
        /// </summary>
        /// <param name="numbersList">A List of ints</param>
        /// <returns>An int that represents the missing number.</returns>
        public int FindMissingNumber(List<int> numbersList)
        {
            // Assume the first List contains this sequence {3,7,1,2,8,4,5,9,10}
            
            numbersList.Sort(); // The list is now sorted as such {1,2,3,4,5,7,8,9,10}
            
            var arraySum = numbersList.Sum(); // The sum of the numbers passed in is 49
            
            var expectedSum = 0; // Expected sum of numbers in the range of 1 to 10. That's 55
                                 // We'll loop through that range to add achieve that sum.
            for (var x = numbersList[0]; x < numbersList[numbersList.Count - 1] + 1; x++)
            {
                expectedSum += x; 
            }

            return expectedSum - arraySum; 
        }
    }
}
