using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Database
{
    public class AddressModle
    {
        public int UserID { get; set; }
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
