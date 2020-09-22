using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookReader.Data;
using BookReader.Models;

namespace BookReader.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly BookReader.Data.BookReaderContext _context;

        public DetailsModel(BookReader.Data.BookReaderContext context)
        {
            _context = context;
        }

        public Book Book { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = await _context.Books
                .Include(b => b.Category).FirstOrDefaultAsync(m => m.BookID == id);

            if (Book == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
