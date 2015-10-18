using System;
using System.Collections.Generic;
using System.IO;

namespace NumberSolver
{
    class MissingNumber
    {
        public static List<int> GetNumberList(StreamReader file)
        {
            var missing_numbers = new List<int>();
            if (file != null)
            {
                string str_list;
                while ((str_list = file.ReadLine()) != null)
                {
                    var str_array = str_list.Split(',');
                    var int_array = ConvertToIntArray(str_array);
                    var missingnumber = GetMissingNumber(int_array);
                    missing_numbers.Add(missingnumber);
                }
            }
            if (file != null)
            {
                file.Close();
            }
            return missing_numbers;
        }
        public static int[] ConvertToIntArray(string[] string_array)
        {
            var length = string_array.Length;
            var numbers_int_array = new int[length];
            for (int i = 0; i < length; i++)
            {
                try
                {
                    numbers_int_array[i] = Convert.ToInt32(string_array[i]);
                }
                catch (FormatException e)
                {
                    numbers_int_array = null;
                }
            }
            return numbers_int_array;
        }
        public static int GetMissingNumber(int[] int_array)
        {
            int missing_number = 0;
            if (int_array != null)
            {
                Array.Sort(int_array);
                var length = int_array.Length;
                var difference = (int_array[length - 1] - int_array[0]) / (length);
                int index = 0;
                while (index < length)
                {
                    var testvalue1 = int_array[index] + difference;
                    var testvalue2 = int_array[index + 1];
                    if (testvalue1 == testvalue2)
                    {
                        index++;
                    }
                    else
                    {
                        Array.Resize(ref int_array, length + 1);
                        int_array[length] = testvalue1;
                        if (CheckIfSequential(int_array))
                        {
                            missing_number = testvalue1;
                        }
                        else
                        {
                            missing_number = 0;
                        }
                        break;
                    }
                }
            }
            return missing_number;
        }
        public static bool CheckIfSequential(int[] int_array)
        {
            var issquential = false;
            if (int_array != null)
            {
                issquential = true;
                Array.Sort(int_array);
                var difference = int_array[1] - int_array[0];
                var length = int_array.Length - 1;
                for (int i = 0; i < length; i++)
                {
                    if ((int_array[i] + difference) != int_array[i + 1])
                    {
                        issquential = false;
                    }
                }
            }
            return issquential;
        }
    }
}
