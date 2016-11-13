using DataAccess.Entity;
using DataAccess.Service;
using ProjectManagementSystem.Models;
using ProjectManagementSystem.ViewModels.Project_ReportVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectManagementSystem.Controllers
{
    public class Project_ReportController : BaseController<Project_Report, ListProject_ReportVM, EditProject_ReportVM, DetailsProject_ReportVM, Project_ReportFilterVM>
    {
        public override void FillList(EditProject_ReportVM model)
        {
            ProjectService ProjectService = new ProjectService();
            List<Project> projects = ProjectService.GetAll(p => p.TeamId == AuthenticationManager.LoggedEmployee.TeamId).ToList();

            model.ListProjects = new List<SelectListItem>();
            foreach (var item in projects)
            {
                model.ListProjects.Add(new SelectListItem()
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });

            }

            if (model.ListProjects.Count() > 0)
            {
                model.ListProjects[0].Selected = true;
            }
        }

        public override void AddAdditionalInfo(ListProject_ReportVM model)
        {
            ProjectService ProjectService = new ProjectService();
            model.projects = new string[model.Items.Count()];

            for (int i = 0; i < model.Items.Count(); i++)
            {
                model.projects[i] = ProjectService.GetById(model.Items[i].ProjectId).Name;
            }

            EmployeeService EmployeeService = new EmployeeService();
            model.creators = new string[model.Items.Count()];

            for (int i = 0; i < model.Items.Count(); i++)
            {
                model.creators[i] = EmployeeService.GetById(model.Items[i].CreatorId).FirstName + " " + EmployeeService.GetById(model.Items[i].CreatorId).LastName;
            }

        }
        public override void ExtraDelete(Project_Report rport)
        {
        }

        public override void PopulateItem(Project_Report report, EditProject_ReportVM model)
        {
            report.Id = model.Id;
            report.Title = model.Title;
            report.Content = model.Content;
            report.ProjectId = model.ProjectId;
            report.CreatorId = AuthenticationManager.LoggedEmployee.Id;
        }

        public override void PopulateModel(Project_Report position, EditProject_ReportVM model)
        {
            model.Id = position.Id;
            model.Title = position.Title;
            model.Content = position.Content;
            model.ProjectId = position.ProjectId;
        }

        public override void PopulateModelDelete(Project_Report position, DetailsProject_ReportVM model)
        {
            model.Id = position.Id;
            model.Title = position.Title;
            model.Content = position.Content;
            ProjectService ProjectService = new ProjectService();
            model.Project = ProjectService.GetById(position.ProjectId).Name;
            EmployeeService EmployeeService = new EmployeeService();
            model.Creator = EmployeeService.GetById(position.CreatorId).FirstName + " " + EmployeeService.GetById(position.CreatorId).LastName;
        }
 
        public override BaseService<Project_Report> SetService()
        {
            return new Project_ReportService();
        }
    }
}