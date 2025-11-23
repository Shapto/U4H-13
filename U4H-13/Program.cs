using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U4H_13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //streamreader, regex, string metodai
            const string in1 = "Knyga1.txt";
            const string in2 = "Knyga2.txt";
            const string out1 = "Rodikliai.txt";
            const string out2 = "ManoKnyga.txt";
            char[] punctuation = { ' ', '.', ',', '!', '?', ':', ';', '(', ')', '\t' };
            File.Delete(out1);
            File.Delete(out2);
            List<WordInfo> wordList1 = InOut.ReadWords(in1, in2, punctuation);
            List<WordInfo> wordList2 = InOut.ReadWords(in2, in1, punctuation);
            List<string> Task1Words = TaskUtils.NonDuplicates(wordList1);
            InOut.PrintNonDuplicates(Task1Words, out1, in1, in2);
            List<WordInfo> Task2Words = TaskUtils.DuplicateWords(wordList1, wordList2);
            List<WordInfo> Task2WordsSorted = TaskUtils.Sort(Task2Words);
            InOut.PrintDuplicates(Task2WordsSorted, out1);

        }
    }
}
