using CommonLayer.Database;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Service
{
    public class UserRL : IUserRL
    {
        public Users AddUser(Users newuser)
        {
            //_userDbContext.User.Add(newuser);
            //_userDbContext.SaveChanges();
            return newuser;
        }
    }
}
