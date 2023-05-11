using ProductManagmentCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductManagmentCRUD.Controllers
{
    public class HomeController : Controller
    {
        private ProductContext db = new ProductContext();
        public ActionResult Index()
        {

            List<Customer> customers = db.Customers.ToList();
            List<Orders> orders = db.Orders.ToList();
            List<OrderDetails> orderDetails = db.OrderDetails.ToList();
            List<Category> categories = db.Categories.ToList();
            List<Product> products = db.Products.ToList();

            var productRecord = from customer in customers
                                join o in orders on customer.CustomerId equals o.CustomerId into table1
                                from o in table1.ToList()
                                join orderDetail in orderDetails on o.OrdersId equals orderDetail.OrderId
                                into table2
                                from orderDetail in table2.ToList()
                                select new ProductViewModel
                                 {
                                     Customers = customer,
                                     Orders = o,
                                     OrderDetails = orderDetail
                                      
                                 };


            var productzCount = products.GroupBy(p => p.Category.CategoryName).Select(g => new
            {
                Category = g.Key,
                Productcount = g.Count()

            }).OrderBy(x => x.Productcount);
            return View(productRecord);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}