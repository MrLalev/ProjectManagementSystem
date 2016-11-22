using ProjectManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectManagementSystem.Filters
{
    public class AdminFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (AuthenticationManager.LoggedEmployee.AdminRole != true)
            {
                filterContext.Result = new RedirectResult("/Home/Index");
                return;
            }
        }
    }
}