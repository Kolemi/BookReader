using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookReader.Data;
using BookReader.Models;

namespace BookReader.Pages.OrdersItems
{
    public class DeleteModel : PageModel
    {
        private readonly BookReader.Data.BookReaderContext _context;

        public DeleteModel(BookReader.Data.BookReaderContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OrderItem = await _context.OrderItems.FindAsync(id);

            if (OrderItem != null)
            {
                _context.OrderItems.Remove(OrderItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
