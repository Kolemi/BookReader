using BookReader.Data;
using BookReader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Services
{
    public class BookService
    {
        private BookReaderContext context;
        public BookService(BookReaderContext bookReaderContext)
        {
            context = bookReaderContext;
        }

        public IEnumerable<Book> GetBooks() => context.Books;
    }
}
