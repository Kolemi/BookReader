using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookReader.Data;
using BookReader.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookReader.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly BookReader.Data.BookReaderContext _context;

        public IndexModel(BookReader.Data.BookReaderContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList CategoryID { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Categories { get; set; }

        public async Task OnGetAsync()
        {
            var books = from b in _context.Books
                         select b;
            if (!string.IsNullOrEmpty(SearchString))
            {
                books = books.Where(s => s.Title.Contains(SearchString));
            }

            Book = await books.ToListAsync();
        }
    }
}
