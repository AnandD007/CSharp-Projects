using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace FileOperationsAssignment
{
    public class FilesUploader
    {
        public string? FileSourceLocation;
        // public string Destination = @"E:\\Tester\\";
        public string? DestinationFileFullPath;
        public string? SourceFileName;
        public DirectoryInfo? SourceFileDirectoryPath;
        public DirectoryInfo? ReadFilePath;
        public string FileDestinationDirectory = @"E:\\Tester\\";
        public string? SourceFileFullPath;
        public int UploadFileCount = 0;
        public string? UserFileCountString;
        public string? DestinationFileName;
        public List<string> ChoosenFiles = new List<string>();
        public void MultipleFilesUploader()
        {
            try
            {
                Regex onlyForNumbers = new Regex(@"[0-9]$");
                // Writing Content in new file
                Console.Write("\n\nEnter the Files Choosing Directory Location:");
                FileSourceLocation = Console.ReadLine();
                while (FileSourceLocation.Length == 0)
                {
                    Console.Write("\n\nField Should Not Be Null...!\n\nEnter Writing File Location:");
                    FileSourceLocation = Console.ReadLine();
                }
                FileSourceLocation = @"" + FileSourceLocation;
                SourceFileDirectoryPath = new DirectoryInfo(FileSourceLocation);
                if (SourceFileDirectoryPath == null || !(SourceFileDirectoryPath.Exists))
                {
                    throw new DirectoryNotFoundException();
                }
                else
                {
                    Console.WriteLine("\nFiles those present in your choosen directory:\n\n");
                    // Display the file names

                    foreach (FileInfo fileName in SourceFileDirectoryPath.GetFiles())
                    {
                        Console.WriteLine("{0}", fileName.Name.ToLower());
                    }
                    Console.Write("\n\nEnter How many files Do You want to upload:");
                    UserFileCountString = Console.ReadLine();
                    while (UserFileCountString == null || UserFileCountString.Length == 0 || !(onlyForNumbers.IsMatch(UserFileCountString)))
                    {
                        Console.Write("\n\nInvalid Input Entered....!\nEnter How many files Do You want to upload:");
                        UserFileCountString = Console.ReadLine();
                    }
                    while (Convert.ToInt16(onlyForNumbers.IsMatch(UserFileCountString)) <= 0)
                    {

                        if (Convert.ToInt16(onlyForNumbers.IsMatch(UserFileCountString)) <= 0)
                        {
                            if (UploadFileCount == 0)
                            {
                                Console.WriteLine("\n\nUploading files count number should be above 0.");
                                Environment.Exit(0);
                            }
                        }
                        else
                        {
                            Console.Write("\n\nInvalid Input Entered....!\nEnter How many files Do You want to upload:");
                            UserFileCountString = Console.ReadLine();
                        }
                    }
                    UploadFileCount = Convert.ToInt16(UserFileCountString);
                }
                for (int i = 0; i < UploadFileCount; i++)
                {
                    Console.Write("\n\nEnter Choosing File Name:");
                    SourceFileName = Console.ReadLine().ToLower();
                    while (SourceFileName.Length == 0)
                    {
                        Console.Write("\n\nField Should Not Be Null...!\n\nEnter the Correct File Name from above File List:");
                        SourceFileName = Console.ReadLine().ToLower();
                    }
                    SourceFileFullPath = FileSourceLocation + "\\" + SourceFileName;
                    if (File.Exists(SourceFileFullPath))
                    {
                        ChoosenFiles.Add(SourceFileFullPath);
                    }
                    else
                    {
                        while (!File.Exists(SourceFileFullPath))
                        {
                            Console.Write("\n\nInvaild File Name Choosen...!\n\nEnter the Correct File Name from above File List:");
                            SourceFileName = Console.ReadLine().ToLower();
                        }

                    }
                }
                DirectoryInfo ReadFilePath = new DirectoryInfo(FileDestinationDirectory);
                if (ReadFilePath == null || !(ReadFilePath.Exists))
                {
                    throw new DirectoryNotFoundException();
                }
                else
                {
                    foreach (string fileName in ChoosenFiles)
                    {
                        DestinationFileFullPath = FileDestinationDirectory + fileName;
                        if (File.Exists(DestinationFileFullPath))
                        {
                            throw new FileFoundException();
                        }

                    }
                    var sw = new Stopwatch();
                    sw.Start();
                    Console.WriteLine("Starting Upload...\n");
                    try
                    {
                        IEnumerable<Task> tasks = ChoosenFiles.Select(currentFile => UploadMultipleFiles.UploadMultipleFile(currentFile));
                        Task.WhenAll(tasks).Wait();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    Console.WriteLine("\nAll Uploads Complete.");
                    Console.WriteLine($"Elapsed Time: {sw.ElapsedMilliseconds} ms");
                }
            }
            catch (FileNotFoundException e2)
            {
                Console.WriteLine(e2.Message);
            }
            catch (DirectoryNotFoundException e3)
            {
                Console.WriteLine(e3.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("\n\nThank You For Using Our Service\n\n");
            }
        }
    }
}
