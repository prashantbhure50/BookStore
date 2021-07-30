using BusinessLayer.Interface;
using CommonLayer.Database;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class AddressBL : IAddressBL
    {
        IAddressRL AddressRl;
        public AddressBL(IAddressRL AddressRl)
        {
            this.AddressRl = AddressRl;
        }
        public bool AddAddress(AddressModle book)
        {
            return this.AddressRl.AddAddress(book);
        }
        public IEnumerable<AddressModle> Get()
        {
            return this.AddressRl.Get();
        }
        public bool DeleteAddress(AddressModle id)
        {
            return this.AddressRl.DeleteAddress(id);
        }
        public bool UpdateAddress(AddressModle book)
        {
            return this.AddressRl.UpdateAddress(book);
        }
    }
}

