using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductManagmentCRUD.Models
{
    public class Category
    {

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public int IsActive { get; set; }

        public ICollection<Product> Products { get; set; }


    }
}