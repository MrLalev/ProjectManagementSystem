using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagementSystem.ViewModels.TaskVM
{
    public class ListTaskVM : BaseVMList<Task, TaskFilterVM>
    {
        public string[] creators;
        public string[] assignets;
        public string[] projects;
    }
}