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
            //dont read the entire file at once
            //skaityti faila su while loop
            //using (StreamReader reader = new StreamReader(fin))
            //string line;
            //while ((line = reader.ReadLine()) != null)

            //mano knyga.txt dalis uzduoties
            //kopijuoti text kol pasiekia zodi is antro failo
            //stop. vietoj to kopijuoti antra faila.
            //jei antrame faile yra zodis is pirmo, tai reverse
            //copy kol pasiekiama abieju failu pabaiga

            const string in1 = "Knyga1.txt";
            const string in2 = "Knyga2.txt";
            const string out1 = "Rodikliai.txt";
            const string out2 = "ManoKnyga.txt";
            char[] punctuation = { ' ', '.', ',', '!', '?', ':', ';', '(', ')', '\t' };
            File.Delete(out1);
            File.Delete(out2);
        }
    }
}
