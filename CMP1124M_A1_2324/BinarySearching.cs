using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace CMP1124M_A1_2324
{
    internal class BinarySearching
    {
        private int binarySteps; // Holds counter

        public void BinarySearch(int[] array, int key)
        {
            binarySteps = 0;
            int low = 0;
            int high = array.Length - 1;

            List<int> resultIndexes = new List<int>(); // List of indexes
            int result = Binary_Search(key, array, low, high); // Index of key value

            Console.WriteLine($"[BINARY SEARCH] Steps Taken: {binarySteps}");

            if (result == -1)
            {
                // No exact match found, find closest value
                int closestIndex = FindClosestValueIndex(key, array);
                Console.WriteLine($"The value {key} has not been found. The closest value within the specified array is: {array[closestIndex]} at index {closestIndex}");
            }
            else
            {
                GetAllIndexes(resultIndexes, array, result); // Find duplicates of the same value

                Console.WriteLine($"The value {key} has been found at indexes: ");
                foreach (var i in resultIndexes)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }
        }

        private int Binary_Search(int key, int[] array, int low, int high)
        {
            if (low > high) return -1;
            int mid = (low + high) / 2; // Calculate middle index
            binarySteps++;
            if (key == array[mid])
            {
                binarySteps++; // Add to step counter
                return mid;
            }

            // If  key is less than value at middle index, search left half.
            if (key < array[mid])
            {
                return Binary_Search(key, array, low, mid - 1);
            }
            // If key is greater than value at middle index, search right half.
            else
            {
                return Binary_Search(key, array, mid + 1, high);
            }
        }

        static int FindClosestValueIndex(int key, int[] array)
        {
            int low = 0; // Low index
            int high = array.Length - 1; // High Index
            int closestIndex = 0; // Closest value
            int minDiff = int.MaxValue; // Min difference

            // Binary Search loop
            while (low <= high)
            {
                int mid = (low + high) / 2; // Get middle index
                int diff = Math.Abs(array[mid] - key); // Calculate value between key and middle index

                // Update closest and min diff
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

        public void DisplayEachValueOf(int[] array, int value)
        {
            Console.WriteLine();
            Console.WriteLine($"Every multiple of {value} in the array: ");

            // Checks if remainder of array value is 0, if condition is met, it is a multiple of parameter value
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % value == 0)
                    Console.Write(array[i] + ", ");
                else continue;
            }
            Console.WriteLine();
        }

        private static void GetAllIndexes(List<int> list, int[] array, int result)
        {
            int targetValue = array[result];
            // Start from the left side of the result index
            for (int i = result; i >= 0; i--)
            {
                if (array[i] == targetValue)
                {
                    list.Add(i);
                }
                else
                {
                    // Exit loop if a different value is encountered
                    break;
                }
            }

            // Start from the right side of the result index
            for (int i = result + 1; i < array.Length; i++)
            {
                if (array[i] == targetValue)
                {
                    list.Add(i);
                }
                else
                {
                    // Exit loop if a different value is encountered
                    break;
                }
            }
        }

    }
}
