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

namespace BookReader.Pages.OrdersItems
{
    public class EditModel : PageModel
    {
        private readonly BookReader.Data.BookReaderContext _context;

        public EditModel(BookReader.Data.BookReaderContext context)
        {
            _context = context;
        }

        [BindProperty]
        public OrderItem OrderItem { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OrderItem = await _context.OrderItems
                .Include(o => o.Book)
                .Include(o => o.Order).FirstOrDefaultAsync(m => m.OrderItemID == id);

            if (OrderItem == null)
            {
                return NotFound();
            }
           ViewData["BookID"] = new SelectList(_context.Books, "BookID", "BookID");
           ViewData["OrderID"] = new SelectList(_context.Orders, "OrderID", "OrderID");
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

            _context.Attach(OrderItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderItemExists(OrderItem.OrderItemID))
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

        private bool OrderItemExists(int id)
        {
            return _context.OrderItems.Any(e => e.OrderItemID == id);
        }
    }
}
