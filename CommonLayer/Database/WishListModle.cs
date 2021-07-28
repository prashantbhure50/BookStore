using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Database
{
   public class WishListModle
    {
        public int CartID { get; set; }
        public int UserID { get; set; }
        public string BookName { get; set; }
        public string BookPrice { get; set; }
    }
}
