using LibraryAPI.Models;

namespace LibraryAPI.Mapping
{
    public static class DomainToDtoMapper
    {
        public static Book ToBookDto(this Book book)
        {
            return new Book
            {
                ISBN = book.ISBN,
                Title = book.Title,
                Description = book.Description
            };
        }
    }
}
