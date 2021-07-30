using CommonLayer.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
   public interface IAddressRL
    {
        bool AddAddress(AddressModle address);
        IEnumerable<AddressModle> Get();
        bool DeleteAddress(AddressModle id);
        bool UpdateAddress(AddressModle address);
    }
}
