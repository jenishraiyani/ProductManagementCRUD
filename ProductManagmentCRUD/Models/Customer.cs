using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductManagmentCRUD.Models
{
    public class Customer
    {
       
        public int CustomerId { get; set; }
        public string UserName { get; set; }

        [StringLength(20, ErrorMessage = "Your First Name can contain only 20 characters")]
        public string FirstName { get; set; }

        [StringLength(20, ErrorMessage = "Your Last Name can contain only 20 characters")]
        public string LastName { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string MobilePhone { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
        public virtual CustomerAddresss Address { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}