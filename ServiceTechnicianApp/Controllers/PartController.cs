using Service.Contracts;
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
        private readonly IMachinePartService _machinePartService;
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
        public ActionResult Edit(int id)
        {
            var service = CreatePartService();
            var detail = service.GetMachinePartById(id);
            var model = new MachinePartEdit
            {
                MachinePartId = detail.MachinePartId,
                PartName = detail.PartName,
                PartNumber = detail.PartNumber,
                Cost = detail.Cost,
                NumberInStock = detail.NumberInStock,
                AvailableToOrder = detail.AvailableToOrder
            };
            return View(model);
        }
        //POST: EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MachinePartEdit model)
        {
            if (!ModelState.IsValid)
            {
                
                return View(model);
            }
            if(model.MachinePartId != id)
            {
                ModelState.AddModelError("", "ID mismatch");
                return View(model);
            }
            var service = CreatePartService();
            if (service.EditMachinePart(model))
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "An error has occured.");
            return View(model);
        }
    }
}