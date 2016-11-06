using DataAccess.Entity;
using DataAccess.Service;
using ProjectManagementSystem.Models;
using ProjectManagementSystem.ViewModels.EmployeeVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectManagementSystem.Controllers
{
    public class EmployeeController : BaseController<Employee, ListEmployeeVM, EditEmployeeVM, DetailsEmployeeVM, EmployeeFilterVM>
    {
        public override void FillList(EditEmployeeVM model)
        {
            EmployeeService EmployeeService = new EmployeeService();
            List<Employee> managers = EmployeeService.GetAll().ToList();

            model.ListManagers = new List<SelectListItem>();
            model.ListManagers.Add(new SelectListItem(){Text = "", Value = null});
            foreach (var item in managers)
            {
                if (item.Id != AuthenticationManager.LoggedEmployee.Id)
                {
                    model.ListManagers.Add(new SelectListItem()
                    {
                        Text = item.FirstName + " " + item.LastName,
                        Value = item.Id.ToString()
                    });
                }

            }

            model.ListManagers[0].Selected = true;

            TeamService TeamService = new TeamService();
            List<Team> teams = TeamService.GetAll().ToList();

            model.ListTeams = new List<SelectListItem>();
            foreach (var item in teams)
            {
                model.ListTeams.Add(new SelectListItem()
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });

            }

            model.ListTeams[0].Selected = true;

            PositionService PositionService = new PositionService();
            List<Position> positions = PositionService.GetAll().ToList();

            model.ListPositions = new List<SelectListItem>();
            foreach (var item in positions)
            {
                model.ListPositions.Add(new SelectListItem()
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });

            }

            model.ListPositions[0].Selected = true;
        }

        public override void ExtraDelete(Employee employee)
        {
            TaskService TaskService = new TaskService();
            List<Task> tasks = TaskService.GetAll(t => t.AssignetId == employee.Id && t.Status != "Resolved").ToList();

            foreach (var item in tasks)
            {
                TaskService.Delete(item);
            }

            CommentService CommentService = new CommentService();
            List<Comment> comments = CommentService.GetAll(c => c.CreatorId == employee.Id).ToList();

            foreach (var item in comments)
            {
                CommentService.Delete(item);
            }
        }

        public override void PopulateItem(Employee employee, EditEmployeeVM model)
        {
            employee.Id = model.Id;
            employee.Email = model.Email;
            employee.Password = model.Password;
            employee.FirstName = model.FirstName;
            employee.SecondName = model.SecondName;
            employee.LastName = model.LastName;
            employee.Phone = model.Phone;
            employee.ManagerId = model.ManagerId;
            employee.PositionId = model.PositionId;
            employee.TeamId = model.TeamId;
            employee.Adress = model.Adress;
            employee.DateofBirth = model.DateOfBirth;
            employee.AdminRole = model.AdminRole;
        }

        public override void PopulateModel(Employee employee, EditEmployeeVM model)
        {
            model.Id = employee.Id;
            model.Email = employee.Email;
            model.FirstName = employee.FirstName;
            model.SecondName = employee.SecondName;
            model.LastName = employee.LastName;
            model.Phone = employee.Phone;
            model.ManagerId = employee.ManagerId;
            model.PositionId = employee.PositionId;
            model.TeamId = employee.TeamId;
            model.Adress = employee.Adress;
            model.DateOfBirth = employee.DateofBirth;
            model.AdminRole = employee.AdminRole;
        }

        public override void PopulateModelDelete(Employee employee, DetailsEmployeeVM model)
        {
            model.Id = employee.Id;
            model.Email = employee.Email;
            model.FirstName = employee.FirstName;
            model.SecondName = employee.SecondName;
            model.LastName = employee.LastName;
            model.Phone = employee.Phone;
            model.ManagerId = employee.ManagerId;
            model.PositionId = employee.PositionId;
            model.TeamId = employee.TeamId;
            model.Adress = employee.Adress;
            model.DateOfBirth = employee.DateofBirth;
            model.AdminRole = employee.AdminRole;
        }

        public override BaseService<Employee> SetService()
        {
            return new EmployeeService();
        }
	}
}