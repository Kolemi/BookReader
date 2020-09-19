using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookReader.Data;
using BookReader.Models;

namespace BookReader.Pages.Adreses
{
    public class EditModel : PageModel
    {
        private readonly BookReader.Data.BookReaderContext _context;

        public EditModel(BookReader.Data.BookReaderContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["ID"] = new SelectList(_context.Customer, "ID", "ID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Adres).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdresExists(Adres.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AdresExists(int id)
        {
            return _context.Adres.Any(e => e.ID == id);
        }
    }
}
