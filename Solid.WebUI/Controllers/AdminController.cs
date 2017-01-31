using Microsoft.AspNetCore.Mvc;
using Solid.Entities.SSConcrete;
using Solid.Services.SSAbstract;
using Solid.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Solid.WebUI.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;
        public AdminController(IProductService productService,ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }


        public ActionResult Index()
        {
            var productListViewModel = new ProductListModel
            {
                Products = _productService.GetAll()
            };
            return View(productListViewModel);
        }


        public ActionResult Add()
        {
            var model = new ProductAddViewModel
            {
                Product = new Product(),
                Categories = _categoryService.GetAll()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(Product product,Category category)
        {
            if (ModelState.IsValid)
            {
                _productService.Add(product);
                TempData.Add("message", String.Format("{0} adlı ürün {1} numaralı kategoriye başarıyla eklendi", product.ProductName, category.CategoryName));
            }
            return RedirectToAction("Add");
        }


        public ActionResult Update(int productId)
        {
            var model = new ProductUpdateViewModel
            {
                Product = _productService.GetById(productId),
                Categories = _categoryService.GetAll()
            };
            return View(model);
        }


        [HttpPost]
        public ActionResult Update(Product product, Category category)
        {
            if (ModelState.IsValid)
            {
                _productService.Update(product);
                TempData.Add("message", String.Format("{0} adlı ürün {1} numaralı kategoride başarıyla güncellendi", product.ProductName, category.CategoryName));
            }
            return RedirectToAction("Update");
        }


        public ActionResult Delete(int productId,Product product)
        {
            _productService.Delete(productId);
            TempData.Add("message", String.Format("{0} adlı ürün silindi ", product.ProductName));
            return RedirectToAction("Index");
        }


    }
}
