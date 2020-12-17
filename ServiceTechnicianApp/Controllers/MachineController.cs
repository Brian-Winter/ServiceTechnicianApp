﻿using Service.Model.MachineModels;
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
        private MachineService CreateMachineService()
        {
            var service = new MachineService();
            return service;
        }
        // GET: Machine
        public ActionResult Index()
        {
            var service = CreateMachineService();
            var model = service.GetAllMachines();
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
    }
}