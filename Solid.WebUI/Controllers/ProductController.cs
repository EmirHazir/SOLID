using Microsoft.AspNetCore.Mvc;
using Solid.Services.SSAbstract;
using Solid.WebUI.Models;
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


        public ActionResult Index(int page=1,int category=0)
        {
            int pageSize = 10;

            var products = _productService.GetByCategory(category);
            ProductListModel model = new ProductListModel
            {
                Products = products.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                PageCount = (int)Math.Ceiling(products.Count / (double)pageSize),
                PageSize = pageSize,
                CurrentCategory=category,
                CurrentPage = page
            };
            return View(model);
        }
    }
}
