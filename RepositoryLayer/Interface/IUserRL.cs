using CommonLayer.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
   public interface IUserRL
    {
        Users AddUser(Users user);
        //string Login(string email, string password);
    }
}
