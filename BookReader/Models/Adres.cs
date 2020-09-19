using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Models
{
    public class Adres
    {
        [ForeignKey("Customer")]
        public int AdresID { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public int FlatNumber { get; set; }
        public string ZipCode { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
