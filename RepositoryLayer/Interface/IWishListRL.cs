using CommonLayer.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IWishListRL
    {
        public bool AddToWishList(WishListModle list);
        public bool RemoveFromWishList(WishListModle id);
        public bool UpdateWishList(WishListModle modle);
        IEnumerable<WishListModle> Get();
    }
}
