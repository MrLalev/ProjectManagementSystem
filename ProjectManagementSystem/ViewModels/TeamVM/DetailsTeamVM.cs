using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectManagementSystem.ViewModels.TeamVM
{
    public class DetailsTeamVM:BaseVMId
    {
        [Display(Name = "Team Name:")]
        public string Name { get; set; }

        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
    }
}