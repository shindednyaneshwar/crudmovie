using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MovieAPP.Data.DataConnections;
using MovieAPP.Entity;
using System.Linq; 

namespace MovieAPP.Data.Repositories
{
    public class User : IUser
    {
        //to access usermodel from dataconnection i have to create instance of class i.e MovieDbContext
        MovieDBContext _movieDbContext;


        //creating runtime instance of MovieDBContext and assign to localvariable(_movieDbContext)
        public User(MovieDBContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }

        public string Delete(int userId)
        {
            var user = _movieDbContext.userModel.Find(userId);
            if (user == null)
                return "";
            // _movieDbContext.userModel.Remove(user);
            //i.e from user entitystate is deleted
            _movieDbContext.Entry(user).State = EntityState.Deleted;

            _movieDbContext.SaveChanges();

            return "Deleted";

        }

        public UserModel Login(UserModel userModel)
        {
            UserModel userData = null;
            //linq= var result = from table in collectionobjectOrxml(userModel)
            //select table

            //sql query = select * from userModel where email=userModel.email && pass==userModel.pass
           var user= _movieDbContext.userModel.Where(u => u.Email == userModel.Email && u.Password == userModel.Password).ToList();
            if (user.Count > 0)
                userData = user[0];
            return userData;
        }


        //Now you have to insert record of UserModel from entity inside userModel table
        public string Register(UserModel userModel)
        {
            string msg = "";
            //insert into userModel values(userModel.Id,userModel.FName,userModel.LastName, like that)
            _movieDbContext.userModel.Add(userModel);//inserted in table
            _movieDbContext.SaveChanges();//execute sql statement in database
            msg = "Inserted";
            return msg;

            
        }

        public object SelectUsers()
        {
            //select * from userModel(table)
            List<UserModel> userList=_movieDbContext.userModel.ToList();
            return userList;
        }

        public string Update(UserModel userModel)
        {
           
            _movieDbContext.Entry(userModel).State = EntityState.Modified;

            _movieDbContext.SaveChanges();

            return "Updated";

        }

        public object SelectUserById(int userId)
        {
            var user = _movieDbContext.userModel.Find(userId);
            if (user == null)
                return "";
            return user;
        }
    }
}
