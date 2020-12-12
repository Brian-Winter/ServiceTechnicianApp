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
        // GET: ServiceForm
        public ActionResult Index()
        {
            return View();
        }
    }
}