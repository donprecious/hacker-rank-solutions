using System;

namespace BinarySearch
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[] array = {1, 3, 4, 5, 6, 7, 8,9};
            Array.Sort(array);
            var isFound = BinarySearchWithIteration(array, 3);
            Console.WriteLine(isFound);
        }

        private static bool BinarySearchWithIteration(int[] array, int target)
        {
            int left = 0;
            int right = array.Length - 1;
            while (left < right)
            {
                var mid = (left + right) / 2;
                if (array[mid] == target)
                {
                    return true; 
                }else if (target < array[mid])
                {
                    right = mid - 1; 
                }
                else
                {
                    left = mid + 1; 
                }
            }

            return false; 
        }
    }
}