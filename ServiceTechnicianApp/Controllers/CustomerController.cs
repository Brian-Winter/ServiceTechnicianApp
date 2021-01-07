using Service.Model.CustomerModels;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServiceTechnicianApp.Controllers
{
    public class CustomerController : Controller
    {
        private CustomerService CreateCustomerService()
        {
            var service = new CustomerService();
            return service;
        }
        // GET: Customer
        public ActionResult Index()
        {
            var service = CreateCustomerService();
            var model = service.ViewAllCustomers();
            return View(model);
        }
        //GET: Create
        public ActionResult Create()
        {
            return View();
        }
        //POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var service = CreateCustomerService();

            if (service.CreateCustomer(model))
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Customer could not be created.");
            return View(model);
        }
       
        //GET: Details
        //GET: Details by Active Service Contract
        //GET: Edit
        //POST: Edit

    }
}