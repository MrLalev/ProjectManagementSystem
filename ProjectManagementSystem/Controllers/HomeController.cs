using DataAccess.Entity;
using DataAccess.Service;
using ProjectManagementSystem.Filters;
using ProjectManagementSystem.Models;
using ProjectManagementSystem.ViewModels.EmployeeVM;
using ProjectManagementSystem.ViewModels.HomeVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        public class HomeController : Controller
        {
            public ActionResult Index()
            {
                return View();

            }

            [HttpGet]
            public ActionResult Create()
            {
                EditEmployeeVM model = new EditEmployeeVM();

                return View(model);
            }

            [HttpPost]
            public ActionResult Create(EditEmployeeVM model)
            {
                if (!this.ModelState.IsValid)
                {
                    return View(model);
                }

                EmployeeService service = new EmployeeService();
                Employee newItem = new Employee();

                newItem.Email = model.Email;
                newItem.Password = model.Password;
                newItem.FirstName = model.FirstName;
                newItem.SecondName = model.SecondName;
                newItem.LastName = model.LastName;
                newItem.Phone = model.Phone;
                newItem.AdminRole = model.AdminRole;
                newItem.ManagerId = model.ManagerId;
                newItem.PositionId = model.PositionId;
                newItem.TeamId = model.TeamId;
                newItem.Adress = model.Adress;
                newItem.DateofBirth = model.DateOfBirth;

                service.Create(newItem);

                return RedirectToAction("Login");
            }


            [HttpGet]
            public ActionResult LogIn()
            {
                return View();

            }

            [HttpPost]
            public ActionResult LogIn(LogInVM login)
            {
                AuthenticationManager.Authenticate(login.Email, login.Password);

                if (AuthenticationManager.LoggedEmployee == null)
                {
                    return RedirectToAction("LogIn", "Home");
                }
                else
                {
                    return RedirectToAction("Index", "Appointment");
                }
            }

            public ActionResult LogOut()
            {
                if (AuthenticationManager.LoggedEmployee == null)
                {
                    return RedirectToAction("Login", "Home");
                }
                AuthenticationManager.Logout();

                return RedirectToAction("Login", "Home");
            }

            [AuthenticationFilter]
            [HttpGet]
            public ActionResult Details()
            {
                Employee employee = AuthenticationManager.LoggedEmployee;

                DetailsEmployeeVM model = new DetailsEmployeeVM();

                model.Id = employee.Id;
                model.Email = employee.Email;
                model.FirstName = employee.FirstName;
                model.SecondName = employee.SecondName;
                model.LastName = employee.LastName;
                model.Phone = employee.Phone;
                model.AdminRole = employee.AdminRole;
                model.ManagerId = employee.ManagerId;
                model.PositionId = employee.PositionId;
                model.TeamId = employee.TeamId;
                model.Adress = employee.Adress;
                model.DateOfBirth = employee.DateofBirth;

                return View(model);
            }

            [AuthenticationFilter]
            [HttpGet]
            public ActionResult Edit()
            {
                Employee employee = AuthenticationManager.LoggedEmployee;

                EditEmployeeVM model = new EditEmployeeVM();

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
                model.AdminRole = AuthenticationManager.LoggedEmployee.AdminRole;

                return View(model);
            }

            [HttpPost]
            public ActionResult Edit(EditEmployeeVM model)
            {
                if (!this.ModelState.IsValid)
                {
                    return View(model);
                }

                EmployeeService service = new EmployeeService();
                Employee employee = new Employee();

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
                employee.AdminRole = AuthenticationManager.LoggedEmployee.AdminRole;

                service.Edit(employee);

                AuthenticationManager.Authenticate(AuthenticationManager.LoggedEmployee.Email, AuthenticationManager.LoggedEmployee.Password);
                return RedirectToAction("Details", "Home");
            }
        }
	}
}