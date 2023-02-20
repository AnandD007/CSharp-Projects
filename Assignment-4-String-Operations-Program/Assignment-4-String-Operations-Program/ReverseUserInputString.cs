using System;
using System.Text.RegularExpressions;

namespace StringFunctionsRelatedProblemStatements
{
    class ReverseUserInputString
    {
        internal string userInput;
        internal string[] stringArray;
        internal string reversedString = "";
        public void ReverseUserInputStringFunction()
        {
            Console.Write("\n\nEnter Any Sentence: ");
        
            userInputCheck:
            userInput = Console.ReadLine();
            stringArray = userInput.Split(' ');
            if (userInput.Length == 0)
            {
                Console.Write("\n\nInvalid String value..! Enter Any Sentence: ");
                goto userInputCheck;
            }
            foreach (string word in stringArray)
    {
        char[] letters = word.ToCharArray();
        Array.Reverse(letters);
        reversedString += new string (letters) + " ";
    }
    Console.WriteLine(reversedString.Trim());
        
        
        }
    }
}