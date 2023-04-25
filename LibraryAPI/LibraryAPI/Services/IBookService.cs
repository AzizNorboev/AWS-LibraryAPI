using LibraryAPI.Models;

namespace LibraryAPI.Services
{
    public interface IBookService
    {
        Task<bool> CreateAsync(Book book);
    }
}
