using BookApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Services
{
    public interface IBookRepository
    {
        ICollection<Book> GetBooks();
        Book GetBook(int bookId);
        Book GetBook(string isbn);
        bool BookExists(int bookId);
        bool BookExists(string isbn);
        bool isDuplicateISBN(int id, string isbn);

    }
}
