using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookApi.Models;

namespace BookApi.Services
{
    public class BookRepository : IBookRepository
    {
        private BookDbContext _bookDbContext;

        public BookRepository(BookDbContext bookDbContext)
        {
            _bookDbContext = bookDbContext;
        }

        public bool BookExists(int bookId)
        {
            return _bookDbContext.Book.Any(b => b.Id == bookId);
        }

        public bool BookExists(string isbn)
        {
            return _bookDbContext.Book.Any(b => b.Isbn == isbn);
        }

        public Book GetBook(int bookId)
        {
            return _bookDbContext.Book.Where(b => b.Id == bookId).FirstOrDefault();

        }

        public Book GetBook(string isbn)
        {
            return _bookDbContext.Book.Where(b => b.Isbn == isbn).FirstOrDefault();
        }

        public ICollection<Book> GetBooks()
        {
            return _bookDbContext.Book.OrderBy(b => b.Title).ToList();
        }

        public bool isDuplicateISBN(int bookId, string isbn)
        {
            var book = _bookDbContext.Book.Where(b => b.Isbn.Trim().ToUpper() == isbn.Trim().ToUpper()
                                                && b.Id != bookId).FirstOrDefault();

            return book == null ? false : true;
        }
    }
}
