using Microsoft.AspNetCore.Mvc;
using Solid.Entities.SSConcrete;
using Solid.Services.SSAbstract;
using Solid.WebUI.Models;
using Solid.WebUI.UIServicesforSessionManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solid.WebUI.Controllers
{
    public class CartController : Controller
    {
        //ihtiyacım olan servisler Session için ve bunların Depences Injectionları
        private ICartSessionService _cartSessionservice;
        private ICartService _cartService;
        private IProductService _productService;
        public CartController(
            ICartSessionService cartSessionService, 
            ICartService cartService,
            IProductService productService)
        {
            _cartSessionservice = cartSessionService;
            _cartService = cartService;
            _productService = productService;
        }


        public ActionResult AddToCart(int productId)
        {
            var productTobeAdded = _productService.GetById(productId); //producttan id ile çektik

            var cart = _cartSessionservice.GetCart(); //bunun için sessionu genişlettik

            
            _cartService.AddToCart(cart,productTobeAdded); // cartServiceye bir cart ekle product tipte

            _cartSessionservice.SetCart(cart); // ve bunu tekrar set et diyorum

            TempData.Add("message", String.Format("Ürününüz , {0} ,başarıyla carta eklendi ",productTobeAdded.ProductName)); //TempData tek requestlik veri taşır mesaj filan

            return RedirectToAction("Index", "Product");
        }



        public ActionResult List()
        {
            var cart = _cartSessionservice.GetCart(); //sessionu cektik
            CartListViewModel cartListViewModel = new CartListViewModel //modeli newledik
            {
                Cart = cart // modeldeki Cartın sessionda ki kart oldugunu söyledik
            };
            return View(cartListViewModel); //geriye de bu listeyi döndürdük
        }

        public ActionResult Remove(int productId)
        {
            var cart = _cartSessionservice.GetCart(); //sessionu cektik
            _cartService.RemoveCart(cart, productId); // silinecek olan bilgiyi sildik
            _cartSessionservice.SetCart(cart); // tekrar sessiona kaydettik
            TempData.Add("message", String.Format("Ürününüz başarıyla carttan silindi ")); //TempData tek requestlik veri taşır mesaj filan
            return RedirectToAction("List");//Aynı List actiona git
        }

        public ActionResult Complete()
        {
            var shippingDetailsViewModel = new ShippingDetailsViewModel
            {
                ShippingDetails = new ShippnigDetails()
            };
            return View(shippingDetailsViewModel);
        }

        [HttpPost]
        public ActionResult Complete(ShippnigDetails shippingDetails)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            TempData.Add("message",String.Format("Merhaba {0}, siparişiniz hazırlanıyor",shippingDetails.FirstName));
            return View();
            //Database e ekleme işlemini henüz yapamıyorum
        }
    }
}
