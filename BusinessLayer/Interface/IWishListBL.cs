using CommonLayer.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IWishListBL
    {
        public bool AddToWishList(WishListModle list);
        public bool RemoveFromWishList(WishListModle id);
        public bool UpdateWishList(WishListModle modle);
        IEnumerable<WishListModle> Get(int id);
    }
}
