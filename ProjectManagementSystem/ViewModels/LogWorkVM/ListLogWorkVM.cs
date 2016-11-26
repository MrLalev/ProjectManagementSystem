using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagementSystem.ViewModels.LogWorkVM
{
    public class ListLogWorkVM : BaseVMList<LogWork,LogWorkFilterVM>
    {
        public string[] employees;
    }
}