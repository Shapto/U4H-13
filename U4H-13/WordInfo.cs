using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U4H_13
{
    class WordInfo
    {
        /// <summary>
        /// Word information
        /// </summary>
        public bool Duplicate { get; set; }
        public bool Copied { get; set; }
        public int Count { get; set; }
        public string Word { get; set; }
        public WordInfo (bool duplicate, int count, string word, bool copied)
        {
            Duplicate = duplicate;
            Count = count;
            Word = word;
            Copied = copied;
        }
        /// <summary>
        /// Prints only the word and no other information if printing only the word object.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string line;
            line = String.Format("{0}", Word);
            return line;
        }
        /// <summary>
        /// Used for sorting. first sorts by count and then by the ABCs using Word string.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Needed to compare only by word, so capitalized words arent treated any different when adding to a list.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
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
