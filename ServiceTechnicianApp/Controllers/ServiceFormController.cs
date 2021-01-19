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
        [Authorize]
        private ServiceFormService CreateFormService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ServiceFormService(userId);
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
            var service = CreateFormService();
            if (service.CreateServiceForm(model))
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Form could not be completed.");
            return View(model);

        }
        //GET: DETAILS
        public ActionResult Details(int id)
        {
            var service = CreateFormService();
            var model = service.GetFormById(id);
            return View(model);
        }
        //GET: EDIT
        public ActionResult Edit(int id)
        {
            var service = CreateFormService();
            var detail = service.GetFormById(id);
            var model = new ServiceFormEdit
            {
                FormId = detail.FormId,
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
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "An error has occured.");
            return View(model);
        }
        //GET: DELETE
        public ActionResult Delete(int id)
        {
            var service = CreateFormService();
            var model = service.DeleteServiceForm(id);
            return View(model);
        }
        //POST: DELETE
    }
}