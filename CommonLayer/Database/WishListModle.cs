using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Database
{
   public class WishListModle
    {
        public int CartID { get; set; }
        public int UserID { get; set; }
        public int BookID { get; set; }
        public string BookName { get; set; }
        public string BookPrice { get; set; }
        public string BookAurthor { get; set; }
        public string BookCategory { get; set; }
        public string BookLanguage { get; set; }
    }
}
