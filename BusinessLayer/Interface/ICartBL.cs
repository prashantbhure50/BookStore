using CommonLayer.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface ICartBL
    {
        public bool AddToCart(CartModle cart);
        public bool DeleteFromCart(CartModle cart);
        public bool UpdateCart(CartModle modle);
        IEnumerable<CartModle> GetCart(int id);
    }
}
