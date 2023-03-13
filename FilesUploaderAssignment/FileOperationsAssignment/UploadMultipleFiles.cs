namespace FileOperationsAssignment
{
    public class UploadMultipleFiles
    {
        public static async Task UploadMultipleFile(string path)
        {
            FilesUploader uploader = new FilesUploader();
            FileInfo fileInfo = new(path);
            await Task.Run(() => File.Copy(path, Path.Combine(uploader.FileDestinationDirectory, fileInfo.Name)));
            Console.WriteLine($"{fileInfo.Name} Uploaded");
        }
    }
}
