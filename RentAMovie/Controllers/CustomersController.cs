using RentAMovie.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentAMovie.Controllers
{
    public class CustomersController : Controller
    {
        private DBEntity context;

        public CustomersController()
        {
            this.context = new DBEntity();
        }

        protected override void Dispose(bool disposing)
        {
            this.context.Dispose();
        }

        // GET: Customer
        public ViewResult Index()
        {
            var customers = this.context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        //[Route("customers/details/{id}:range(1,3)")]
        public ActionResult Details(int id)
        {
            var customer = this.context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
    }
}