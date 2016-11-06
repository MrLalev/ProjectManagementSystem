using DataAccess.Entity;
using DataAccess.Service;
using ProjectManagementSystem.ViewModels.DepartmentVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectManagementSystem.Controllers
{
    public class DepartmentController : BaseController<Department, ListDepartmentVM, EditDepartmentVM, DetailsDepartmentVM, DepartmentFilterVM>
    {
        public override void ExtraDelete(Department department)
        {
        }

        public override void PopulateItem(Department department, EditDepartmentVM model)
        {
            department.Id = model.Id;
            department.Name = model.Name;
            department.Description = model.Description;
        }

        public override void PopulateModel(Department department, EditDepartmentVM model)
        {
            model.Id = department.Id;
            model.Name = department.Name;
            model.Description = department.Description;
        }

        public override void PopulateModelDelete(Department department, DetailsDepartmentVM model)
        {
            model.Id = department.Id;
            model.Name = department.Name;
            model.Description = department.Description;
        }

        public override BaseService<Department> SetService()
        {
            return new DepartmentService();
        }
    }
}