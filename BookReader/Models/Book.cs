using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookReader.Models
{
    public class Book
    {
        public int BookID { get; set; }

        [Display(Name = "Tytuł")]
        public string Title { get; set; }

        [Display(Name = "Opis")]
        public string Description { get; set; }

        [Display(Name = "Autor")]
        public string Author { get; set; }

        [Display(Name = "Cena książki")]
        [Column(TypeName = "decimal(18, 2)")]
        public Decimal Price { get; set; }

        [Display(Name = "Data zakupu")]
        [DataType(DataType.Date)]

        public DateTime ReleaseDate { get; set; }
        public int CategoryID { get; set; }

        [Display(Name = "Kategoria")]
        public Category Category { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }

        public static implicit operator Book(List<Book> v)
        {
            throw new NotImplementedException();
        }
    }
}
