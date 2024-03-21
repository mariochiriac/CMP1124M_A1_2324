using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1124M_A1_2324
{
    internal class Searching
    {
        public void Search(int[] sorted_array)
        {
            BinarySearching binarySearch = new BinarySearching();
            LinearSearching linearSearching = new LinearSearching();

            Console.WriteLine("""
                    Would you like to search for a value within the array?
                    Y - Yes
                    N - Any key
                    (Type Y for yes, press any key for no)
                    """);

            string user_input = Console.ReadLine();

            int search_choice;
            int valueChoice;
            
            if (user_input.ToLower() == "y")
            {
                Console.WriteLine("""
                Which searching algorithm would you like to use?
                (1) Binary Search
                (2) Linear Search
                """);

                while (true)
                {
                    
                    int.TryParse(Console.ReadLine(), out search_choice);

                    if (search_choice <= 2 && search_choice >= 1) break;
                    else Console.WriteLine("Invalid input! Please enter an integer (1 - 3)!");
                }
                
                Console.WriteLine("Enter the value you want to search:");
                while (!int.TryParse(Console.ReadLine(), out valueChoice))
                {
                    Console.WriteLine("Please enter a valid integer.");
                }

                switch (search_choice)
                {
                    case 1: binarySearch.BinarySearch(sorted_array, valueChoice); break;
                    case 2: linearSearching.LinearSearch(sorted_array, valueChoice); break;
                }
                
            }
            else
            {
                Console.WriteLine("Exiting program...");
            }
        }
    }
}
