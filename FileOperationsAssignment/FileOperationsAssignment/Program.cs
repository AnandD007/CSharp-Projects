
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters;
using System.Text.RegularExpressions;

namespace FileOperationsApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            FileOperations userFileObject = new FileOperations();
            userFileObject.FileOperationsFunction();
        }
    }

    internal class FileOperations
    {
        internal void FileOperationsFunction()
        {
        try 
            { 
            string existFilename;
            string[] userSelectedFiles = new string[100];
            string userFileNameInput;
            string[] allowedExtensions = { "png", "txt", "xls", "jpg" };
            int userFileCount;
            string userWriteFileName = "";
            string userFileWriteStatus = "";
            string[] extensionSplit = new string[10];
            string[] existFileExtensionSplit = new string[10];
            bool fileFoundStatus = false;
            bool fileFoundStatus2 = false;
            int fileCounter = 1;

            Regex onlyForNumbers = new Regex(@"[0-9]$");
            DirectoryInfo filePath = new DirectoryInfo(@"D:\c drive downloads\Assignment");
            FileInfo[] Files = filePath.GetFiles();
            Console.WriteLine("Files those Presents in your current directory:\n\n");

            // Display the file names

            foreach (FileInfo i in Files)
            {
                Console.WriteLine("{0}", i.Name.ToLower());
            }
            Console.Write("\n\nEnter How many files Do You want to upload:");
        userFileCountStringChecker:
            string userFileCountString = Console.ReadLine();
            if (userFileCountString == null || userFileCountString.Length == 0 || !(onlyForNumbers.IsMatch(userFileCountString)))
            {
                Console.Write("\n\nInvalid Input Entered....!\nEnter How many files Do You want to upload:");
                goto userFileCountStringChecker;
            }

            else if (Convert.ToInt16(onlyForNumbers.IsMatch(userFileCountString)) >= 0)
            {
                userFileCount = Convert.ToInt16(userFileCountString);
                if (userFileCount == 0)
                {
                    Console.WriteLine("\n\nThank You For Using Our Service");
                    Environment.Exit(0);
                }
            }
            else
            {
                Console.Write("\n\nInvalid Input Entered....!\nEnter How many files Do You want to upload:");
                goto userFileCountStringChecker;
            }

            for (int j = 0; j < userFileCount; j++)
            {
                Console.Write("\n\nEnter {0} File Name To Upload:", fileCounter);
            userFileNameInputChecker:
                userFileNameInput = Console.ReadLine().ToLower();
                foreach (FileInfo file in Files)
                {
                    extensionSplit = userFileNameInput.Split(".");
                    string userFileName = extensionSplit[0].ToLower();
                    foreach (FileInfo filer in Files)
                    {
                        if (userFileNameInput == filer.Name.ToLower())
                        {
                            fileFoundStatus = true;
                            break;
                        }
                    }

                    if ((userFileNameInput.Length) == 0)
                    {
                        Console.WriteLine($"File {userFileNameInput} does not exist and will not be uploaded.\nEnter {fileCounter} Correct File Name with extension to upload:");
                        goto userFileNameInputChecker;
                    }
                    else if (fileFoundStatus == true)
                    {
                        userSelectedFiles[j] = userFileNameInput;
                        existFileExtensionSplit = file.Name.Split(".");
                        existFilename = existFileExtensionSplit[0].ToLower();
                        string existFileExtension = existFileExtensionSplit[1].ToLower();
                        if (file.Name.ToLower() == userFileName)
                        {
                            if (!(allowedExtensions.Contains(extensionSplit[1])))
                            {
                                Console.WriteLine($"File {userFileNameInput} has an invalid extension and will not be uploaded.\nOnly .txt, .xls, .jpg, .png extensions are allowed...!\nEnter The {fileCounter} Correct File Name upload:");
                                goto userFileNameInputChecker;
                            }
                            else if (existFilename.ToLower() != userFileName)
                            {
                                Console.WriteLine($"File {userFileNameInput} does not exist and will not be uploaded.\nEnter The {fileCounter} Correct File Name upload:");
                                goto userFileNameInputChecker;
                            }
                            else if (userFileNameInput.EndsWith(".txt") || userFileNameInput.EndsWith(".jpg") || userFileNameInput.EndsWith(".xls") || userFileNameInput.EndsWith(".png"))
                            {
                                string userFileExtension = extensionSplit[1].ToLower();
                            }
                            else if (!(userFileNameInput.EndsWith(".txt") || userFileNameInput.EndsWith(".jpg") || userFileNameInput.EndsWith(".xls") || userFileNameInput.EndsWith(".png")))
                            {
                                Console.Write($"File {userFileNameInput} has an invalid extension and will not be uploaded.\nOnly .txt, .xls, .jpg, .png extensions are allowed..!\n\nEnter {fileCounter} Correct File Name with extension to upload:");
                                goto userFileNameInputChecker;
                            }
                            else
                            {
                                Console.WriteLine($"File {userFileNameInput} does not exist and will not be uploaded.\nEnter The {fileCounter} Correct File Name upload:");
                                goto userFileNameInputChecker;
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine($"File {userFileNameInput} does not exist and will not be uploaded.\nEnter The Correct {fileCounter} File Name with extension to upload:");
                        goto userFileNameInputChecker;
                    }
                }
                fileCounter++;

            }
            Console.Write("Do You Want to Write/Insert Data within selected files(yes/no):");
        userFilesWriteStatusChecker:
            userFileWriteStatus = Console.ReadLine().ToLower();
            if (userFileWriteStatus == "yes" || userFileWriteStatus == "y")
            {
                Console.WriteLine("\nYour Selected File Names:");
                foreach (string k in userSelectedFiles)
                {
                    Console.Write("\n     {0}", k);
                }
            }
            else if (userFileWriteStatus == "no" || userFileWriteStatus == "n")
            {
                Console.WriteLine("\n\nThank You For Using Our Service\n");
                Environment.Exit(0);
            }
            else if (fileFoundStatus == false)
            {
                Console.Write("Entered Invalid Option...!\n\nEnter Correct Option");
                goto userFilesWriteStatusChecker;
            }

            Console.WriteLine("Please enter the name of the file you would like to write to:");
        userFilesWriteInputChecker:
            userWriteFileName = Console.ReadLine();
            foreach (FileInfo h in Files)
            {
                if (h.Name.ToLower() == userWriteFileName)
                {
                    fileFoundStatus2 = true;
                }
            }

            Console.WriteLine(userWriteFileName);
            if (fileFoundStatus2 == true)
            {
                //Console.Write("\n\nEnter File Name to Write the Data:");
                //string choice = Console.ReadLine().ToLower();
                extensionSplit = userWriteFileName.Split(".");
                if (allowedExtensions[1] == extensionSplit[1] && extensionSplit[1] == "txt")
                {
                    Console.WriteLine($"Writing to file {userWriteFileName}. Enter your text:");
                    string text = Console.ReadLine();
                    FileStream fileObject = new FileStream("D:\\c drive downloads\\Assignment\\" + userWriteFileName, FileMode.Append, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fileObject);
                    sw.Write(text);
                    sw.Flush();
                    sw.Close();
                    fileObject.Close();
                    Console.WriteLine($"Text written to file {userWriteFileName} successfully.");
                }
                else if (extensionSplit[1] != "txt" && allowedExtensions.Contains(extensionSplit[1]))
                {
                    Console.WriteLine($"\n{userWriteFileName}Unable To Write/Insert Data..!\n\nOnly Text Files are able to Write/Insert the data.");
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Operation cancelled...!\n\nOnly Text Files are able to Write/Insert the data.");
                    Environment.Exit(0);
                }
            }
            else if (fileFoundStatus2 != true)
            {
                Console.Write($"\n\nUnable to Write the {userWriteFileName} file. \n\nChoose another File to Write or Enter exit:");
                goto userFilesWriteInputChecker;
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine("Error: "+ex.Message);
        }
        }
    }
}