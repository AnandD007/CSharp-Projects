using System;
using System.Text.RegularExpressions;

namespace StringFunctionsRelatedProblemStatements
{
    class DuplicateLettersRemover
    {
        internal string userInput = "";
        internal char letter;
        internal string resultString = "";
        public void duplicateLettersRemoverFunction()
        {
            Console.Write("\n\nEnter any string value:");
            userInputChecker:
            userInput = Console.ReadLine();

            if (userInput.Length == 0)
            {
                Console.WriteLine("\n\nField Should Not Be Null..! Enter any Sentence:");
                goto userInputChecker;
            }
            foreach (char letter in userInput)
            {
                if (resultString.IndexOf(letter) == -1)
                {
                    resultString += letter;
                }
            }

            Console.WriteLine("All Duplicate Values Are Removed..! \nDistinct letters:{0}",resultString);  
        }


    }

}
