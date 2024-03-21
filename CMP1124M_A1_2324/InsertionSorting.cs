using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1124M_A1_2324
{
    internal class InsertionSorting
    {
        private int insertionSteps;

        public void InsertionSort(int[] data)
        // pre: 0 <= n <= data.length
        // post: values in data[0 … n-1] are in ascending order
        {
            int n = data.Length;

            insertionSteps = 0;

            int numSorted = 1; // number of values in place
            int index; // general index
            while (numSorted < n)
            {
                // take the first unsorted value
                int temp = data[numSorted];
                // … and insert it among the sorted
                for (index = numSorted; index > 0; index--)
                {
                    if (temp < data[index - 1])
                    {
                        data[index] = data[index - 1];
                        insertionSteps++;
                    }
                    else
                    {
                        break;
                    }
                }
                // reinsert value
                data[index] = temp;
                numSorted++;
            }

            Console.WriteLine($"[INSERTION SORT ASCENDING] Steps Taken: {insertionSteps}");
            Console.WriteLine();
        }

        public void InsertionSortDescending(int[] data)
        {
            insertionSteps = 0;
            int n = data.Length;
            int numSorted = 1;
            int index;
            while (numSorted < n)
            {
                int temp = data[numSorted];
                for (index = numSorted; index > 0; index--)
                {
                    if (temp > data[index - 1]) // Comparison changed for descending order
                    {
                        data[index] = data[index - 1];
                        insertionSteps++;
                    }
                    else
                    {
                        break;
                    }
                }
                data[index] = temp;
                numSorted++;
            }

            Console.WriteLine($"[INSERTION SORT DESCENDING] Steps Taken: {insertionSteps}");
            Console.WriteLine();
        }
    }
}
