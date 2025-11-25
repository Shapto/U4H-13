using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace U4H_13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string in1 = "Knyga1s.txt";
            const string in2 = "Knyga2s.txt";
            const string out1 = "Rodikliai.txt";
            const string out2 = "ManoKnyga.txt";
            char[] punctuation = { ' ', '.', ',', '!', '?', ':', ';', '(', ')', '-', '\t', '\n'};
            File.Delete(out1); //Deletes result files if they exist
            File.Delete(out2);
            List<WordInfo> wordList1 = InOut.ReadWords(in1, in2, punctuation); //Creates word lists
            List<WordInfo> wordList2 = InOut.ReadWords(in2, in1, punctuation);
            List<string> Task1Words = TaskUtils.NonDuplicates(wordList1); //Creates and prints non duplicates
            InOut.PrintNonDuplicates(Task1Words, out1, in1, in2);
            List<WordInfo> Task2Words = TaskUtils.DuplicateWords(wordList1, wordList2); //Gets words from both files, sorts and prints them into the first output file
            List<WordInfo> Task2WordsSorted = TaskUtils.Sort(Task2Words);
            InOut.PrintDuplicates(Task2WordsSorted, out1);
            InOut.MyBook(in1, in2, out2, wordList1, wordList2, punctuation); //Appends text according to the task's rules into the second output file.
        }
    }
}
