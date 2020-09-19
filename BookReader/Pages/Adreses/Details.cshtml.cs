using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookReader.Data;
using BookReader.Models;

namespace BookReader.Pages.Adreses
{
    public class DetailsModel : PageModel
    {
        private readonly BookReader.Data.BookReaderContext _context;

        public DetailsModel(BookReader.Data.BookReaderContext context)
        {
            _context = context;
        }

        public Adres Adres { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Adres = await _context.Adres
                .Include(a => a.Customer).FirstOrDefaultAsync(m => m.ID == id);

            if (Adres == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
