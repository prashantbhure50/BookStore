using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Database
{
   public class CartModle
   {
        public int CartID { get; set; }
        public int UserID { get; set; }
        public int BookID { get; set; }
        public string BookName { get; set; }
        public string BookQuantity { get; set; }
        public string BookPrice { get; set; }
     
   }
}
