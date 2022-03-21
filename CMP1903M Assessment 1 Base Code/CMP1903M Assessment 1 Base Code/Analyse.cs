using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_1_Base_Code
{
    public static class Extensions
    {
        //Essentially this fucntion allows me to to find an element in a speicified list
        public static bool find<T>(this List<T> list, T target)
        {
            return list.Contains(target);
        }
  
    }

    //class dedicated to finding the frequency of the letters in the alphabet of the given text or file
    public class LetterFreq
    {
        public Dictionary<string,int> Get_Freq_letter(string input)
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
    public class Analyse
    {
        //Handles the analysis of text

        //Method: analyseText
        //Arguments: string
        //Returns: list of integers
        //Calculates and returns an analysis of the text
        public List<int> values = new List<int>();
        public List<int> analyseText(string input)
        {
            int senNum = 0;
            int vowNum = 0;
            int conNum = 0;
            int upperCase = 0;
            int lowerCase = 0;



            List<string> vowels = new List<string> { "A", "a", "E", "e", "I", "i", "O", "o", "U", "u" };




            //List of integers to hold the first five measurements:
            //1. Number of sentences
            //2. Number of vowels
            //3. Number of consonants
            //4. Number of upper case letters
            //5. Number of lower case letters

            //Initialise all the values in the list to '0'
            for (int i = 0; i < 5; i++)
            {
                values.Add(0);
            }
            //One large for loop which will cycle through all of the characters in the input text
            foreach (char c in input)
            {
                bool isExist = vowels.find(c.ToString());
                // Counts how man sentences there are
                if ((c.ToString()) == ".")
                {
                    senNum++;
                }

                //small object created in order find an element in a given list to check if the character is a vowels
                else if (isExist)
                {
                    //adds both to the count to vowels and capital letters if they are detected
                    if ((c.ToString() == vowels[0]) || (c.ToString() == vowels[2]) || (c.ToString() == vowels[4]) || (c.ToString() == vowels[6]) || (c.ToString() == vowels[8]))
                    {
                        upperCase++;
                        vowNum++;
                    }
                    else
                    {
                        vowNum++;
                        lowerCase++;


                    }

                }
                else
                {
                    //As the character is tested as vowel before the consonant then you dont have to think about encountering it is the 'else' section

                    //if c is equal to a letter between A and Z but not in the vowels at certain places than an upper case is added

                    if ((c >= 'A' && c <= 'Z'))// this works as the values are compared to their ASCII values
                    {
                        upperCase++;
                        conNum++;
                    }
                    //if c is equal to a letter between a and z but not in the vowels at certain places than an lower case is added
                    else if ((c >= 'a' && c <= 'z'))// this works as the values are compared to their ASCII values
                    {
                        lowerCase++;
                        conNum++;
                    }
                }


            }
            //small section made just to assign the various counters to their respective indexes in the list
            values[0] = senNum;
            values[1] = vowNum;
            values[2] = conNum;
            values[3] = upperCase;
            values[4] = lowerCase;



            //public string is returned to the program class
            return values;
        }

    }




}
