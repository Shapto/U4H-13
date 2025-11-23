using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace U4H_13
{
    class InOut
    {
        public static List<WordInfo> ReadWords(string in1, string in2, char[] punctuation)
        {
            List<WordInfo> wordList = new List<WordInfo>();
            using (StreamReader reader = new StreamReader(in1))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] words = line.Split(punctuation, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string word in words)
                    {
                        if (TaskUtils.ExistsInFile(word, in2, punctuation))
                        {
                            int count = TaskUtils.CountOccurences(in1, word, punctuation) + TaskUtils.CountOccurences(in2, word, punctuation);
                            WordInfo word1 = new WordInfo(true, count, word, false);
                            wordList.Add(word1);
                        }
                        else
                        {
                            WordInfo word1 = new WordInfo(false, TaskUtils.CountOccurences(in1, word, punctuation), word, false);
                            wordList.Add(word1);
                        }
                    }
                }
            }
            return wordList;
        }
        public static void PrintNonDuplicates(List<string> Task1Words, string out1, string in1, string in2)
        {
            using (StreamWriter writer = new StreamWriter(out1, true))
            {
                if (Task1Words.Count > 0)
                {
                    writer.WriteLine("Žodžiai, kurie yra faile {0}, bet nėra faile {1} ir kartojasi tik vieną kartą:", in1, in2);
                    writer.WriteLine("Žodžių skaičius: {0}", Task1Words.Count);
                    for (int i = 0; i < Task1Words.Count; i++)
                    {
                        if (i < 10)
                        {
                            writer.WriteLine(Task1Words[i]);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("{0} yra tusčias.", in1);
                }
            }
        }
        public static void PrintDuplicates(List<WordInfo> Task2WordsSorted, string out1)
        {
            using (StreamWriter writer = new StreamWriter(out1, true))
            {
                writer.WriteLine(" ");
                writer.WriteLine("Žodžiai, kurie yra abiejose failuose:");
                if (Task2WordsSorted.Count > 0)
                {
                    writer.WriteLine("Žodžių skaičius: {0}", Task2WordsSorted.Count);
                    for (int i = 0; i < Task2WordsSorted.Count; i++)
                    {
                        if (i < 10)
                        {
                            writer.WriteLine(Task2WordsSorted[i]);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Pasikartojanciu žodžiu masyvas tusčias arba nebuvo sudarytas.");
                }
            }
        }
        public static void MyBook(List<WordInfo> wordList1, List<WordInfo> wordList2, string out2)
        {
            int index1 = 0, index2 = 0;
            using (StreamWriter writer = new StreamWriter(out2))
            {
                while (index1 < wordList1.Count || index2 < wordList2.Count)
                {
                    index1 = Copy(wordList1, wordList2, index1, index2, writer);
                    index2 = Copy(wordList2, wordList1, index2, index1, writer);
                }
            }
        }
        private static int Copy(List<WordInfo> wordList1, List<WordInfo> wordList2, int index1, int index2, StreamWriter writer)
        {
            while (index1 < wordList1.Count)
            {
                WordInfo word = wordList1[index1];
                if (index2 < wordList2.Count && !wordList2[index2].Copied && wordList2[index2].Word.Equals(word))
                {
                    return index1;
                }
                if (index1 % 10 == 0)
                {
                    writer.WriteLine(word + " ");
                }
                else
                {
                    writer.Write(word + " ");
                }
                word.Copied = true;
                index1++;
            }
            return index1;
        }
    }
}
