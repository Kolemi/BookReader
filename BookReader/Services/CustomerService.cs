using BookReader.Data;
using BookReader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Services
{
    public class CustomerService
    {
        private BookReaderContext context;
        public CustomerService(BookReaderContext bookReaderContext)
        {
            context = bookReaderContext;
        }

        public IEnumerable<Customer> GetCustomers() => context.Customers;
    }
}
