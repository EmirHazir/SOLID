using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solid.Entities.SSConcrete
{
    //Sepet
    public class Cart
    {
        public Cart()
        {
            CartLines = new List<CartLine>();
        }

        public List<CartLine> CartLines { get; set; }


        public decimal Total
        {
            get { return CartLines.Sum(x => x.Product.UnitPrice * x.Quantity); }
        }

    }
}
