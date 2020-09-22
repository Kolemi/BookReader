using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookReader.Data;
using BookReader.Models;

namespace BookReader.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly BookReader.Data.BookReaderContext _context;

        public IndexModel(BookReader.Data.BookReaderContext context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get;set; }

        public async Task OnGetAsync()
        {
            Customer = await _context.Customers.ToListAsync();
        }
    }
}
