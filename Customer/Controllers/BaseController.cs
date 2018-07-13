using Customer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Customer.Controllers
{
    public class BaseController : Controller
    { 
        // GET: Base
    protected 客戶資料管理Entities db = new 客戶資料管理Entities();
   
    protected override void HandleUnknownAction(string actionName)
            {
                this.RedirectToAction("Index").ExecuteResult(this.ControllerContext);
            }
}

}