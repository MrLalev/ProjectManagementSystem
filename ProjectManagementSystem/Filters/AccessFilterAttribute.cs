using ProjectManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using DataAccess.Entity;
using DataAccess.Service;
namespace ProjectManagementSystem.Filters
{
    public class AccessFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
                var url = filterContext.HttpContext.Request.Url.AbsolutePath;
                string[] keys = url.Split('/');
                
                switch (keys[1])
                {
                    case "Comment":
                        {
                            if (keys.Count() >= 3)
                            {
                                if (keys[2] != "Create")
                                {
                                    CommentService service = new CommentService();
                                    if (keys.Count() == 4)
                                    {
                                        if (AuthenticationManager.LoggedEmployee.Id != service.GetById(Convert.ToInt32(keys[3])).CreatorId)
                                        {
                                            filterContext.Result = new RedirectResult("/Task/Index");
                                            return;
                                        }
                                    }

                                }
                                else
                                {
                                    goto case "Task";
                                }
                            }
                          
                            break;
                       }
                    case "Project_Report":
                        {
                            if (keys.Count() >= 3)
                            {
                                if (keys[2] != "Create")
                                {
                                    Project_ReportService service = new Project_ReportService();
                                    if (keys.Count() == 4)
                                    {
                                        if (AuthenticationManager.LoggedEmployee.Id != service.GetById(Convert.ToInt32(keys[3])).CreatorId)
                                        {
                                            filterContext.Result = new RedirectResult("/Project/Index");
                                            return;
                                        }
                                    }

                                }
                                else
                                {
                                    goto case "Project";
                                }
                            }
                            

                            break;
                        }
                    case "Task":
                        {
                            TaskService service = new TaskService();
                            if (keys.Count() == 4)
                            {
                                if (AuthenticationManager.LoggedEmployee.Id != service.GetById(Convert.ToInt32(keys[3])).CreatorId && AuthenticationManager.LoggedEmployee.Id != service.GetById(Convert.ToInt32(keys[3])).AssignetId)
                                {
                                    filterContext.Result = new RedirectResult("/Task/Index");
                                    return;
                                }
                            }

                            break;
                        }
                    case "Project":
                        {
                            ProjectService service = new ProjectService();
                            if (keys.Count() == 4)
                            {
                                if (AuthenticationManager.LoggedEmployee.TeamId != service.GetById(Convert.ToInt32(keys[3])).TeamId)
                                {
                                    filterContext.Result = new RedirectResult("/Project/Index");
                                    return;
                                }
                            }

                            break;
                        }
                    case "Team":
                    case "Employee": 
                    case "Department":
                    case "Position":
                        {
                            if (AuthenticationManager.LoggedEmployee.AdminRole != true)
                            {
                                filterContext.Result = new RedirectResult("/Home/Index");
                                return;
                            }
                            break;
                        }
                    default:
                        break;
                }
            }

    }
}