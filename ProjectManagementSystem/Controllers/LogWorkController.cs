using DataAccess.Entity;
using DataAccess.Service;
using ProjectManagementSystem.Models;
using ProjectManagementSystem.ViewModels.LogWorkVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectManagementSystem.Controllers
{
    public class LogWorkController : BaseController<LogWork, ListLogWorkVM, EditLogWorkVM, DetailsLogWorkVM, LogWorkFilterVM>
    {
        public override void FillList(EditLogWorkVM model)
        {
            TaskService TaskService = new TaskService();
            ProjectService ProjectService = new ProjectService();
            List<Project> projects = ProjectService.GetAll(p => p.TeamId == AuthenticationManager.LoggedEmployee.TeamId).ToList();
            List<Task> tasks = new List<Task>();

            foreach (var item in projects)
            {
                foreach (var task in TaskService.GetAll(t => t.ProjectId == item.Id && (t.AssignetId == AuthenticationManager.LoggedEmployee.Id || t.CreatorId == AuthenticationManager.LoggedEmployee.Id) && t.Status != "Resolved" && t.Status != "Closed").ToList())
                {
                    tasks.Add(task);
                }
            }

            model.ListTask = new List<SelectListItem>();
            foreach (var item in tasks)
            {
                model.ListTask.Add(new SelectListItem()
                {
                    Text = item.Title,
                    Value = item.Id.ToString()
                });

            }


            if (model.ListTask.Count() > 0)
            {
                if (model.TaskId != 0)
                {
                    model.ListTask.Find(p => p.Value == model.TaskId.ToString()).Selected = true;
                }
                else
                {
                    model.ListTask[0].Selected = true;
                }

            }

            model.ListWorkType = new List<SelectListItem>();
            model.ListWorkType.Add(new SelectListItem() { Text = "Development", Value = "Development" });
            model.ListWorkType.Add(new SelectListItem() { Text = "Design", Value = "Design" });

            if (model.ListWorkType.Count() > 0)
            {
                model.ListWorkType[0].Selected = true;
            }
        }
        public override void ExtraDelete(LogWork logWork)
        {
        }
        public override void AddAdditionalInfo(ListLogWorkVM model)
        {
            EmployeeService EmployeeService = new EmployeeService();
            model.employees = new string[model.Items.Count()];

            for (int i = 0; i < model.Items.Count(); i++)
            {
                model.employees[i] = EmployeeService.GetById(model.Items[i].EmployeeId).FirstName + " " + EmployeeService.GetById(model.Items[i].EmployeeId).LastName;
            }
        }
        public override void PopulateItem(LogWork logWork, EditLogWorkVM model)
        {
            logWork.Id = model.Id;
            logWork.EmployeeId = AuthenticationManager.LoggedEmployee.Id;
            logWork.HoursWorked = model.HoursWorked;
            logWork.TaskId = model.TaskId;
            logWork.WorkType = model.WorkTypeValue;

            TaskService taskService = new TaskService();
            Task task = taskService.GetById(model.TaskId);
            task.LogWork += model.HoursWorked;
            taskService.Edit(task);
        }

        public override void PopulateModel(LogWork logWork, EditLogWorkVM model)
        {
            model.Id = logWork.Id;
            model.HoursWorked = logWork.HoursWorked;
            model.WorkTypeValue = logWork.WorkType;
            model.TaskId = logWork.TaskId;
        }

        public override void PopulateModelDelete(LogWork logWork, DetailsLogWorkVM model)
        {
            model.Id = logWork.Id;
            model.HoursWorked = logWork.HoursWorked;
            model.WorkType = logWork.WorkType;
            EmployeeService EmployeeService = new EmployeeService();
            model.Employee = EmployeeService.GetById(logWork.EmployeeId).FirstName + " " + EmployeeService.GetById(logWork.EmployeeId).LastName;
        }

        public override BaseService<LogWork> SetService()
        {
            return new LogWorkService();
        }
    }
}