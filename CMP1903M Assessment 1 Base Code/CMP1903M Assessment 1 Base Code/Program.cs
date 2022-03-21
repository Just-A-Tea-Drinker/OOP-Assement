//Base code project for CMP1903M Assessment 1
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_1_Base_Code
{

    class Program
    {
        static void Main()
        {
            //Local list of integers to hold the first five measurements of the text
            List<int> parameters = new List<int>();

            //Create 'Input' object
            //Get either manually entered text, or text from a file
            Input input = new Input();
            if(input.GetChoice() == "text file") //an object attribute is tested 
            {
                while (true)
                {
                    try
                    {
                        //file path testing is sent to input class to be tested to be valid
                        Console.WriteLine("\nPlease enter the file path.\n");
                        string Filepath =  Console.ReadLine();

                        // small amount of string formating so a raw string can be inputed
                        Filepath = Filepath.Trim(new char [] {'"'});
                        Console.WriteLine(Filepath);
                        Filepath = @"" + Filepath;
                        
                        input.fileTextInput(Filepath);

                        //this if statement essentially tests if there is anything worth running into the analyse object
                        if (input.text != null)
                        {
                            break;
                        }
                        
                        
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            //if the attribute test is false this then a method in the input class
            else
            {
                while (true)
                {
                    try
                    {
                        input.manualTextInput();
                        if(input.text != null)// again same test is performed to validate if the analyse object should be created
                        {
                            break;
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                
            }
            
            //Create an 'Analyse' object
            //Pass the text input to the 'analyseText' method

            Analyse analyse = new Analyse();
            analyse.analyseText(input.text);
            //Receive a list of integers back
            LetterFreq Lettercount = new LetterFreq();
            var LetterFrequency = Lettercount.Get_Freq_letter(input.text);

            //Report the results of the analysis

            //creating a reporting object
            Report Output = new Report();
            Output.outputConsole(analyse.values);

            //Report the frequency of individual letters?
            Output.FrequencyOut(LetterFrequency);



            

        }   
        
    }

    






}
