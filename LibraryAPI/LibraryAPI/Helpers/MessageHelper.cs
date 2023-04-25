using Amazon.SQS;
using Amazon.SQS.Model;
using LibraryAPI.Models;
using System.Text.Json;

namespace LibraryAPI.Helpers
{
    public static class MessageHelper
    {

        public static async Task<bool> SendMessage(Book book)
        {
            var sqsClient = new AmazonSQSClient();
            var queueUrlResponse = await sqsClient.GetQueueUrlAsync("book-changes");

            var sendMessageRequest = new SendMessageRequest
            {
                QueueUrl = queueUrlResponse.QueueUrl,
                MessageBody = JsonSerializer.Serialize(book),
                MessageAttributes = new Dictionary<string, MessageAttributeValue>
                {
                    {
                        "MessageType", new MessageAttributeValue
                        {
                             DataType = "String",
                             StringValue = nameof(Book)
                        }
                    }
                },

            };

            var response = await sqsClient.SendMessageAsync(sendMessageRequest);
            return true;
        }
    }
}
