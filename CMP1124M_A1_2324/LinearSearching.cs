using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CMP1124M_A1_2324
{
    internal class LinearSearching
    {
        private int linearSteps;
        public void LinearSearch(int[] array, int key)
        {
            List<int> resultIndexes = new List<int>();
            int linearSteps = 0;

            // Loop that checks each value of array to find the key
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == key) resultIndexes.Add(i);
                linearSteps++;
            }

            Console.WriteLine($"[LINEAR SEARCH] Steps Taken: {linearSteps}");

            if (resultIndexes.Count == 0)
            {
                int closest_index = FindClosestValueIndex(key, array);
                Console.WriteLine($"The {key} has not been found in the array.");
                Console.WriteLine($"The closest value found in the array is: {array[closest_index]} at index {closest_index}");
            }
            else
            {
                Console.WriteLine($"The value {key} has been found at indexes: ");
                foreach (var i in resultIndexes)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }
        }
        static int FindClosestValueIndex(int key, int[] array)
        {
            int low = 0;
            int high = array.Length - 1;
            int closestIndex = 0;
            int minDiff = int.MaxValue;

            while (low <= high)
            {
                int mid = (low + high) / 2;
                int diff = Math.Abs(array[mid] - key);

                if (diff < minDiff)
                {
                    minDiff = diff;
                    closestIndex = mid;
                }

                if (array[mid] == key)
                {
                    return mid;
                }
                else if (array[mid] < key)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            return closestIndex;
        }
    }
}
