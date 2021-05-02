using Refrence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Refrence.Services
{
    public class SecurityService
    {
        // we will create list of users
        //List<UserModel> users = new();

        UsersDAO usersDAO = new();
        public SecurityService()
        {

        }
        public bool IsValid(UserModel user)
        {
            return usersDAO.FindUserByUserNameAndPassword(user);
        }
    }
}
