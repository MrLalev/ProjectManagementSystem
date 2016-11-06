using ProjectManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectManagementSystem.Filters
{
    public class LogedFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (AuthenticationManager.LoggedEmployee == null)
            {
                filterContext.Result = new RedirectResult("/Home/LogIn");
                return;
            }
        }
    }
}