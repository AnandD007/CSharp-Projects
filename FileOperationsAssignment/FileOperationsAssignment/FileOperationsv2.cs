using OfficeOpenXml;
using System.Text.RegularExpressions;

namespace FileOperationsApplication
{
    class Program
    {
        internal static void Main(string[] args)
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
                bool userSelectedFileStatus = false;
                int cellCounter = 1;
                int userWorksheetCellCount = 0;
                string existFilename;
                string[] userSelectedFiles = new string[100];
                string userFileNameInput;
                string[] allowedExtensions = { "png", "txt", "xlsx", "jpg" };
                int userFileCount;
                string userWriteFileName;
                string userFileWriteStatus;
                string[] extensionSplit = new string[10];
                string[] existFileExtensionSplit = new string[10];
                bool fileFoundStatus = false;
                bool fileFoundStatus2 = false;
                int fileCounter = 1;


                Regex onlyForNumbers = new Regex(@"[0-9]$");
                DirectoryInfo filePath = new DirectoryInfo(@"D:\c drive downloads\Assignment");
                if (filePath == null || !(filePath.Exists))
                {
                    Console.WriteLine("\nInvalid File Path...!");
                    Environment.Exit(0);
                }
                FileInfo[] Files = filePath.GetFiles();
                Console.WriteLine("Files those Presents in your current directory:\n\n");

                // Display the file names

                foreach (FileInfo i in Files)
                {
                    Console.WriteLine("{0}", i.Name.ToLower());
                }
                Console.Write("\n\nEnter How many files Do You want to select/upload:");
            userFileCountStringChecker:
                string userFileCountString = Console.ReadLine();
                if (userFileCountString == null || userFileCountString.Length == 0 || !(onlyForNumbers.IsMatch(userFileCountString)))
                {
                    Console.Write("\n\nInvalid Input....!\nEnter How many files Do You want to select/upload:");
                    goto userFileCountStringChecker;
                }

                if (Convert.ToInt16(onlyForNumbers.IsMatch(userFileCountString)) >= 0)
                {
                    userFileCount = Convert.ToInt16(userFileCountString);
                    if (userFileCount == 0)
                    {
                        Console.WriteLine("\n\nThank You For Using Our Service");
                        Environment.Exit(0);
                    }
                    else if (userFileCount < 0)
                    {
                        Console.Write("\n\nInvalid Input....!\nEnter How many files Do You want to select/upload:");
                        goto userFileCountStringChecker;
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
                        string userExtension = extensionSplit[1].ToLower();
                        foreach (FileInfo filer in Files)
                        {
                            if (userFileNameInput == filer.Name.ToLower() && allowedExtensions.Contains(userExtension))
                            {
                                fileFoundStatus = true;
                                break;
                            }
                            else 
                            {
                                fileFoundStatus = false;
                            }
                        }

                        if ((userFileNameInput.Length) == 0)
                        {
                            Console.WriteLine($"Field should not be Null..!\n\nEnter {fileCounter} Correct File Name with extension to upload:");
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
                                    Console.WriteLine($"File {userFileNameInput} does not exist and will not be uploaded.\n\nEnter The {fileCounter} Correct File Name upload:");
                                    goto userFileNameInputChecker;
                                }
                                else if (userFileNameInput.EndsWith(".txt") || userFileNameInput.EndsWith(".jpg") || userFileNameInput.EndsWith(".xls") || userFileNameInput.EndsWith(".png") || userFileNameInput.EndsWith(".xlsx"))
                                {
                                    string userFileExtension = extensionSplit[1].ToLower();
                                }
                                else if (!(userFileNameInput.EndsWith(".txt") || userFileNameInput.EndsWith(".jpg") || userFileNameInput.EndsWith(".xls") || userFileNameInput.EndsWith(".png") || userFileNameInput.EndsWith(".xlsx")))
                                {
                                    Console.Write($"File {userFileNameInput} has an invalid extension and will not be uploaded.\n\nOnly .txt, .xls, .jpg, .png extensions are allowed..!\n\nEnter {fileCounter} Correct File Name with extension to upload:");
                                    goto userFileNameInputChecker;
                                }
                                else
                                {
                                    Console.WriteLine($"File {userFileNameInput} does not exist and will not be uploaded.\n\nEnter The {fileCounter} Correct File Name upload:");
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
                    int o = 1;
                    foreach (string k in userSelectedFiles)
                    {
                        if (k == null)
                        {
                            continue;
                        }
                        else
                        {
                            Console.Write("\n {0}: {1}\n",o, k);
                            o++;
                        }
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
                Console.Write("\nPlease enter the name of the file you would like to write to:");
            userFilesWriteInputChecker:
                userWriteFileName = Console.ReadLine();
                foreach( string k in userSelectedFiles)
                {
                    if(k == null)
                    {
                        
                    }
                    else if (k.ToLower() == userWriteFileName.ToLower())
                    {
                        fileFoundStatus2 = true;
                        userSelectedFileStatus = true;
                    }
                }
                if(userSelectedFileStatus == false)
                {
                    Console.Write("\nChoose the file from above selected files list only...!");
                    goto userFilesWriteInputChecker;
                }
                if (fileFoundStatus2 == true)
                {
                    extensionSplit = userWriteFileName.Split(".");
                    if (allowedExtensions[1] == extensionSplit[1] && extensionSplit[1] == "txt")
                    {
                        Console.WriteLine($"Writing to file {userWriteFileName}. Enter your text:");
                        string text = Console.ReadLine();
                        FileStream fileObject = new FileStream("D:\\c drive downloads\\Assignment\\" + userWriteFileName, FileMode.Append, FileAccess.Write);
                        StreamWriter sw = new StreamWriter(fileObject);
                        sw.WriteLine("\n" + text);
                        sw.Flush();
                        sw.Close();
                        fileObject.Close();
                        Console.WriteLine($"Text written to file {userWriteFileName} successfully.");
                    }
                    else if (extensionSplit[1] == "xls" || extensionSplit[1] == "xlsx")
                    {

                        // WorkBook workBook = WorkBook.Load(@"D:\c drive downloads\Assignment\"+ userWriteFileName);
                        string fileName = "D:\\c drive downloads\\Assignment\\" + userWriteFileName;
                        string createNewWorksheet;
                        string existingWorksheet;
                        string addWorksheet;
                        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                        ExcelPackage package = new ExcelPackage(new FileInfo(fileName));
                        Console.Write("\n\nEnter the name of the new Worksheet: ");
                        createNewWorksheet = Console.ReadLine();
                        while (createNewWorksheet.Length == 0)
                        {
                            Console.Write("\n\nField Should Not Be Null...!\n\nEnter the name of the new Worksheet: ");
                            createNewWorksheet = Console.ReadLine();

                        }
                        addWorksheet = createNewWorksheet;
                        ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(addWorksheet);
                    userWorksheetCountStringChecker:
                        Console.Write("\n\nEnter How many worksheet cells Do You want to insert:");
                        string userCellCountString = Console.ReadLine();
                        if (userCellCountString == null || userCellCountString.Length == 0 || !(onlyForNumbers.IsMatch(userCellCountString)))
                        {
                            Console.Write("\n\nInvalid Input....!\nEnter How many worksheet cells Do You want to insert:");
                            goto userWorksheetCountStringChecker;
                        }

                        if (Convert.ToInt16(onlyForNumbers.IsMatch(userCellCountString)) >= 0)
                        {
                            userWorksheetCellCount = Convert.ToInt16(userCellCountString);
                            if (userWorksheetCellCount == 0)
                            {
                                Console.WriteLine("\n\nThank You For Using Our Service");
                                Environment.Exit(0);
                            }
                            else if (userWorksheetCellCount < 0)
                            {
                                Console.Write("\n\nInvalid Input....!\nEnter How many worksheet cells Do You want to insert:");
                                goto userWorksheetCountStringChecker;
                            }
                        }
                        else
                        {
                            Console.Write("\n\nInvalid Input Entered....!\nEnter How many worksheet cells Do You want to insert:");
                            goto userWorksheetCountStringChecker;
                        }
                        for (int e = 0; e < userWorksheetCellCount; e++)
                        {
                            Console.WriteLine("Enter {0} Cell Name and Cell Value seperated by comma(,):", cellCounter);
                            string[] cell = Console.ReadLine().ToUpper().Split(',');
                            string cellValue = cell[1];
                            string cellName = cell[0].Replace("-", "");
                            while (cellName.Length == 0)
                            {
                                Console.Write("\n\nInvalid Input...!\n\nEnter the Correct Cell Name: ");
                                cellName = Console.ReadLine().ToUpper().Replace("-", "");
                            }
                            while (cellValue.Length == 0)
                            {
                                Console.Write("\n\nInvalid Input...!\n\nEnter the Correct Cell Value: ");
                                cellValue = Console.ReadLine().ToUpper();
                            }
                            worksheet.Cells[cellName].Value = cellValue;
                            cellCounter++;
                            package.Save();
                        }
                        // Tell the user where the file was saved
                        Console.WriteLine($"File saved at {Path.GetFullPath(fileName)}");


                    }
                    else if (extensionSplit[1] != "txt" || extensionSplit[1] != "xlsx" && allowedExtensions.Contains(extensionSplit[1]) || allowedExtensions.Contains(extensionSplit[2]))
                    {
                        Console.WriteLine($"\n{userWriteFileName} Unable To Write/Insert Data..!\n\nOnly Text Files are able to Write/Insert the data.");
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("Operation cancelled...!\n\nOnly .text & .xlsx extension Files are able to Write/Insert the data.");
                        Environment.Exit(0);
                    }
                }
                else if (fileFoundStatus2 != true)
                {
                    Console.Write($"\n\nUnable to Write the {userWriteFileName} file. \n\nChoose another File to Write or Enter exit:");
                    goto userFilesWriteInputChecker;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
