using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Solid.WebUI.Models;
using Solid.WebUI.UIServicesforSessionManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solid.WebUI.ViewComponents
{
    //Burada kart içeriği göstericem üst soldaki menude onun için sessionu yakalamam lazım
    //ve bunun için bir component yazmalıyım
    public class CartSummaryViewComponent : ViewComponent
    {
        private ICartSessionService _cartSessionService;
        public CartSummaryViewComponent(ICartSessionService cartSessionService)
        {
            _cartSessionService = cartSessionService;
        }

        //burada Invoke diyip modeli içine basıyorum
        public ViewViewComponentResult Invoke()
        {
            var model = new CartListViewModel
            {
                Cart = _cartSessionService.GetCart()
            };
            return View(model);
        }

    }
}
