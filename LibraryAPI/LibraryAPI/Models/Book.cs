using System.Text.Json.Serialization;

namespace LibraryAPI.Models
{
    public class Book
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }


    }
}
