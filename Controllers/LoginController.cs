using Microsoft.AspNetCore.Mvc;
using Refrence.Models;
using Refrence.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Refrence.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [CustomAuthorization]
        // we can create custom  Attribute by use this [AttrName] and then create class for that and implement
        //  Attribute, or other INterfaces and classess
        public IActionResult PrivateSectionMustBeLoggedIn()
        {
            return View();
        }
        public IActionResult ProcessLogin(UserModel user)
        {
            SecurityService securityService = new();
            if (securityService.IsValid(user))
            {
                return View("LoginSuccess", user);
            }
            else
            {
                return View("LoginFailure", user);
            }
        }
    }
}
