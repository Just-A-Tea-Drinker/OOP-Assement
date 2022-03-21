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
            //Prints out the respective values in the list to the values stored
            Console.WriteLine($"The number of Sentences are:{values[0]}\n" +
            $"The number of Vowels are: { values[1]}\n" +
            $"The number of Consonants are: { values[2]}\n" +
            $"The number of Upper case letters are: { values[3]}\n" +
            $"The number of Lower case letters are: { values[4]}\n");

        }
        //Handles the reporting of the analysis
        //Maybe have different methods for different formats of output?
        //eg.   public void outputConsole(List<int>)
        public void FrequencyOut(Dictionary<string,int>Values)
        {
            foreach (var kvp in Values) //Spits out all of the keys and the values of dictionary
            {
                Console.WriteLine("Key: {0}, Value: {1}", kvp.Key, kvp.Value);
            }
               
        }
    }
}
