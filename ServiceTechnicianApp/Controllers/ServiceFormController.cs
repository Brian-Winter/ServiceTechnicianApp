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
        //GET: EDIT
        //POST: EDIT
        //GET: DELETE
        //POST: DELETE
    }
}