using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookReader.Data;
using BookReader.Models;

namespace BookReader.Pages.Adreses
{
    public class CreateModel : PageModel
    {
        private readonly BookReader.Data.BookReaderContext _context;

        public CreateModel(BookReader.Data.BookReaderContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ID"] = new SelectList(_context.Customer, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Adres Adres { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Adres.Add(Adres);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
