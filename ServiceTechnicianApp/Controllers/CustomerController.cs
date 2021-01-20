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
        public ActionResult Details(int id)
        {
            var service = CreateCustomerService();
            var model = service.GetCustomerById(id);
            return View(model);
        }
        //GET: Details by Active Service Contract
        public ActionResult DetailsByServiceContract()
        {
            var service = CreateCustomerService();
            var model = service.GetCustomersByContract();
            return View(model);
        }
        //GET: Edit
        public ActionResult Edit(int id)
        {
            var service = CreateCustomerService();
            var details = service.GetCustomerById(id);
            var model = new CustomerEdit
            {
                CustomerId = details.CustomerId,
                CompanyName = details.CompanyName,
                City = details.City,
                State = details.State,
                Address = details.Address,
                ServiceContract = details.ServiceContract,
                MachineId = details.MachineId
            };
            return View(model);
        }
        //POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CustomerEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if(model.CustomerId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateCustomerService();

            if (service.EditCustomer(model))
            {
                return RedirectToAction("index");
            }
            ModelState.AddModelError("", "An error has occured, the customer information could not be updated.");
            return View(model);
        }
        //GET: Delete
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateCustomerService();
            var model = service.GetCustomerById(id);
            return View(model);
        }
        //POST: Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCustomer(int id)
        {
            var service = CreateCustomerService();
            service.DeleteCustomer(id);
            return RedirectToAction("Index");
        }
    }
}