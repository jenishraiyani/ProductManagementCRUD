using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProductManagmentCRUD.Models;

namespace ProductManagmentCRUD.Controllers
{
    public class CustomerAddresssesController : Controller
    {
        private ProductContext db = new ProductContext();

        // GET: CustomerAddressses
        public ActionResult Index()
        {
            var customerAddresses = db.CustomerAddresses.Include(c => c.Customer);
            return View(customerAddresses.ToList());
        }

        // GET: CustomerAddressses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerAddresss customerAddresss = db.CustomerAddresses.Find(id);
            if (customerAddresss == null)
            {
                return HttpNotFound();
            }
            return View(customerAddresss);
        }

        // GET: CustomerAddressses/Create
        public ActionResult Create()
        {
            ViewBag.CustomerAddressId = new SelectList(db.Customers, "CustomerId", "UserName");
            return View();
        }

        // POST: CustomerAddressses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerAddressId,Address,City,PostalCode,State,Country")] CustomerAddresss customerAddresss)
        {
            if (ModelState.IsValid)
            {
                db.CustomerAddresses.Add(customerAddresss);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerAddressId = new SelectList(db.Customers, "CustomerId", "UserName", customerAddresss.CustomerAddressId);
            return View(customerAddresss);
        }

        // GET: CustomerAddressses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerAddresss customerAddresss = db.CustomerAddresses.Find(id);
            if (customerAddresss == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerAddressId = new SelectList(db.Customers, "CustomerId", "UserName", customerAddresss.CustomerAddressId);
            return View(customerAddresss);
        }

        // POST: CustomerAddressses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerAddressId,Address,City,PostalCode,State,Country")] CustomerAddresss customerAddresss)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerAddresss).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerAddressId = new SelectList(db.Customers, "CustomerId", "UserName", customerAddresss.CustomerAddressId);
            return View(customerAddresss);
        }

        // GET: CustomerAddressses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerAddresss customerAddresss = db.CustomerAddresses.Find(id);
            if (customerAddresss == null)
            {
                return HttpNotFound();
            }
            return View(customerAddresss);
        }

        // POST: CustomerAddressses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerAddresss customerAddresss = db.CustomerAddresses.Find(id);
            db.CustomerAddresses.Remove(customerAddresss);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
