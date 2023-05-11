using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProductManagmentCRUD.Models
{
    public class Product
    {
    
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please enter validate price")]
        public decimal Price { get; set; }
        public int IsInStock { get; set; }

        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}