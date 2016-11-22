using DataAccess.Entity;
using DataAccess.Service;
using ProjectManagementSystem.Filters;
using ProjectManagementSystem.ViewModels.PositionVM;
using ProjectManagementSystem.ViewModels.Project_ReportVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectManagementSystem.Controllers
{
    [AdminFilter]
    public class PositionController : BaseController<Position, ListPositionVM, EditPositionVM, DetailsPositionVM, PositionFilterVM>
    {
        public override void ExtraDelete(Position position)
        {
        }

        public override void PopulateItem(Position position, EditPositionVM model)
        {
            position.Id = model.Id;
            position.Name = model.Name;
            position.Salary = model.Salary;
        }

        public override void PopulateModel(Position position, EditPositionVM model)
        {
            model.Id = position.Id;
            model.Name = position.Name;
            model.Salary = position.Salary;
        }

        public override void PopulateModelDelete(Position position, DetailsPositionVM model)
        {
            model.Id = position.Id;
            model.Name = position.Name;
            model.Salary = position.Salary;
        }

        public override BaseService<Position> SetService()
        {
            return new PositionService();
        }
    }
}