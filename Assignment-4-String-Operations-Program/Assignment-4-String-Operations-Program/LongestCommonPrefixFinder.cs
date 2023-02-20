using System;

namespace StringFunctionsRelatedProblemStatements
{
    class LongestCommonPrefixFinder
    {
        internal string[] userInputStringArray = new string[100];
        internal string userInput = "";
       internal void longestCommonPrefixFinderFunction()
	    {
            Console.WriteLine("\n\nEnter any sentence:");
            userInputChecker:
            userInput = Console.ReadLine();
            userInputStringArray = userInput.Split();
                if (userInputStringArray.Length == 0)
                {
                    Console.WriteLine("\n\nField Should Not Be Null..! Enter any Sentence:");
                goto userInputChecker;
                    
                }
                else if (userInputStringArray.Length == 1)
                {
                    Console.WriteLine("Longest Common Prefix: {0}",userInputStringArray[0]);
                }
                else
                {
                    string shortest = userInputStringArray[0];
                    foreach(string subString in userInputStringArray)    
                    {
                        if (subString.Length < shortest.Length)
                        {
                            shortest = subString;
                        }
                    }   
                    for (int i = 0; i < shortest.Length; i++)
                    {
                        char singleCharacter = shortest[i];
                        for (int j = 0; j < userInputStringArray.Length; j++)
                        {
                            if (userInputStringArray[j][i] != singleCharacter)
                            {
                                // The characters don't match, so return the prefix up to this point
                                Console.WriteLine("Longest Common Prefix: {0}",shortest.Substring(0, i));
                            }
                        }
                    }

                // All strings have the same prefix
                Console.WriteLine("Longest Common Prefix: {0}", shortest);
            }

        }
    }
}
