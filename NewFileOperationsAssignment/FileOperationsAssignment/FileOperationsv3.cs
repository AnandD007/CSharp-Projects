using System.Text.RegularExpressions;

namespace FileOperationsAssignment
{
    class FileOperationsv3
    {
        internal static void Main(string[] args)
        {
            Console.WriteLine("\n1. Create/Open File to Write and Copy the Content from Another File\n\n2. Display all given file content and ask user given word from existing file content to Replace\n\n3. Display Last Line of the given file with it's file name\n\n4. Exit");
            Console.Write("\n\nEnter the Correct user choice: ");
            string userChoice = Console.ReadLine();
            Regex onlyForNumbers = new Regex(@"[\d]$");
            while(userChoice.Length == 0)
            {
                Console.Write("\n\nInput Field should not be null..!\n\nEnter the Correct user choice: ");
                userChoice = Console.ReadLine();
            }
            while(!(onlyForNumbers.IsMatch(userChoice)))
            {
                Console.Write("\n\nInvalid Input Entered..!\n\nEnter the Correct user choice: ");
                userChoice = Console.ReadLine();
            }
            while (Convert.ToInt16(userChoice) <= 0 || Convert.ToInt16(userChoice) > 4)
            {
                Console.Write("\n\nInvalid Input Entered..!\n\nEnter the Correct user choice: ");
                userChoice = Console.ReadLine();
            }
                switch (userChoice)
            {
                case "1":
                    CreateFileNCopyContent userFileObject = new CreateFileNCopyContent();
                    userFileObject.FileCreateCopy();
                    break;
                case "2":
                    ReplaceFileContents userFileObject2 = new ReplaceFileContents();
                    userFileObject2.ReplaceFileContentFunction();
                    break;
                case "3":
                    DisplayLastLine userFileObject3 = new DisplayLastLine();
                    userFileObject3.DisplayLastNameFunction();
                    break;
                case "4":
                    Console.WriteLine("\nThank You For Using Our Service");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid Option Entered");
                    break;
            }

        }
    }

    public class FileNotFoundException : Exception
    {
        public void FileNotFoundFunction()
        {
            Console.WriteLine("Invalid User Input Entered..!\n\nFile Not Found within the given directory");
        }
    }

    public class DirectoryNotFoundException : Exception
    {
        public void DirectoryNotFoundFunction()
        {
            Console.WriteLine("Invalid User Input Entered..!\n\nGiven directory is Incorrect.");
        }
    }
    public class UnauthorizedAccessException : Exception
    {
        public void UnauthorizedAccessFunction()
        {
            Console.WriteLine("Invalid User Input Entered..!\n\nUser is not authorized to modify files.");
        }
    }
    
}
