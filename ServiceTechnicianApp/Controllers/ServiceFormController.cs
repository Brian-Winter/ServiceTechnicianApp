using Microsoft.AspNet.Identity;
using Service.Model.ServiceFormModels;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServiceTechnicianApp.Controllers
{
    public class ServiceFormController : Controller
    {
        
        private ServiceFormService CreateFormServiceForUser()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ServiceFormService(userId);
            return service;
        }
        private ServiceFormService CreateFormService()
        {
            
            var service = new ServiceFormService();
            return service;
        }

        // GET: ServiceForm
        public ActionResult Index()
        {
            
            var service = CreateFormService();
           
            var model = service.ViewAllForms();
            return View(model);
        }
        //GET: CREATE
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }
        //POST: CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ServiceFormCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var service = CreateFormServiceForUser();
            if (service.CreateServiceForm(model))
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Form could not be completed.");
            return View(model);

        }
        //GET: DETAILS
        [Authorize]
        public ActionResult Details(int id)
        {
            var service = CreateFormService();
            var model = service.GetFormForDetails(id);
            return View(model);
        }
        //GET: CUSTOMER SPECIFIC DETAILS
        public ActionResult CustomerDetails(int id)
        {
            var service = CreateFormService();
            var model = service.ViewAllCustomerForms(id);
            return View(model);
        }
        //GET: EDIT
        public ActionResult Edit(int id)
        {
            var service = CreateFormService();
            var detail = service.GetFormById(id);
            var model = new ServiceFormEdit
            {
                FormId = id,
                Completed = detail.Completed,
                StartTime = detail.StartTime,
                FinishTime = detail.FinishTime,
                MeterReadOne = detail.MeterReadOne,
                MeterReadTwo = detail.MeterReadTwo,
                CostDue = detail.CostDue,
                MachineId = detail.MachineId,
                MachinePartId = detail.MachinePartId,
                CustomerId = detail.CustomerId

            };
            return View(model);
        }
        //POST: EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ServiceFormEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if(model.FormId != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
            }
            var service = CreateFormService();

            if (service.EditServiceForm(model))
            {
                return RedirectToAction("Details");
            }
            ModelState.AddModelError("", "An error has occured.");
            return View(model);
        }
        //GET: DELETE
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateFormService();
            var model = service.GetFormById(id);
            return View(model);
        }
       // POST: DELETE
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteServiceForm(int id)
        {
            var service = CreateFormService();

            service.DeleteServiceForm(id);
            return RedirectToAction("Index", "Home", "Index");
        }
    }
}