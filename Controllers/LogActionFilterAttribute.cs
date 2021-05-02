using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Refrence.Models;
using Refrence.Utillity;
using System;

namespace Refrence.Controllers
{
    internal class LogActionFilterAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // get the user variable
            UserModel user = (UserModel)((Controller)context.Controller).ViewData.Model;
            MyLogger.GetInstance().Info("Leaving the ProcessLogin method");
            MyLogger.GetInstance().Info("User that Loged in:" + user.toString());
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            MyLogger.GetInstance().Info("Entering the ProcessLogin method");
        }
    }
}