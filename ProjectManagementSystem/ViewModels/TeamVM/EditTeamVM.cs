using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectManagementSystem.ViewModels.TeamVM
{
    public class EditTeamVM : BaseVMId
    {

        [Required(ErrorMessage = "Please enter Team Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter Department")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
    }
}