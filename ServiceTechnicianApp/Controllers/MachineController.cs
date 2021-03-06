﻿using Service.Model.MachineModels;
using Service.Contracts;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServiceTechnicianApp.Controllers
{
    public class MachineController : Controller
    {
        private readonly IMachineService _machineService;
        private MachineService CreateMachineService()
        {
            var service = new MachineService();
            return service;
        }
        // GET: Machine
        public ActionResult Index()
        {
            var service = CreateMachineService();
            var model = service.GetViewBaseMachines();
            return View(model);
        }
        //GET: Machines with Serial
        public ActionResult Machine(string id)
        {
            var service = CreateMachineService();
            var model = service.GetAllMachinesbyName(id);
            if(id == null)
            {
               var modelTwo = service.GetAllMachines();
                return View(modelTwo);
            }
            return View(model);
        }
        public ActionResult CreateSerial(int id)
        {
            var service = CreateMachineService();
            var model = service.GetMachineByIdForSerial(id);
            return View(model);
        }
        //GET: Create Add Serial Number
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSerial(MachineCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var service = CreateMachineService();

            if (service.CreateMachine(model))
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Machine could not be created.");
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
        public ActionResult Create(MachineCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var service = CreateMachineService();

            if (service.CreateMachine(model))
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Machine could not be created.");
            return View(model);
        }
        //GET: Details
        public ActionResult Details(int id)
        {
            var service = CreateMachineService();
            var model = service.GetMachineById(id);
            return View(model);
        }
        //GET: Edit
        public ActionResult Edit(int id)
        {
            var service = CreateMachineService();
            var detail = service.GetMachineById(id);
            var model = new MachineEdit
            {
                MachineId = detail.MachineId,
                MachineName = detail.MachineName,
                SerialNumber = detail.SerialNumber,
                NumberOfDrawers = detail.NumberOfDrawers,
                Color = detail.Color
            };
            return View(model);
        }
        //POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MachineEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (model.MachineId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateMachineService();

            if (service.EditMachine(model))
            {
               
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your note was unable to be updated.");
            return View(model);
        }
        //GET: DELETE
         [ActionName("Delete")]
         public ActionResult Delete(int id)
        {
            var service = CreateMachineService();
            var model = service.GetMachineById(id);
            return View(model);
        }
        //POST: DELETE
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteMachine(int id)
        {
            var service = CreateMachineService();

            service.DeleteMachine(id);

            return RedirectToAction("Index");
        }
        
    }
}