using CommonLayer.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IUserBL
    {
        Users AddUser(Users user);
        //string Login(string email, string password);
    }
}
