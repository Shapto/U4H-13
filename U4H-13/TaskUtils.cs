using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U4H_13
{
    class TaskUtils
    {
        public static bool ExistsInFile(string word, string filePath, char[] punctuation)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] words = line.Split(punctuation, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string w in words)
                    {
                        if (w == word)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public static int CountOccurences(string filePath, string word, char[] punctuation)
        {
            int count = 0;
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] words = line.Split(punctuation, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string w in words)
                    {
                        if (w == word)
                        {
                            count++;
                        }
                    }
                }
            }
            return count;
        }
    }
}
