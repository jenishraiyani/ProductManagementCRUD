using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductManagmentCRUD.Models
{
    public class ProductViewModel
    {
        public Customer Customers { get; set; }
        public Orders Orders { get; set;}

        public OrderDetails OrderDetails { get; set;}
    }
}