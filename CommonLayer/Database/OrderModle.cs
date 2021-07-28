using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Database
{
   public class OrderModle
    {
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public string BookName { get; set; }
        public int BookQuantity { get; set; }
        public string BookPrice { get; set; }
    }
}
