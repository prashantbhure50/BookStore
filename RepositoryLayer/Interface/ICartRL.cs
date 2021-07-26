using CommonLayer.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface ICartRL
    {
       public bool AddToCart(CartModle cart);
        public bool DeleteFromCart(CartModle cart);
        public bool UpdateCart(CartModle modle);
    }
}
