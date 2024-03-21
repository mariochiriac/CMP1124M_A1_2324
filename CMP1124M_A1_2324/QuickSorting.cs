using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1124M_A1_2324
{
    internal class QuickSorting
    {
        private int quickSteps;
        public void QuickSort(int[] data)
        {
            // pre: 0 <= n <= data.length
            // post: values in data[0 … n-1] are in ascending order
            quickSteps = 0;
            Quick_Sort(data, 0, data.Length - 1);

            Console.WriteLine($"[QUICK SORT ASCENDING] Steps Taken: {quickSteps}");
        }
        private void Quick_Sort(int[] data, int left, int right)
        {
            int i, j;
            int pivot, temp;
            i = left;
            j = right;
            pivot = data[(left + right) / 2];
            do
            {
                while ((data[i] < pivot) && (i < right)) i++;
                while ((pivot < data[j]) && (j > left)) j--;
                if (i <= j)
                {
                    quickSteps++;
                    temp = data[i];
                    data[i] = data[j];
                    data[j] = temp;
                    i++;
                    j--;
                }
            } while (i <= j);
            if (left < j) Quick_Sort(data, left, j);
            if (i < right) Quick_Sort(data, i, right);
        }

        public void QuickSortDescending(int[] data)
        {
            quickSteps = 0;
            Quick_Sort(data, 0, data.Length - 1);

            Console.WriteLine($"[QUICK SORT DESCENDING] Steps Taken: {quickSteps}");
            Console.WriteLine();
        }

        private void Quick_SortDescending(int[] data, int left, int right)
        {
            int i, j;
            int pivot, temp;
            i = left;
            j = right;
            pivot = data[(left + right) / 2];
            do
            {
                while ((data[i] > pivot) && (i < right)) i++; // Comparison changed for descending order
                while ((pivot > data[j]) && (j > left)) j--; // Comparison changed for descending order
                if (i <= j)
                {
                    quickSteps++;
                    temp = data[i];
                    data[i] = data[j];
                    data[j] = temp;
                    i++;
                    j--;
                }
            } while (i <= j);
            if (left < j) Quick_SortDescending(data, left, j);
            if (i < right) Quick_SortDescending(data, i, right);
        }

    }
}
