using Amazon.S3;
using Amazon.S3.Transfer;
using LibraryAPI.Models;
using Newtonsoft.Json;
using System.Text;

namespace LibraryAPI.Helpers
{
    public static class BucketHelper
    {
        public static async Task UploadJson(Book book)
        {
            string json = JsonConvert.SerializeObject(book);

            var s3Client = new AmazonS3Client();
            var transferUtility = new TransferUtility(s3Client);

            string bucketName = "lambda-code-bucket-new";
            string keyName = $"Books/{book.ISBN}.json";

            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                await transferUtility.UploadAsync(stream, bucketName, keyName);
            }
        }
    }
}
