using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Solid.WebUI.Controllers
{
    public class ProductController:Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
