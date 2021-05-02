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
            MyLogger.GetInstance().Info("Processing a login attempt");
            MyLogger.GetInstance().Info(user.toString());
            //MyLogger.GetInstance().Info("Processing a login attemp");
            SecurityService securityService = new();
            if (securityService.IsValid(user))
            {
                MyLogger.GetInstance().Info("Loggin success");
                HttpContext.Session.SetString("username", user.UserName);
                //MyLogger.GetInstance().Info("Login Success");
                return View("LoginSuccess", user);
            }
            else
            {
                MyLogger.GetInstance().Warning("Login Failure");
                return View("LoginFailure", user);
            }
        }
    }
}
