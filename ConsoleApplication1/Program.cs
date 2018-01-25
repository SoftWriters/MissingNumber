using System;
using System.IO;
using System.Linq;

/* Christine Mullins 
 * 10-26-2015
 */
namespace MissingNumber
{
    public class Missing
    {
        static void Main(string[] args)
        {
            int missing = 0;
            string textLine;

            StreamReader file = new StreamReader("inputlines.txt");
            while ((textLine = file.ReadLine()) != null)
            {
                if (!textLine.Equals(string.Empty))
                {
                    int[] numbers = cleanLine(textLine);
                    missing = getMissing(numbers);
                    System.Console.WriteLine(missing + "\n");
                }
            }

            file.Close();
            System.Console.ReadLine();
        }

        public static int[] cleanLine(string textLine)
        {
            string[] temp = textLine.Split(',');
            int[] numLine = temp.Select(x => int.Parse(x)).ToArray();
            Array.Sort(numLine);

            return numLine;
        }

        public static int getMissing(int[] nums)
        {
            int missing = 0;
            int dif = 0;

            for (int i = 0; i < nums.Length - 1; i++)
            {
                dif = nums[i + 1] - nums[i];
                if (dif > 1)
                {
                    missing = nums[i] + 1;

                }
                dif = 0;
            }

            return missing;
        }
    }
}