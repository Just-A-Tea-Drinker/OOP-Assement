using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_1_Base_Code
{
    public class LetterFrequency
    {
        //class dedicated to finding the frequency of the letters in the alphabet of the given text or file this is a form of data abstraction.
        public Dictionary<string, int> Get_Freq_letter(string input)
        {

            char[] Alpha = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

            //formatting done in order to avoid clashed with capital letters
            input = input.ToLower();

            int frequency = 0;
            Dictionary<string, int> LetterCount = new Dictionary<string, int> { };

            //makes sure again that there is some data sort in case of error
            if (input.Length > 0)
            {

                // for loop dedicatd to repeating over the alphabet array that was declared
                for (int i = 0; i < Alpha.Length; i++)
                {
                    //loops through every character in text to find all instances of the value of Alpha
                    foreach (char c in input)
                    {
                        // when an instance of Alpha[i] is found the frequency is increased
                        if (c == Alpha[i])
                        {
                            frequency++;
                        }
                    }
                    // After the foreach loop is complete the Alpha[i] is stored  as the key and frequency is the value
                    LetterCount.Add((Alpha[i].ToString()), frequency);

                    //the frequency is reset for the next letter or element in Alpha
                    frequency = 0;
                }

            }
            return LetterCount;
        }



    }
}
