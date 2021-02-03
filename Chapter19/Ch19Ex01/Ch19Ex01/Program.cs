using System;
using System.IO;
using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace Ch19Ex01
{
    class Program
    {
        static void Main(string[] args)
        {
            try 
            {
                string connectionString = Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING");
                BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
                BlobContainerClient containerClient = blobServiceClient.CreateBlobContainer("carddeck");
                containerClient.SetAccessPolicy(PublicAccessType.Blob);

                int numberOfCards = 0;
                DirectoryInfo dir = new DirectoryInfo(@"Cards");
                foreach (FileInfo f in dir.GetFiles("*.*"))
                {
                    BlobClient blob = containerClient.GetBlobClient(f.Name);
                    using (var fileStream = System.IO.File.OpenRead(@"Cards\" + f.Name))
                    {
                        blob.Upload(fileStream);
                        Console.WriteLine($"Uploading: '{f.Name}' which " +
                         $"is {fileStream.Length} bytes.");
                    }
                    numberOfCards++;
                }
                Console.WriteLine($"Uploaded {numberOfCards.ToString()} cards.");
                Console.WriteLine();

                numberOfCards = 0;
                foreach (BlobItem item in containerClient.GetBlobs())
                {
                    Console.WriteLine($"Card image url '{containerClient.Uri}/{item.Name}' with length " +
                         $"of {item.Properties.ContentLength}");
                    numberOfCards++;
                }
                Console.WriteLine($"Listed {numberOfCards.ToString()} cards.");

                Console.WriteLine("If you want to delete the container and its contents enter: " + 
                                   "'Yes' and the Enter key");
                var delete = Console.ReadLine();
                if (delete == "Yes")
                {
                    containerClient.Delete();
                    Console.WriteLine("Container deleted.");
                }
                Console.WriteLine("All done, press the Enter key to exit.");
                Console.ReadLine();
            }
            catch (RequestFailedException rfe) 
            {
                Console.WriteLine($"RequestFailedException: {rfe.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }
    }
}
