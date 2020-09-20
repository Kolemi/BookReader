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

        public DbSet<BookReader.Models.Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
        }
    }
}
