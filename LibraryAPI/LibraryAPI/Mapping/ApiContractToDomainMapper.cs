using LibraryAPI.Models;

namespace LibraryAPI.Mapping
{
    public static class ApiContractToDomainMapper
    {
        public static Book ToBook(this Book request)
        {
            return new Book
            {
                ISBN = request.ISBN,
                Title = request.Title,
                Description = request.Description,
            };
        }
    }
}
