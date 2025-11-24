using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace U4H_13
{
    class TaskUtils
    {
        /// <summary>
        /// Checks if the word exists in a file
        /// </summary>
        /// <param name="word"></param>
        /// <param name="filePath"></param>
        /// <param name="punctuation"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Finds the amount of times a word appears in a file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="word"></param>
        /// <param name="punctuation"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Finds words which are only in the first list
        /// </summary>
        /// <param name="wordList"></param>
        /// <returns></returns>
        public static List<string> NonDuplicates(List<WordInfo> wordList)
        {
            List<string> Task1Words = new List<string>();
            for (int i = 0; i < wordList.Count; i++)
            {
                if (wordList[i].Duplicate == false && wordList[i].Count == 1 && !Task1Words.Contains(wordList[i].Word))
                {
                    Task1Words.Add(wordList[i].Word);
                }
            }
            return Task1Words;
        }
        /// <summary>
        /// Finds words which are in both lists and adds them to a singular list.
        /// </summary>
        /// <param name="wordlist1"></param>
        /// <param name="wordlist2"></param>
        /// <returns></returns>
        public static List<WordInfo> DuplicateWords(List<WordInfo> wordlist1, List<WordInfo> wordlist2)
        {
            List<WordInfo> Task2Words = new List<WordInfo>();
            for (int i = 0; i < wordlist1.Count; i++)
            {
                WordInfo word1 = wordlist1[i];
                for (int j = 0; j < wordlist2.Count; j++)
                {
                    WordInfo word2 = wordlist2[j];
                    if (word1.Duplicate == true && !Task2Words.Contains(word1))
                    {
                        Task2Words.Add(word1);
                    }
                    else if (word2.Duplicate == true && !Task2Words.Contains(word2))
                    {
                        Task2Words.Add(word2);
                    }
                }
            }
            return Task2Words;
        }
        /// <summary>
        /// Selection sort, which works by finding the lowest value in an array and moving it to the front, repeating until the array is sorted.
        /// </summary>
        public static List<WordInfo> Sort(List<WordInfo> wordList)
        {
            for (int i = 0; i < wordList.Count - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < wordList.Count; j++)
                {
                    if (wordList[j].CompareTo(wordList[min]) > 0)
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
