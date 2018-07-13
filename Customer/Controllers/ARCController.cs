using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Customer.Controllers
{
    public class ARCController : Controller
    {
        // GET: ARC
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewTest()
        {
            string model = "My Data";
            return View((object)model);
        }
    }
}