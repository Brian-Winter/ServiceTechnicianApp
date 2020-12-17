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

        //POST: Create

        //GET: Details

        //GET: Edit

        //POST: Edit
    }
}