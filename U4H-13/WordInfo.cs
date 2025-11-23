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
        public WordInfo (bool duplicate, int count, string word)
        {
            Duplicate = duplicate;
            Count = count;
            Word = word;
        }
        public override string ToString()
        {
            string line;
            line = String.Format("{0}", Word);
            return line;
        }
        public int CompareTo(WordInfo other)
        {
            int comparison;
            comparison = Count.CompareTo(other.Count);
            if (comparison != 0)
            {
                return comparison;
            }
            return string.Compare(Word, other.Word, StringComparison.OrdinalIgnoreCase);
        }
        public override bool Equals(object obj)
        {
            WordInfo other = (WordInfo)obj;
            return string.Equals(Word, other.Word, StringComparison.OrdinalIgnoreCase);
        }
        public override int GetHashCode()
        {
            return Word.ToLowerInvariant().GetHashCode();
        }
    }
}
