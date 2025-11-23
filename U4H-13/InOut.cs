using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
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
                            WordInfo word1 = new WordInfo(true, count, word);
                            wordList.Add(word1);
                        }
                        else
                        {
                            WordInfo word1 = new WordInfo(false, TaskUtils.CountOccurences(in1, word, punctuation), word);
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
                writer.WriteLine("Žodžiai, kurie yra faile {0}, bet nėra faile {1} ir kartojasi tik vieną kartą:", in1, in2);
                writer.WriteLine("Žodžių skaičius: {0}", Task1Words.Count);
                if (Task1Words.Count > 0)
                {
                    for (int i = 0; i < Task1Words.Count; i++)
                    {
                        writer.WriteLine(Task1Words[i]);
                    }
                }
                else
                {
                    Console.WriteLine("{0} yra tusčias.", in1);
                }
            }
        }
    }
}
