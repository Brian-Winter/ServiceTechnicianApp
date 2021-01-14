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
        //POST: CREATE
        //GET: DETAILS
        //GET: EDIT
        //POST: EDIT
        //GET: DELETE
        //POST: DELETE
    }
}