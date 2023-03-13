using System.Text.RegularExpressions;

namespace FileOperationsAssignment
{
    public class FileNotFoundException : Exception
    {
        public void FileNotFoundFunction()
        {
            Console.WriteLine("Invalid User Input Entered..!\n\nFile Not Found within the given directory");
        }
    }
    public class FileFoundException : Exception
    {
        public void FileFoundFunction()
        {
            Console.WriteLine("Unable to Upload Given File Name..!\n\nFile Found within the given directory");
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
    class FileUploaderOperations
    {
        internal static void Main(string[] args)
        {
            Console.WriteLine("\n1. Choose Multiple files to Upload in another given directory\n\n2. Display all given files upload loading status \n\n3. Exit");
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
            while (Convert.ToInt16(userChoice) <= 0 || Convert.ToInt16(userChoice) > 3)
            {
                Console.Write("\n\nInvalid Input Entered..!\n\nEnter the Correct user choice: ");
                userChoice = Console.ReadLine();
            }
                switch (userChoice)
            {
                case "1":
                    FilesUploader userFileObject = new FilesUploader();
                    userFileObject.MultipleFilesUploader();
                    break;
                case "2":
                    FileProgressBar userFileObject2 = new FileProgressBar();
                    userFileObject2.FileProgress();
                    break;
                case "3":
                    Console.WriteLine("\nThank You For Using Our Service");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid Option Entered");
                    Console.WriteLine("\n\nThank You For Using Our Service");
                    break;
            }

        }
    }

    
    
}
