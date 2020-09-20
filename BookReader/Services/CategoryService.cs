using BookReader.Data;
using BookReader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Services
{
    public class CategoryService
    {
        private BookReaderContext context;
        public CategoryService(BookReaderContext bookReaderContext)
        {
            context = bookReaderContext;
        }

        public IEnumerable<Category> GetCategories() => context.Categories;
    }
}
