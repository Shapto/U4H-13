using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace U4H_13
{
    class InOut
    {
        /// <summary>
        /// Reads words, makes an object containing its information and adds them to a list
        /// </summary>
        /// <param name="in1">first input file</param>
        /// <param name="in2">second input file</param>
        /// <param name="punctuation">char[] which contains all punctuation</param>
        /// <returns></returns>
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
                        if (TaskUtils.ExistsInFile(word, in2))
                        {
                            int count = TaskUtils.CountOccurences(in1, word) + TaskUtils.CountOccurences(in2, word);
                            WordInfo word1 = new WordInfo(true, count, word, false);
                            wordList.Add(word1);
                        }
                        else
                        {
                            WordInfo word1 = new WordInfo(false, TaskUtils.CountOccurences(in1, word), word, false);
                            wordList.Add(word1);
                        }
                    }
                }
            }
            return wordList;
        }

        /// <summary>
        /// Writes total word count and the first 10 elements the string list
        /// </summary>
        /// <param name="Task1Words">contains words which arent in the second file</param>
        /// <param name="out1">first output file</param>
        /// <param name="in1">first input file</param>
        /// <param name="in2">second input file</param>
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
                        else
                        {
                            return;
                        }
                    }
                }
                else
                {
                    writer.WriteLine("{0} yra tusčias arba abu failai yra tie patys.", in1);
                }
            }
        }

        /// <summary>
        /// Prints words which are in both lists, after being sorted in main.
        /// </summary>
        /// <param name="Task2WordsSorted">Sorted WordInfo list containing repeating words.</param>
        /// <param name="out1">first output file</param>
        public static void PrintDuplicates(List<WordInfo> Task2WordsSorted, string out1)
        {
            using (StreamWriter writer = new StreamWriter(out1, true))
            {
                writer.WriteLine(" ");
                if (Task2WordsSorted.Count > 0)
                {
                    writer.WriteLine("Žodžiai, kurie yra abiejose failuose:");
                    writer.WriteLine("Žodžių skaičius: {0}", Task2WordsSorted.Count);
                    for (int i = 0; i < Task2WordsSorted.Count; i++)
                    {
                        if (i < 10)
                        {
                            writer.WriteLine(Task2WordsSorted[i]);
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                else
                {
                    writer.WriteLine("Pasikartojanciu žodžiu masyvas tusčias arba nebuvo sudarytas.");
                }
            }
        }

        /// <summary>
        /// Writes text from both files into one singular file according to the task's rules
        /// </summary>
        /// <param name="in1">the first list containing words</param>
        /// <param name="in2">the first list containing words</param>
        /// <param name="out2">the second output file</param>
        public static void MyBook(string in1, string in2, string out2, List<WordInfo> wordList1, List<WordInfo> wordList2, char[] punctuation)
        {
            using (StreamReader reader1 = new StreamReader(in1))
            {
                using (StreamReader reader2 = new StreamReader(in2))
                {
                    using (StreamWriter writer = new StreamWriter(out2, true))
                    {
                        string line1 = "a", line2 = "b";
                        while (!reader1.EndOfStream || !reader2.EndOfStream)
                        {
                            if (!reader1.EndOfStream)
                            {
                                line1 = reader1.ReadLine();
                                Write(writer, line1, punctuation, wordList2);
                            }
                            if (!reader2.EndOfStream)
                            {
                                line2 = reader2.ReadLine();
                                Write(writer, line2, punctuation, wordList1);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Finds and gets the index of a word in the word list. If not found, returns -1.
        /// </summary>
        /// <param name="word">input word from the Write() function</param>
        /// <param name="wordList">list containing the words that will be checked</param>
        /// <returns></returns>
        private static int GetWordIndex(string word, List<WordInfo> wordList)
        {
            int index = -1;
            for (int i = 0; i < wordList.Count; i++)
            {
                if(word ==  wordList[i].Word)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        /// <summary>
        /// Writes words and punctuation according to the task rules. If there was even a single word written to the line, it can create a linebreak.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="line"></param>
        /// <param name="punctuation"></param>
        /// <param name="wordList"></param>
        private static void Write(StreamWriter writer, string line, char[] punctuation, List<WordInfo> wordList)
        {
            bool writtenToLine = false;
            foreach (Match match in Regex.Matches(line, @"\S+|\s"))
            {
                string temp = match.Value;
                if (!string.IsNullOrWhiteSpace(temp) && temp != "\n")
                {
                    string temp1 = match.Value.TrimEnd(punctuation);
                    int index = GetWordIndex(temp1, wordList);
                    if (index != -1 && wordList[index].Duplicate && !wordList[index].Copied)
                    {
                        if (writtenToLine)
                        {
                            writer.Write('\n');
                        }
                        break;
                    }
                    writer.Write(temp);
                    writtenToLine = true;
                }
                else
                {
                    writer.Write(temp);
                }
            }
        }
    }
}
