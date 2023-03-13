using System.Diagnostics;

namespace FileOperationsAssignment
{
    public class UploadFileClass
    {
        public static async Task UploadFile(string FileSourcePath, string DestinationFilePath, long FileSize)
        {
            await Task.Run(() =>
                {
                    try
                    {
                        var sw = new Stopwatch();
                        sw.Start();
                        using (FileStream sourceFileStream = File.OpenRead(FileSourcePath))
                        {
                            string fileDestinationFullPath = DestinationFilePath + "\\" + Path.GetFileName(FileSourcePath);
                            using (FileStream desatinationFileStream = new FileStream(fileDestinationFullPath, FileMode.OpenOrCreate))
                            {
                                byte[] sourceFileBuffer = new byte[1024];
                                int bytesRead = 0;
                                long totalFileBytesRead = 0;

                                while ((bytesRead = sourceFileStream.Read(sourceFileBuffer, 0, sourceFileBuffer.Length)) > 0)
                                {
                                    totalFileBytesRead += bytesRead;

                                    int percentage = (int)((double)totalFileBytesRead / FileSize * 100);
                                    Console.Write("\r{0}% [", percentage);

                                    int totalProgressedFileData = (int)Math.Floor((double)percentage / 2);

                                    for (int i = 0; i < totalProgressedFileData; i++)
                                    {
                                        Console.Write("=");
                                    }

                                    for (int i = totalProgressedFileData; i < 50; i++)
                                    {
                                        Console.Write(" ");
                                    }
                                    Console.Write("]");
                                    if (totalFileBytesRead == FileSize)
                                    {
                                        Console.WriteLine("\nFile upload complete.");
                                        Console.WriteLine($"Elapsed Time: {sw.ElapsedMilliseconds} ms");
                                    }
                                }
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                });
        }
    }
}
