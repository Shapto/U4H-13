using System;
using System.Collections.Generic;
using System.IO;
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
        public static List<string> UpToTenWords(List<WordInfo> wordlist)
        {
            List<string> Task1Words = new List<string>();
            for (int i = 0; i < wordlist.Count; i++)
            {
                if (wordlist[i].Duplicate == false && wordlist[i].Count == 1 && Task1Words.Count != 10)
                {
                    Task1Words.Add(wordlist[i].Word);
                }
            }
            return Task1Words;
        }
        /// <summary>
        /// Selection sort, which works by finding the lowest value in an array and moving it to the front, repeating until the array is sorted.
        /// </summary>
        public List<WordInfo> Sort(List<WordInfo> wordList)
        {
            for (int i = 0; i < wordList.Count - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < wordList.Count; j++)
                {
                    if (wordList[j].CompareTo(wordList[min]) < 0)
                    {
                        min = j;
                    }
                }
                WordInfo temp = wordList[i];
                wordList[i] = wordList[min];
                wordList[min] = temp;
            }
            return wordList;
        }
    }
}
