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
        public string BookAurthor { get; set; }
        public string BookCategory { get; set; }
        public string BookLanguage { get; set; }
        public string AddressDetail { get; set; }
        public int BookID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Address { get; set; }
        public string Pincode { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
    }
}
