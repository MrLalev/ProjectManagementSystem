using DataAccess.Entity;
using DataAccess.Service;
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