using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Solid.Entities.SSConcrete;
using Microsoft.AspNetCore.Http;
using Solid.WebUI.ExtentionForSession;

namespace Solid.WebUI.UIServicesforSessionManage
{
    public class CartSessionService : ICartSessionService
    {
        private IHttpContextAccessor _httpContextAccessor;
        public CartSessionService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        
        public Cart GetCart()
        {
            //sepeti kontrol et varsa zaten onu döndüreceksin
          Cart cartToCheck =  _httpContextAccessor.HttpContext.Session.GetObject<Cart>("cart");
            if (cartToCheck== null) //eğer sepette yoksa
            {
                _httpContextAccessor.HttpContext.Session.SetObject("cart", new Cart()); //yeni cart oluştur
                cartToCheck = _httpContextAccessor.HttpContext.Session.GetObject<Cart>("cart"); //sonra oluşan carti sessiona  ekle
            }
            return cartToCheck;
        }

        public void SetCart(Cart cart)
        {
            _httpContextAccessor.HttpContext.Session.SetObject("cart", cart);
        }
    }
}
