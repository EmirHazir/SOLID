using Microsoft.AspNetCore.Mvc;
using Solid.Services.SSAbstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


//Bu katmanda yani Ön Yüzde ASLA SSAbstract klasörü haricinde başka bir yerden veri KULLANMA(Bu Solid e aykırı)
namespace Solid.WebUI.Controllers
{
    public class ProductController:Controller
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        public ActionResult Index()
        {
            return View();
        }
    }
}
