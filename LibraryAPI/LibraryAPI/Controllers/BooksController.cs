using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using LibraryAPI.Helpers;
using LibraryAPI.Mapping;
using LibraryAPI.Models;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        //private readonly IDynamoDBContext _dynamoDBContext;
        private readonly IAmazonDynamoDB _dynamoDb;
        private readonly string _tableName = "book-table";
        private readonly IBookService _bookService;

        //private readonly IConfiguration _configuration;
        //private readonly IAmazonDynamoDB _dynamoDB;

        public BooksController(IAmazonDynamoDB amazonDynamoDB, IBookService bookService)
        {
            _dynamoDb = amazonDynamoDB; 
            _bookService = bookService;
        }

        [HttpGet("book")]
        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            var scanRequest = new ScanRequest
            {
                TableName = _tableName
            };
            var response = await _dynamoDb.ScanAsync(scanRequest);
            return response.Items.Select(x =>
            {
                var json = Document.FromAttributeMap(x).ToJson();
                return JsonSerializer.Deserialize<Book>(json);
            })!;
        }

        [HttpPost("book-table")]
        public async Task<IActionResult> Create([FromBody] Book request)
        {
            var book = request.ToBook();

            await _bookService.CreateAsync(book);

            await MessageHelper.SendMessage(book);

            return Ok();
        }
            // POST api/<BooksController>
            [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
