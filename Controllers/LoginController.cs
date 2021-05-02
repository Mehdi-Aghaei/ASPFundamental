using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;
using Refrence.Models;
using Refrence.Services;
using Refrence.Utillity;
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

        // we can create custom  Attribute by use this [AttrName] and then create class for that and implement
        //  Attribute, or other INterfaces and classess
        [HttpGet]
        [CustomAuthorization]
        public IActionResult PrivateSectionMustBeLoggedIn()
        {
            return Content("What are you looking For here :)) ?");
        }
        [LogActionFilter]
        public IActionResult ProcessLogin(UserModel user)
        {
            SecurityService securityService = new();
            if (securityService.IsValid(user))
            {
                HttpContext.Session.SetString("username", user.UserName);
                return View("LoginSuccess", user);
            }
            else
            {
                HttpContext.Session.Remove("username");
                return View("LoginFailure", user);
            }
        }
    }
}
