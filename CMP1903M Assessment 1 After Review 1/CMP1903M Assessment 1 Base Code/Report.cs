using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_1_Base_Code
{
    class Report
    {

        public void outputConsole(List<int> values)
        {
            try
            {
                if (values != null)
                {
                    //Prints out the respective values in the list to the values stored
                    Console.WriteLine($"The number of Sentences are:{values[0]}\n" +
                    $"The number of Vowels are: { values[1]}\n" +
                    $"The number of Consonants are: { values[2]}\n" +
                    $"The number of Upper case letters are: { values[3]}\n" +
                    $"The number of Lower case letters are: { values[4]}\n");
                    
                }
                else
                {
                    throw new Exception("Critical Error: Analysis not values not found"); // catches added to avoid any fatal errors
                }
            }
            catch (Exception ex5)
            {
                Console.WriteLine(ex5.Message);
            }
        


    }
        //Handles the reporting of the analysis
        //Maybe have different methods for different formats of output?
        //eg.   public void outputConsole(List<int>)
        public void FrequencyOut(Dictionary<string,int>Values)
        {
            try
            {
                if(Values != null)
                {
                    foreach (var kvp in Values) //Spits out all of the keys and the values of dictionary
                    {
                        Console.WriteLine("Key: {0}, Value: {1}", kvp.Key, kvp.Value);
                    }
                }
                else
                {
                    throw new Exception("Critical Error: Dictionary key and/or values not found"); // catches added to avoid any fatal errors
                }
            }
           catch(Exception ex7)
            {
                Console.WriteLine(ex7.Message);
            }
               
        }
        public void GetLargeWords()
        {
            // using the previously made file the file is read and the length is taken from the array as the previous class was static and i couldnt edit a public value
            string WordsFile = @"F:\Uni work\Semester B\Object Orientated Programming\Assessments\Assessment 1\OOP Assessments\CMP1903M Assessment 1 After Review 1\Long Words.txt";
            string[] words = File.ReadAllLines(WordsFile);
            int Length = words.Length;
            Console.WriteLine("\nThere are: {0} long words found\n ", Length);
        }
    }
}
