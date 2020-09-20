using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Models
{
    public enum Status
    {
        IN_CART,
        PAID
    }
    public class Order
    {
        public int OrderID { get; set; }
        [DataType(DataType.Date)]
        public DateTime? OrderDate { get; set; }
        public Status Status { get; set; }
        public string ShipName { get; set; }
        public string ShipCountry { get; set; }
        public string ShipCity { get; set; }
        public string ShipZipCode { get; set; }
        public string ShipAddress { get; set; }
    }
}
