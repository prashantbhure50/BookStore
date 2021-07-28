using BusinessLayer.Interface;
using CommonLayer.Database;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class WishListBL: IWishListBL
    {
        IWishListRL wishListRl;
        public WishListBL(IWishListRL wishListRl)
        {
            this.wishListRl = wishListRl;
        }
        public bool AddToWishList(WishListModle modle)
        {
            return this.wishListRl.AddToWishList(modle);
        }
        public bool RemoveFromWishList(WishListModle modle)
        {
            return this.wishListRl.RemoveFromWishList(modle);
        }
        public bool UpdateWishList(WishListModle modle)
        {
            return this.wishListRl.UpdateWishList(modle);
        }
    }
}
