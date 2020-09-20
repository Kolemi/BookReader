using BookReader.Data;
using BookReader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Services
{
    public class OrderService
    {
        private BookReaderContext context;
        public OrderService(BookReaderContext bookReaderContext)
        {
            context = bookReaderContext;
        }

        public IEnumerable<Order> GetOrders() => context.Orders;
    }
}
