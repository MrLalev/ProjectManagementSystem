using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagementSystem.ViewModels.EmployeeVM
{
    public class ListEmployeeVM : BaseVMList<Employee, EmployeeFilterVM>
    {
        public string[] teams;
        public string[] managers;
        public string[] positions;
    }
}