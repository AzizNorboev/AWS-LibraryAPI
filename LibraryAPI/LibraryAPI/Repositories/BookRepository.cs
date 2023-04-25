using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using LibraryAPI.Models;
using System.Net;
using System.Text.Json;

namespace LibraryAPI.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IAmazonDynamoDB _dynamoDb;
        private readonly string _tableName = "book-table";

        public BookRepository(IAmazonDynamoDB dynamoDb)
        {
            _dynamoDb = dynamoDb;
        }
        public async Task<bool> CreateAsync(Book book)
        {
            var bookAsJson = JsonSerializer.Serialize(book);
            var bookAsAttributes = Document.FromJson(bookAsJson).ToAttributeMap();

            var createItemRequest = new PutItemRequest
            {
                TableName = _tableName,
                Item = bookAsAttributes,
                ConditionExpression = "attribute_not_exists(pk) and attribute_not_exists(sk)"
            };

            var response = await _dynamoDb.PutItemAsync(createItemRequest);
            return response.HttpStatusCode == HttpStatusCode.OK;
        }
    }
}
