using System;
using System.Text;
using System.IO;
using System.IO.Compression;
using static System.Console;

namespace Compressor
{
    class Program
    {
        static void SaveCompressedFile(string filename, string data)
        {
            using (FileStream fileStream =
               new FileStream(filename, FileMode.Create, FileAccess.Write))
            {
                using (GZipStream compressionStream = new GZipStream(fileStream, CompressionMode.Compress))
                {
                    using (StreamWriter writer = new StreamWriter(compressionStream))
                    {
                        writer.Write(data);
                    }
                }
            }
        }
        static string LoadCompressedFile(string filename)
        {
            using (FileStream fileStream =
               new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                using (GZipStream compressionStream =
                   new GZipStream(fileStream, CompressionMode.Decompress))
                {
                    using (StreamReader reader = new StreamReader(compressionStream))
                    {
                        string data = reader.ReadToEnd();
                        return data;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            try
            {
                string filename = "compressedFile.gz";
                WriteLine(
                   "Enter a string to compress (will be repeated 100 times):");
                string sourceString = ReadLine();
                StringBuilder sourceStringMultiplier =
                   new StringBuilder(sourceString.Length * 100);
                for (int i = 0; i < 100; i++)
                {
                    sourceStringMultiplier.Append(sourceString);
                }
                sourceString = sourceStringMultiplier.ToString();
                WriteLine($"Source data is {sourceString.Length} bytes long.");
                SaveCompressedFile(filename, sourceString);
                WriteLine($"\nData saved to {filename}.");
                FileInfo compressedFileData = new FileInfo(filename);
                Write($"Compressed file is {compressedFileData.Length}");
                WriteLine(" bytes long.");
                string recoveredString = LoadCompressedFile(filename);
                recoveredString = recoveredString.Substring(
                   0, recoveredString.Length / 100);
                WriteLine($"\nRecovered data: {recoveredString}", recoveredString);
            }
            catch (IOException ex)
            {
                WriteLine("An IO exception has been thrown!");
                WriteLine(ex.ToString());
                ReadKey();
            }

        }
    }
}
