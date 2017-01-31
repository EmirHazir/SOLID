using Solid.Entities.SSConcrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solid.Services.SSAbstract
{
    public interface ICartService
    {
        //hangi Sepete hangi producti
        void AddToCart(Cart cart, Product product);
        //hangi sepetten hangi productin idsi
        void RemoveCart(Cart cart, int productId);
        //Sepeti Listele
        List<CartLine> List(Cart cart);
    }

}
