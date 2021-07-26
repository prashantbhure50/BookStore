using BusinessLayer.Interface;
using CommonLayer.Database;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class CartBL: ICartBL
    {
        ICartRL cartRl;
        public CartBL(ICartRL cartRl)
        {
            this.cartRl = cartRl;
        }
        public bool AddToCart(CartModle cart)
        {
            return this.cartRl.AddToCart(cart);
        }
        public bool DeleteFromCart(CartModle cart)
        {
            return this.cartRl.DeleteFromCart(cart);
        }
        public bool UpdateCart(CartModle cart)
        {
            return this.cartRl.UpdateCart(cart);
        }
    }
}
