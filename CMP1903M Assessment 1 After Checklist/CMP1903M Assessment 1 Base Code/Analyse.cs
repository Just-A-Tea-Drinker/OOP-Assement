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
        public int Longwords;
        public List<int> analyseText(string input)
        {
 
            char[] vowels = { 'A', 'a', 'E', 'e', 'I', 'i', 'O', 'o', 'U', 'u' };
            int StopCheck = 1;


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
            //One large for loop which will cycle through all of the characters in the input text using string indexing
            //Updates made are that the values are updated directly to the list rather than a set or variables making the code hopefully more effiecent
            for( int c = 0; c < input.Length; c++)
            {
                if ((input[c] == '.')|| (input[c] == '!')|| (input[c] == '?'))// tests if the values are sentence ending values
                {
                    //tests if they values aren next to each and within index range
                    if (((input[(c + 1)] <= input.Length))&& (input[(c + 1)] != '.')&& (input[(c + 1)] != '!')&&(input[(c + 1)] != '?'))
                    {
                        values[0]++;
                    }
                    else
                    {
                        //tests how many values that are the same are next to eachother
                        while ((input[(c + StopCheck)] == '.')|| (input[(c + StopCheck)] == '!')|| (input[(c + StopCheck)] == '?'))
                        {
                            StopCheck++;
                        }
                        values[0]++;
                        c += StopCheck;
                        StopCheck = 1;
                    }
                } 
                //tests if the value is a vowel
                if (vowels.Contains(input[c]))
                {
                    if (char.IsUpper(input[c]))
                    {
                        values[3]++;
                        values[1]++;
                    }
                    else
                    {
                        values[4]++;
                        values[1]++;
                    }
                }
                else
                {
                    //using ASCII test whether the value is an upper case letter
                    if (input[c] >= 'A' && input[c] <= 'Z')
                    {
                        values[3]++;
                        values[2]++;
                    }
                    //Again using ASCII tests whether the value is lower case
                    else if (input[c] >= 'a' && input[c] <= 'z')
                    {
                        values[4]++;
                        values[2]++;
                    }
                }
            }
        
            //public string is returned to the program class
            return values;
        }
        // Small static function used in order to find all of the words longer/ or  7 characters
        public  static void Word7Letters(string input)
        {
            //This will take the input attribute 'text' and will split it down to calculate the length of a word
            string[] words = input.Split(' ',',','.','!','?','(',')','"',':',';','/' ); // splits on these to makes sure there arent any spaces commas or full stops
            string FileDestin = @"Long Words.txt";
            List<string> FileToWrite = new List<string>{ };

            foreach( var word in words)
            {
                if(word.Length >= 7)
                {
                    FileToWrite.Add(word);
                    
                }
            }
            //Using stream writer large words are written in a specific file
            using(TextWriter TW = new StreamWriter(FileDestin))
            {
                foreach(string entry in FileToWrite)
                {
                    TW.WriteLine(entry);
                }
            }
        
        }

    }




}
