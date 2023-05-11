using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProductManagmentCRUD.Models
{
    public class Orders
    {
        [Key]
        public int OrdersId { get; set; }
        [ForeignKey("Customers")]
        public int CustomerId { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get; set; }
        public virtual Customer Customers { get; set; }
        public virtual ICollection<Product> Products { get; set; }

    }
}