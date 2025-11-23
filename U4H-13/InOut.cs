using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U4H_13
{
    class InOut
    {
        public static void Process(string in1, string in2, string out1, char[] punctuation)
        {
            using (StreamReader reader = new StreamReader(in1))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] words = line.Split(punctuation, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string word in words)
                    {
                        if(TaskUtils.ExistsInFile(word, in2, punctuation))
                        {
                            continue;
                        }
                        int count = TaskUtils.CountOccurences(in1, word, punctuation);
                    }
                }
            }
        }
    }
}
