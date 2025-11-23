using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U4H_13
{
    class WordInfo
    {
        public bool Duplicate { get; set; }
        public int Count { get; set; }
        public string Word { get; set; }
        public WordInfo (bool duplicate, bool copied, int count, string word)
        {
            Duplicate = duplicate;
            Count = count;
            Word = word;
        }
    }
}
