using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Models
{
    public class Category
    {
        public int CategoryID { get; set; }

        [Display(Name = "Kategoria")]
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
