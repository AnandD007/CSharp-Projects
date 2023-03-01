﻿namespace FileOperationsAssignment
{
    internal class DisplayLastLine
    {
        internal void DisplayLastNameFunction()
        {
            try
            { 
            string textRead;
            string userReadFileName = "";
            string userFullFileName;
            string fileLastLine;
            bool fileFoundStatus = false;
            string[] splitter = new String[5];
            string fileReadLocation;
            string fullWriteFileName;

            Console.Write("\n\nEnter Reading File Location:");
            fileReadLocation = Console.ReadLine();
            while (fileReadLocation.Length == 0)
            {
                Console.Write("\n\nField Should Not Be Null...!\nEnter Reading File Location:");
                fileReadLocation = Console.ReadLine();
            }

            DirectoryInfo readFilePath = new DirectoryInfo(@"" + fileReadLocation);
            if (readFilePath == null || !(readFilePath.Exists))
            {
                throw new DirectoryNotFoundException();
            }

            FileInfo[] Files = readFilePath.GetFiles();
            Console.WriteLine("Files those Presents in your current directory:\n\n");

            int j = 1;
            foreach (FileInfo i in Files)
            {
                Console.Write("{0}. {1}\n", j++, i.Name.ToLower());
            }
            Console.WriteLine("Enter the file Name to read from the above list:");
            userReadFileName = Console.ReadLine().ToLower();
            while (userReadFileName.Length == 0)
            {
                Console.Write("\n\nInvalid User Input...!\n\nEnter the file Name to read from the above list:");
                userReadFileName = Console.ReadLine().ToLower().ToLower();
                string userReadFileExtension = Path.GetExtension(userReadFileName);
            }
            while (Path.GetExtension(userReadFileName) != ".txt")
            {
                Console.Write("\n\nInvalid File Extension...! File extension should be (.txt)\n\nEnter Reading File Name:");
                userReadFileName = Console.ReadLine().ToLower();
            }
            foreach (FileInfo filer in Files)
            {
                if (userReadFileName == filer.Name.ToLower())
                {
                    fileFoundStatus = true;
                    break;
                }
                else
                {
                    fileFoundStatus = false;
                }
            }
                if (fileFoundStatus == true)
                {
                    userFullFileName = fileReadLocation + "\\" + userReadFileName;
                    string lastLine = File.ReadLines(userFullFileName).Last();
                    Console.WriteLine("Last line of {0}: {1}", Path.GetFileName(userFullFileName), lastLine);
                }
                else if (fileFoundStatus == false)
                {
                    throw new FileNotFoundException();
                }
                else
                {
                    throw new UnauthorizedAccessException();
                }

            }
            catch (UnauthorizedAccessException e1)
            {
                Console.WriteLine(e1.Message);
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
