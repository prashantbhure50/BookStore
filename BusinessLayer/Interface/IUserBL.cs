using CommonLayer.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IUserBL
    {
        bool AddUser(Users user);
        string Login(string email, string password);
        public bool ForgotPassword(string email);
    }
}
