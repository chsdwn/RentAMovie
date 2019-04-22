using RentAMovie.Models;
using RentAMovie.ViewModels;
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

        public ActionResult Edit(int id)
        {
            var customer = this.context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = this.context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }

        public ActionResult New()
        {
            var membershipTypes = this.context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer.Id == 0)
                this.context.Customers.Add(customer);
            else
            {
                var customerInDB = this.context.Customers.Single(c => c.Id == customer.Id);
                //TryUpdateModel(customerInDB); This may cause security holes.
                //Mapper.Map(customer, customerInDb) Same goes here.
                customerInDB.Name = customer.Name;
                customerInDB.BirthDate = customer.BirthDate;
                customerInDB.MembershipTypeId = customer.MembershipTypeId;
                customerInDB.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }

            this.context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }
    }
}