using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookReader.Models;

namespace BookReader.Data
{
    public class BookReaderContext : DbContext
    {
        public BookReaderContext (DbContextOptions<BookReaderContext> options)
            : base(options)
        {
        }

        public DbSet<BookReader.Models.Customer> Customer { get; set; }

        public DbSet<BookReader.Models.Adres> Adres { get; set; }
    }
}
