using System;

namespace CMP1124M_A1_2324
{
    internal class MergeSorting
    {
        private int mergeSteps; // Counter for merge steps

        // ASCENDING MERGE SORTING
        private void Merge(int[] data, int[] temp, int low, int middle, int high)
        {
            int ri = low; // result index
            int ti = low; // temp index
            int di = middle; // destination index
            // while two lists are not empty merge smaller value
            while (ti < middle && di <= high)
            {
                mergeSteps++; // Increment merge step counter
                if (data[di] < temp[ti])
                {
                    data[ri++] = data[di++];
                }
                else
                {
                    data[ri++] = temp[ti++];
                }
            }
            while (ti < middle)
            {
                mergeSteps++; // Increment merge step counter
                data[ri++] = temp[ti++];
            }
        }

        private void MergeSortRecursive(int[] data, int[] temp, int low, int high)
        {
            int n = high - low + 1;
            int middle = low + n / 2;
            int i;

            if (n < 2) return;

            for (i = low; i < middle; i++)
            {
                temp[i] = data[i];
            }

            MergeSortRecursive(temp, data, low, middle - 1);
            MergeSortRecursive(data, temp, middle, high);

            Merge(data, temp, low, middle, high);
        }

        public void MergeSort(int[] data)
        {
            int n = data.Length;
            mergeSteps = 0;
            int[] temp = new int[n];
            mergeSteps = 0; // Reset merge step counter
            MergeSortRecursive(data, temp, 0, n - 1);
            Console.WriteLine($"[MERGE SORTING ASCENDING] Steps Taken: {mergeSteps}");
        }

        // DESCENDING MERGE SORTING
        private void MergeDescending(int[] data, int[] temp, int low, int middle, int high)
        {
            int ri = low; // result index
            int ti = low; // temp index
            int di = middle; // destination index

            while (ti < middle && di <= high)
            {
                mergeSteps++; // Increment merge step counter
                if (data[di] > temp[ti])
                {
                    data[ri++] = data[di++];
                }
                else
                {
                    data[ri++] = temp[ti++];
                }
            }
            while (ti < middle)
            {
                mergeSteps++; // Increment merge step counter
                data[ri++] = temp[ti++];
            }
        }

        private void MergeSortRecursiveDescending(int[] data, int[] temp, int low, int high)
        {
            int n = high - low + 1;
            int middle = low + n / 2;
            int i;

            if (n < 2) return;

            for (i = low; i < middle; i++)
            {
                temp[i] = data[i];
            }

            MergeSortRecursiveDescending(temp, data, low, middle - 1);
            MergeSortRecursiveDescending(data, temp, middle, high);

            MergeDescending(data, temp, low, middle, high);
        }

        public void MergeSortDescending(int[] data)
        {
            int n = data.Length;
            int[] temp = new int[n];
            mergeSteps = 0; // Reset merge step counter
            MergeSortRecursiveDescending(data, temp, 0, n - 1);
            Console.WriteLine($"[MERGE SORTING DESCENDING] Steps Taken: {mergeSteps}");
            Console.WriteLine();
        }
    }
}
