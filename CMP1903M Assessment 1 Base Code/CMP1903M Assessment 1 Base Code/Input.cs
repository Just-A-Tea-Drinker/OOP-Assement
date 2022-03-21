using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_1_Base_Code
{
    public class Input
    {
        //Handles the text input for Assessment 1

        //public values that are input fields that can be access directly by other classes
        public string option;
        public string text;
        public string GetChoice()
        {
            // will run continously if an unexpected input is givn with a relavent exception handle
            while (true)
            {
                try
                {
                    Console.WriteLine("Would you like to analyse text either through manual input or from a text file \nType 'manual' for manual input\nor\nType 'text file' to input a filepath");
                    string choice = Console.ReadLine().ToLower();// formatting to allow easy comparison

                    //if either one of the predetermined values is inputted the public string is updated to that value
                    if (choice == "manual")
                    {
                        option = choice;
                        return option;
                    }
                    else if(choice == "text file")
                    {
                        option = choice;
                        return option;
                    }
                    else
                    {
                        throw new Exception("\nYou have not selected a valid option.\n");// relevant error thrown if the input isnt valid
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message); // uses the throw to display the cusmtom message
                }
            }



        }

       
        //Method: fileTextInput //Method: manualTextInput
        //Arguments: none
        //Returns: string
        //Gets text input from the keyboard
        public string manualTextInput()
        {
            bool detected = false;
            string CompleteText = "";


            while(detected == false)// using a boolean switch it allows me to control the nested loops
            {
                Console.WriteLine("\nEnter a line of text.\nPlease use '*' to signify the end of an entry");
                string temp_string = Console.ReadLine();

                //tests each character in the inputted line  for the stop character
                foreach(char c in temp_string)
                {
                    if(c == '*')//if the stop character if detected the switch is flipped and the loop will terminate
                    {
                        detected = true;
                    }
                }

                //compiles the line and previous lines into a single string
                CompleteText = CompleteText + " " + temp_string + " ";
                temp_string = "";
            }
            text = CompleteText;// assignes the string to the public string
            return text;
        }

        //Arguments: string (the file path)
        //Returns: string
        //Gets text input from a .txt file

        //Custom method used in order to test whether the file path is valid or not.
        public string fileTextInput(string fileName)
        {
           
            while (true)
            {
                try
                {
                    //will try and call another method tp run the validation
                    text = FileCheck(fileName);
                    return text;
                }
                // here to catch any errors that could occur (file doesnt exist error)
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return text;
                }
            }
           
            
        }
        private static string FileCheck(string fileName)
        {
            // using a built in library to test whether that file exist in said file path
            if ((System.IO.File.Exists(fileName)) == false)
            {
                //calls the relevant catch phrase if there is an exception with a custom message
                throw new Exception($"\nThe path: { fileName } does NOT exist.\n");
            }
            else
            {
                string fileContents = "";
                bool ToStop = false;

                // function used to read the tet file line by line 
                foreach (string line in System.IO.File.ReadLines(fileName))
                {
                    // will check each line character by character in order to test whether the stop character is present
                    foreach (char c in line)
                    {
                        //if the stop character is present the boolean switch is activated
                        if(c == '*')
                        {
                            ToStop = true;
                            break;

                        }
                    }
                    fileContents = fileContents + " " + line;// comiles previous and the current lines into one large strings

                    //tests if the switch has been activated anf then kills the outer foreach loop
                    if (ToStop == true)
                    {
                        break;
                    }
                    
                }
                
                //sets the public string to the compiled string and then returns the control back to the program class
                string text = fileContents;
                return text;
                
            }
                    
        }

        

    }
}
