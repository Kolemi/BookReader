using BookReader.Data;
using BookReader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Services
{
    public class OrderItemService
    {
        private BookReaderContext context;
        public OrderItemService(BookReaderContext bookReaderContext)
        {
            context = bookReaderContext;
        }

        public IEnumerable<OrderItem> GetOrderItems => context.OrderItems;
    }
}
