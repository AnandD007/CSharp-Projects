using System;
using System.Text.RegularExpressions;

namespace StringFunctionsRelatedProblemStatements
{
    class CountTheSentencesFromInputString
    {
        internal string[] userInputStringArray = new string[100];
        internal string userInput = "";
        internal int sentenceCount;
              
        internal char[] letters = {'.','!','?'};
        internal void CountTheSentencesFromInputStringFunction()
        {
            Console.WriteLine("\n\nEnter any sentence:");
            userInputCheck:
            userInput = Console.ReadLine();
            sentenceCount = 0;
            if (userInput.Length == 0)
            {
                Console.Write("\n\nInvalid String value..!  Enter any string: ");
                goto userInputCheck;
            }

            userInputStringArray = userInput.Split(letters);
            foreach (string o in userInputStringArray)
            {
                Console.WriteLine(o);
                sentenceCount++;
            }
            Console.WriteLine("Total {0} Sentences present in given String.",sentenceCount);
        }
    }
}
