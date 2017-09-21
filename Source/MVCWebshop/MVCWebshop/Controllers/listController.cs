using MVCWebshop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWebshop.Controllers
{
    public class listController : Controller
    {
        // GET: list
        public ActionResult List()
        {
            return View((List<Product>)HttpContext.Application["Productlist"]);
        }
       
    }
}
