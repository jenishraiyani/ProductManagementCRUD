using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProductManagmentCRUD.Models
{
    public class CustomerAddresss
    {
        [Key]
        [ForeignKey("Customer")]
        public int CustomerAddressId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public virtual Customer Customer { get; set; }
    }
}