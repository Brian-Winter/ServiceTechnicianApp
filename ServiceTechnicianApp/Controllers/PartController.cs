using Service.Model.MachinePartModels;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServiceTechnicianApp.Controllers
{
    public class PartController : Controller
    {
        private PartService CreatePartService()
        {
            var service = new PartService();
            return service;
        }
        // GET: All Parts
        public ActionResult Index()
        {
             var service = CreatePartService();
            // var model = new MachinePartListAll[0];
            var model = service.GetPartsList();
            return View(model);
        }
        //GET: Create
        public ActionResult Create()
        {
            return View();
        }
       // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MachinePartCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var service = CreatePartService();
            if (service.CreatePart(model))
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
        //GET: Single Part Details
        public ActionResult Details(int id)
        {
            var service = CreatePartService();
            var model = service.GetMachinePartById(id);
            return View(model);
        }
        //GET: EDIT

        //POST: EDIT
    }
}