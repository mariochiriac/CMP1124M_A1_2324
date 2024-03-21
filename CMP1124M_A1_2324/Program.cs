using System;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace CMP1124M_A1_2324
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Objects
                Sorting sortAlgorithm = new Sorting();
                int[] sortedArray = sortAlgorithm.Sort(); // Calls sorting method

                Searching searchAlgorithm = new Searching(); 
                searchAlgorithm.Search(sortedArray); // Calls searching method
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured: " + ex.Message);
            }
        }


    }
}