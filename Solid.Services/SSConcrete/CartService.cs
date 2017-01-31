using Solid.Services.SSAbstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Solid.Entities.SSConcrete;

namespace Solid.Services.SSConcrete
{
    public class CartService : ICartService
    {
        public void AddToCart(Cart cart, Product product)
        {
            //eğer sepette böyle bir ürün varmi.
            //Cartline daki ProductId bizim gonderdiğimiz ProductId ise onu Cartline a gönder
            CartLine cartLine = cart.CartLines.FirstOrDefault(x => x.Product.ProductId == product.ProductId);
            if (cartLine!=null) //sepette ürün varsa
            {
                cartLine.Quantity++; //ürünü arttır
                return;
            }
            //Yoksa cart a yeni bir cartline içeriği aç Product a da benim gönderdiğim product i, Adeti 1 olarak ekle
            cart.CartLines.Add(new CartLine { Product = product ,Quantity = 1 });
        }

        public List<CartLine> List(Cart cart)
        {
            return cart.CartLines;
        }

        public void RemoveCart(Cart cart, int productId)
        {
            //benim gönderdiğim productId yi bul sepetten adamın seçtiği Id is sil
            cart.CartLines.Remove(cart.CartLines.FirstOrDefault(x => x.Product.ProductId == productId));
        }
    }
}
