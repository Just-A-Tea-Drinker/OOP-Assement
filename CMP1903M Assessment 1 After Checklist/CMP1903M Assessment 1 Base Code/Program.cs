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
            while (true)
            {
                //Local list of integers to hold the first five measurements of the text
                List<int> parameters = new List<int>();

                //Create 'Input' object
                //Get either manually entered text, or text from a file
                Input input = new Input();
                if (input.GetChoice() == "text file") //an object attribute is tested 
                {
                    input.FileText();
                }
                //if the attribute test is false this then a method in the input class
                else
                {
                    while (true)
                    {
                        try
                        {
                            input.manualTextInput();
                            if (input.text != "")// again same test is performed to validate if the analyse object should be created
                            {
                                break;
                            }
                            else
                            {
                                throw new Exception("You havent inputted any text that can be analysed");
                            }
                        }
                        catch (Exception ex1)
                        {
                            Console.WriteLine(ex1.Message);
                        }
                    }

                }
                // added the if statement in order to stop the execution if the text is empty
                if (input.text != "")
                {
                    //Create an 'Analyse' object
                    //Pass the text input to the 'analyseText' method

                    Analyse analyse = new Analyse();
                    analyse.analyseText(input.text);
                    //Receive a list of integers back

                    //Obtaining if there are any words larger 7 characters
                    Analyse.Word7Letters(input.text);

                    //Counting the frequencies of the letters in the alphabet
                    LetterFreq Lettercount = new LetterFreq();
                    var LetterFrequency = Lettercount.Get_Freq_letter(input.text);



                    //Report the results of the analysis

                    //creating a reporting object
                    Report Output = new Report();

                    //Reporting the amaount of 'Large Words'
                    Output.GetLargeWords();
                    Output.outputConsole(analyse.values);

                    //Report the frequency of individual letters?
                    Output.FrequencyOut(LetterFrequency);
                }

                // section will handle the quit command if the user wants to quit or do another round of the program
                while (true)
                {
                    try
                    {
                        Console.WriteLine("\nWould you like to analyse more text?\nTyping 'yes' will restart the program. Typing 'no' will end the program.\n");
                        string ToRestart = (Console.ReadLine()).ToLower();
                        if (ToRestart == "no")
                        {
                            System.Environment.Exit(0); //This will allow the program to terminate upon a users choice
                        }
                        else if (ToRestart == "yes")
                        {
                            Console.WriteLine(" \n");
                            break;
                        }
                        else
                        {
                            throw new Exception("You havent selected a valid input option"); // relevant catch to allow input control
                        }
                    }
                    catch (Exception ex2)
                    {
                        Console.WriteLine(ex2.Message);
                    }

                }

            }







        } 
    }

    






}
