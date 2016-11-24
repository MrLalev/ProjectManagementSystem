using ProjectManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using DataAccess.Entity;
using DataAccess.Service;
using System.Reflection;
namespace ProjectManagementSystem.Filters
{
    public class AccessFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
                var url = filterContext.HttpContext.Request.Url.AbsolutePath;
                string[] keys = url.Split('/');

                Type typeEntity = typeof(BaseId).Assembly.GetType("DataAccess.Entity." + keys[1]);

                Type serviceType = typeof(BaseService<BaseId>).Assembly.GetType("DataAccess.Service." + keys[1] + "Service");

                var service = Activator.CreateInstance(serviceType);

                object entity = serviceType.GetMethod("GetById").Invoke(service, new object[] { Convert.ToInt32(keys[3]) });
                PropertyInfo piId = typeEntity.GetProperty("Id");
                PropertyInfo piCreator = typeEntity.GetProperty("CreatorId");
                PropertyInfo piAssigned = typeEntity.GetProperty("AssignetId");
                PropertyInfo piTeamId = typeEntity.GetProperty("TeamId");

                var IdValue = piId.GetValue(entity, null);
                var CreatorValue = piCreator != null ? piCreator.GetValue(entity, null) : null;
                var AssignedValue = piAssigned != null ? piAssigned.GetValue(entity, null) : null;
                var TeamValue = piTeamId != null ? piTeamId.GetValue(entity, null) : null;

                if (AssignedValue == null && CreatorValue != null)
                {
                    if (AuthenticationManager.LoggedEmployee.Id != Convert.ToInt32(CreatorValue))
                    {
                        filterContext.Result = new RedirectResult("/"+ keys[1] + "/Index");
                        return;
                    }
                }
                else if (AssignedValue == null && CreatorValue == null && TeamValue!=null)
	            {
                    if (AuthenticationManager.LoggedEmployee.TeamId != Convert.ToInt32(TeamValue))
                    {
                        filterContext.Result = new RedirectResult("/" + keys[1] + "/Index");
                        return;
                    }
	            }
                else
                {
                    if (AuthenticationManager.LoggedEmployee.Id != Convert.ToInt32(CreatorValue) && AuthenticationManager.LoggedEmployee.Id !=  Convert.ToInt32(AssignedValue))
                    {
                        filterContext.Result = new RedirectResult("/" + keys[1] + "/Index");
                        return;
                    }
                }

            }

    }
}