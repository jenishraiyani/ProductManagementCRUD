using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManagmentCRUD.Models
{
    public class OrderDetails
    {
        [Key]
        public int OrderDetailsId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        [ForeignKey("Orders")]
        public int OrderId { get; set; }
        public int Quantity { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please enter validate price")]
        public decimal UnitPrice { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please enter validate price")]
        public decimal Discount { get; set; }
        public virtual Product Product { get; set; }
        public virtual Orders Orders { get; set; }

    }
}