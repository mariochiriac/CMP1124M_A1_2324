using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CMP1124M_A1_2324
{
    internal class FileReader
    {
        public int[] LoadFromFile(string filePath)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                int[] array = new int[lines.Length];

                for (int i = 0; i < lines.Length; i++)
                {
                    array[i] = int.Parse(lines[i].Trim());
                }

                return array;
            }
            catch (Exception ex)
            {
                throw new FileLoadException("Error loading from file: " + ex.Message, ex);
            }

        }
    }


}
