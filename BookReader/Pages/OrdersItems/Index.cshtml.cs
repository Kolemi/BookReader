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
    public class IndexModel : PageModel
    {
        private readonly BookReader.Data.BookReaderContext _context;

        public IndexModel(BookReader.Data.BookReaderContext context)
        {
            _context = context;
        }

        public IList<OrderItem> OrderItem { get;set; }

        public async Task OnGetAsync()
        {
            OrderItem = await _context.OrderItems
                .Include(o => o.Book)
                .Include(o => o.Order).ToListAsync();
        }
    }
}
