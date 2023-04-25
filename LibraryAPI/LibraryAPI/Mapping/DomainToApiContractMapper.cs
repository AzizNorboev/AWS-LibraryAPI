using LibraryAPI.Models;

namespace LibraryAPI.Mapping
{
    public static class DomainToApiContractMapper
    {
        public static Book ToBookResponse(this Book customer)
        {
            return new Book
            {
                ISBN = customer.ISBN,
                Title = customer.Title,
                Description = customer.Description,
            };
        }
    }
}
