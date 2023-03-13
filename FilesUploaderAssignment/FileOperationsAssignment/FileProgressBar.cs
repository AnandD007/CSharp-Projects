

namespace FileOperationsAssignment
{
    public class FileProgressBar
    {
        public string FileSourcePath;
        public string DestinationFilePath;
        public long FileSize;
        public void FileProgress()
        {
            Console.Write("\n\nEnter the Upload file source path with File Name: ");
            FileSourcePath = Console.ReadLine();

            while (!File.Exists(FileSourcePath))
            {
                Console.Write("\n\nFile not found.\nEnter the Upload file source path with File Name: ");
                FileSourcePath = Console.ReadLine();
            }
            Console.Write("\n\nEnter the Upload file Destination path: ");
            DestinationFilePath = Console.ReadLine();
            while (!Directory.Exists(DestinationFilePath))
            {
                Console.Write("\n\nFile not found.\nEnter the Upload file Destination path: ");
                DestinationFilePath = Console.ReadLine();
            }
            string fileName = Path.GetFileName(FileSourcePath);
            while (File.Exists(DestinationFilePath + "\\" + fileName))
            {
                Console.Write("\n\nFile already exists in destination directory path.\nEnter the Upload file source path with File Name: ");
                FileSourcePath = Console.ReadLine();
            }
            FileInfo fileInfo = new FileInfo(FileSourcePath);
            FileSize = fileInfo.Length;

            Console.WriteLine("\nFile size: {0} bytes.", FileSize);
            Task task = UploadFileClass.UploadFile(FileSourcePath, DestinationFilePath, FileSize);
            Task.WhenAll(task).Wait();
        }
    }
}
