﻿using BusinessLayer.Interface;
using CommonLayer.Database;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class UserBL : IUserBL
    {
        IUserRL userRl;
        public UserBL(IUserRL userRl)
        {
            this.userRl = userRl;
        }
        public Users AddUser(Users user)
        {
            this.userRl.AddUser(user);
            return user;
        }


        public string Login(string email, string password)
        {
            return this.userRl.Login(email, password);
        }
    }
}
