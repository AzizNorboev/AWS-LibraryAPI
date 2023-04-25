using LibraryAPI.Mapping;
using LibraryAPI.Models;
using LibraryAPI.Repositories;
using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<bool> CreateAsync(Book book)
        {
            var bookDto = book.ToBookDto();
            return await _bookRepository.CreateAsync(bookDto);
        }
    }
}
