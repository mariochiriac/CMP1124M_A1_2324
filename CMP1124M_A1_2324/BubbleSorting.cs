using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1124M_A1_2324
{
    internal class BubbleSorting
    {
        private int bubbleSteps;

        public void bubbleSort(int[] array)
        {
            bubbleSteps = 0;
            int n = array.Length;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (array[j + 1] < array[j])
                    {
                        bubbleSteps++;
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
            // Outputs Steps Taken
            Console.WriteLine($"[BUBBLE SORT ASCENDING] Steps Taken: {bubbleSteps}");
            Console.WriteLine();
        }

        public void BubbleSortDescending(int[] array)
        {
            bubbleSteps = 0;
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (array[j + 1] > array[j]) // Comparison changed for descending order
                    {
                        bubbleSteps++;
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
            Console.WriteLine($"[BUBBLE SORT DESCENDING] Steps Taken: {bubbleSteps}");
            Console.WriteLine();
        }
    }
}
