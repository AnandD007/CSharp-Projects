using System;
using System.Text.RegularExpressions;

namespace StringFunctionsRelatedProblemStatements
    {
        class Program
        {
        
            internal static void Main(string[] args) 
            {
            Regex checkUserInput = new Regex(@"[0-6]$");
            string choice = "";
            Console.WriteLine("String Function Related Problem Solutions:");
            Console.WriteLine("1.Find The Longest Common Prefix\n2.Counting Line from a string\n3.All String Functions Implimented Class Program\n4.Reverse the each word from the string\n5.Duplicate Character Remover\n6.Exit");
            Console.Write("\n\nEnter Your Choice To Run Program:");
            choiceChecker:
            choice = Console.ReadLine();

            if(!(checkUserInput.IsMatch(choice)) || string.IsNullOrEmpty(choice) || string.IsNullOrWhiteSpace(choice))
            {
                Console.Write("\n\nInvalid Choice Entered..! Enter Your Choice To Run Program:");
                goto choiceChecker;
            }
            
            switch (choice)
            {
                case "1": 
                    LongestCommonPrefixFinder userInput1 = new LongestCommonPrefixFinder();
                    userInput1.longestCommonPrefixFinderFunction();
                    break;
                case "2":
                    CountTheSentencesFromInputString userInput2 = new CountTheSentencesFromInputString();
                    userInput2.CountTheSentencesFromInputStringFunction();
                    break;
                case "3":
                    AllStringFunctions userInput3 = new AllStringFunctions();
                    
                    break;
                case "4":
                    ReverseUserInputString userInput4 = new ReverseUserInputString();
                    userInput4.ReverseUserInputStringFunction();
                    break;
                case "5":
                    DuplicateLettersRemover userInput5 = new DuplicateLettersRemover();
                    userInput5.duplicateLettersRemoverFunction();
                    break;
                case "6":
                    Console.WriteLine("Bye Bye..!");
                    Environment.Exit(0);
                    break;
                
            }
            
        }
        }
    }