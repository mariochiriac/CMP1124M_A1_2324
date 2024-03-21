using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CMP1124M_A1_2324
{
    internal class Sorting
    {
        public int[] Sort()
        {
            try
            {
                // Objects
                FileReader fileReader = new FileReader();
                MergeSorting mergeSort = new MergeSorting();
                BubbleSorting bubbleSort = new BubbleSorting();
                InsertionSorting insertionSort = new InsertionSorting();
                QuickSorting quickSort = new QuickSorting();
                BinarySearching binarySearch = new BinarySearching();

                //Variables
                int[] net_1_256 = fileReader.LoadFromFile("net_1_256.txt");
                int[] net_2_256 = fileReader.LoadFromFile("net_2_256.txt");
                int[] net_3_256 = fileReader.LoadFromFile("net_3_256.txt");
                int[] net_1_2048 = fileReader.LoadFromFile("net_1_2048.txt");
                int[] net_2_2048 = fileReader.LoadFromFile("net_2_2048.txt");
                int[] net_3_2048 = fileReader.LoadFromFile("net_3_2048.txt");

                int[] selected_array = new int[2048];

                // User Input
                Console.WriteLine("""
                    Choose which array you would like to analyse:
                    ==== 256 TRAFFIC ====
                    (1) Net_1_256
                    (2) Net_2_256
                    (3) Net_3_256
                    ==== 2048 TRAFFIC ====
                    (4) Net_1_2048
                    (5) Net_2_2048
                    (6) Net_3_2048
                    """);

                int arrayChoice; // Variable to hold input from user
                // A loop that will check and validate input from user
                while (true)
                {
                    int.TryParse(Console.ReadLine(), out arrayChoice);

                    if (arrayChoice <= 6 && arrayChoice >= 1) break; // Ensures user chooses 1 -> 6
                    else Console.WriteLine("Invalid input! Please enter an integer (1 - 3)!");
                }

                // TASK 1 - 2
                // Switch Case Statement
                // Loads file depending on user choice from input
                switch (arrayChoice)
                {
                    case 1:
                        selected_array = net_1_256; break;
                    case 2:
                        selected_array = net_2_256; break;
                    case 3:
                        selected_array = net_3_256; break;
                    case 4:
                        selected_array = net_1_2048; break;
                    case 5:
                        selected_array = net_2_2048; break;
                    case 6:
                        selected_array = net_3_2048; break;
                    default:
                        Console.WriteLine("ERROR: Input not in range (1 - 3)."); break;
                }


                Console.WriteLine("""
                    How would you like to sort the array?
                    (1) Ascending
                    (2) Descending
                    (3) Ascending & Descending
                    """);

                int sort_choice; // Variable to hold input from user
                // A loop that will check and validate input from user
                while (true)
                {
                    int.TryParse(Console.ReadLine(), out sort_choice);

                    if (sort_choice <= 3 && sort_choice >= 1) break; // Ensures input is 1 -> 3
                    else Console.WriteLine("Invalid input! Please enter an integer (1 - 3)!");
                }


                Console.WriteLine("""
                Which sorting algorithm would you like to use?
                (1) Bubble Sorting
                (2) Insertion Sorting
                (3) Quick Sorting
                (4) Merge Sorting
                """);

                int algorithm_choice; // Holds algorithm choice
                // Loop for data type check and validation
                while (true)
                {

                    int.TryParse(Console.ReadLine(), out algorithm_choice);

                    if (algorithm_choice <= 4 && algorithm_choice >= 1) break; // Ensures choice is 1 -> 4
                    else Console.WriteLine("Invalid input! Please enter an integer (1 - 3)!");
                }

                // Sorted Variables
                // Copies the current array that holds information from the file for later sorting
                int[] array_ascending = (int[])selected_array.Clone();
                int[] array_descending = (int[])selected_array.Clone();

                
                // Sorting

                switch (algorithm_choice) // Each choice will have a different algorithm
                {
                    case 1: // Bubble Sort
                        switch (sort_choice) // Each choice will have a different sorting choice
                        {
                            case 1:
                                // Ascending Sort
                                bubbleSort.bubbleSort(array_ascending); // Sorts ascending using bubble sort
                                Console.WriteLine("[BUBBLEBUBBLE SORTING] (256) ASCENDING ORDER:");
                                OutputArray(array_ascending);
                                // Checks if the 256 or 2048 files have been selected
                                if (arrayChoice >= 1 && arrayChoice <= 3) binarySearch.DisplayEachValueOf(array_ascending, 10);  // Multiples of 10 if chosen file is 256
                                else binarySearch.DisplayEachValueOf(array_ascending, 50); // Multiples of 50 if chosen file is 2048
                                break;

                            case 2:
                                // Descending Sort
                                bubbleSort.BubbleSortDescending(array_descending);
                                Console.WriteLine("[BUBBLE SORTING] (256) DESCENDING ORDER:");
                                OutputArray(array_descending);
                                if (arrayChoice >= 1 && arrayChoice <= 3) binarySearch.DisplayEachValueOf(array_ascending, 10); // Multiples of 10 if chosen file is 256
                                else binarySearch.DisplayEachValueOf(array_ascending, 50); // Multiples of 50 if chosen file is 2048
                                break;
                            case 3:
                                // Ascending and Descending Sort
                                bubbleSort.bubbleSort(array_ascending);
                                bubbleSort.BubbleSortDescending(array_descending);
                                Console.WriteLine("[BUBBLE SORTING] (256) ASCENDING ORDER:");
                                OutputArray(array_ascending);
                                Console.WriteLine();
                                Console.WriteLine("[BUBBLE SORTING] (256) DESCENDING ORDER:");
                                OutputArray(array_descending);
                                if (arrayChoice >= 1 && arrayChoice <= 3) binarySearch.DisplayEachValueOf(array_ascending, 10);
                                else binarySearch.DisplayEachValueOf(array_ascending, 50);
                                break;
                            default: Console.WriteLine("Invalid! Input out of range (1 - 3)."); break;

                        } 
                        break;

                    case 2: // Insertion Sort
                        switch (sort_choice)
                        {
                            case 1:
                                // Ascending Sort
                                insertionSort.InsertionSort(array_ascending);
                                Console.WriteLine("[INSERTION SORTING] (256) ASCENDING ORDER:");
                                OutputArray(array_ascending);
                                if (arrayChoice >= 1 && arrayChoice <= 3) binarySearch.DisplayEachValueOf(array_ascending, 10);
                                else binarySearch.DisplayEachValueOf(array_ascending, 50);
                                break;

                            case 2:
                                // Descending Sort
                                insertionSort.InsertionSortDescending(array_descending);
                                Console.WriteLine("[INSERTION SORTING] (256) DESCENDING ORDER:");
                                OutputArray(array_descending);
                                binarySearch.DisplayEachValueOf(array_ascending, 10);
                                break;
                            case 3:
                                // Ascending and Descending Sort
                                insertionSort.InsertionSort(array_ascending);
                                insertionSort.InsertionSortDescending(array_descending);
                                Console.WriteLine("[INSERTION SORTING] (256) ASCENDING ORDER:");
                                OutputArray(array_ascending);
                                Console.WriteLine();
                                Console.WriteLine("[INSERTION SORTING] (256) DESCENDING ORDER:");
                                OutputArray(array_descending);
                                if (arrayChoice >= 1 && arrayChoice <= 3) binarySearch.DisplayEachValueOf(array_ascending, 10);
                                else binarySearch.DisplayEachValueOf(array_ascending, 50);
                                break;
                            default: Console.WriteLine("Invalid! Input out of range (1 - 3)."); break;
                        }
                        break;

                    case 3: // Quick Sort
                        switch (sort_choice)
                        {
                            case 1:
                                // Ascending Sort
                                quickSort.QuickSort(array_ascending);
                                Console.WriteLine("[QUICK SORTING] (256) ASCENDING ORDER:");
                                OutputArray(array_ascending);
                                if (arrayChoice >= 1 && arrayChoice <= 3) binarySearch.DisplayEachValueOf(array_ascending, 10);
                                else binarySearch.DisplayEachValueOf(array_ascending, 50);
                                break;

                            case 2:
                                // Descending Sort
                                quickSort.QuickSortDescending(array_descending);
                                Console.WriteLine("[QUICK SORTING] (256) DESCENDING ORDER:");
                                OutputArray(array_descending);
                                if (arrayChoice >= 1 && arrayChoice <= 3) binarySearch.DisplayEachValueOf(array_ascending, 10);
                                else binarySearch.DisplayEachValueOf(array_ascending, 50);
                                break;
                            case 3:
                                // Ascending and Descending Sort
                                quickSort.QuickSort(array_ascending);
                                quickSort.QuickSortDescending(array_descending);
                                Console.WriteLine("[QUICK SORTING] (256) ASCENDING ORDER:");
                                OutputArray(array_ascending);
                                Console.WriteLine();
                                Console.WriteLine("[QUICK SORTING] (256) DESCENDING ORDER:");
                                OutputArray(array_descending);
                                if (arrayChoice >= 1 && arrayChoice <= 3) binarySearch.DisplayEachValueOf(array_ascending, 10);
                                else binarySearch.DisplayEachValueOf(array_ascending, 50);
                                break;
                            default: Console.WriteLine("Invalid! Input out of range (1 - 3)."); break;
                        }
                        break;

                    case 4: // Merge Sort
                        switch (sort_choice)
                        {
                            case 1:
                                // Ascending Sort
                                mergeSort.MergeSort(array_ascending);
                                Console.WriteLine("[MERGE SORTING] (256) ASCENDING ORDER:");
                                OutputArray(array_ascending);
                                if (arrayChoice >= 1 && arrayChoice <= 3) binarySearch.DisplayEachValueOf(array_ascending, 10);
                                else binarySearch.DisplayEachValueOf(array_ascending, 50);
                                break;

                            case 2:
                                // Descending Sort
                                mergeSort.MergeSortDescending(array_descending);
                                Console.WriteLine("[MERGE SORTING] (256) DESCENDING ORDER:");
                                OutputArray(array_descending);
                                if (arrayChoice >= 1 && arrayChoice <= 3) binarySearch.DisplayEachValueOf(array_ascending, 10);
                                else binarySearch.DisplayEachValueOf(array_ascending, 50);
                                break;
                            case 3:
                                // Ascending and Descending Sort
                                mergeSort.MergeSort(array_ascending);
                                mergeSort.MergeSortDescending(array_descending);
                                Console.WriteLine("[MERGE SORTING] (256) ASCENDING ORDER:");
                                OutputArray(array_ascending);
                                Console.WriteLine();
                                Console.WriteLine("[MERGE SORTING] (256) DESCENDING ORDER:");
                                OutputArray(array_descending);
                                if (arrayChoice >= 1 && arrayChoice <= 3) binarySearch.DisplayEachValueOf(array_ascending, 10);
                                else binarySearch.DisplayEachValueOf(array_ascending, 50);
                                break;
                            default: Console.WriteLine("Invalid! Input out of range (1 - 3)."); break;
                        }
                        break;

                    default: Console.WriteLine("Invalid! Input out of range (1 - 3)."); break;
                }

                return array_ascending; // Returns sorted array
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured: " + ex.Message);
                return null;
            }
        }

        private static void OutputArray(int[] array)
        {
            foreach (var i in array)
            {
                if (i == array[array.Length - 1]) Console.Write(i + ".");
                else Console.Write(i + ", ");
            }
            Console.WriteLine();
        }
    }
}
