using Microsoft.AspNetCore.Mvc;
using Solid.Services.SSAbstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Solid.WebUI.Models;

namespace Solid.WebUI.ViewComponents
{
    //Class ismi ViewComponent ile bitmeli CategoryListViewComponent gibi
    public class CategoryListViewComponent : ViewComponent
    {
        private ICategoryService _categoryService;
        public CategoryListViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        //ViewViewComponentResult olmalı
        public ViewViewComponentResult Invoke()
        {
            var model = new CategoryListModel
            {
                Categories = _categoryService.GetAll(),
                CurrentCategory = Convert.ToInt32(HttpContext.Request.Query["category"])
            };

            return View(model);
        }
    }
}
