using System;
using System.Collections.Generic;
using System.Text;
using MovieAPP.Data.Repositories;
using MovieAPP.Entity;

namespace MovieAPP.Business.Services
{
    public class UserService
    {
        IUser _iuser;

        public UserService(IUser user)
        {
            _iuser = user;
        }

        public string Register(UserModel userModel)
        {
            return _iuser.Register(userModel);
        }

        public object SelectUsers()
        {
            return _iuser.SelectUsers();
        }


        public object SelectUserById(int userId)
        {
            return _iuser.SelectUserById(userId);
        }

        public string UpdateUser(UserModel userModel)
        {
            return _iuser.Update(userModel);
        }

        public string DeleteUser(int userId)
        {
            return _iuser.Delete(userId);
        }


        public object LoginUser(UserModel userModel)
        {
            return _iuser.Login(userModel);
        }


    }
}
