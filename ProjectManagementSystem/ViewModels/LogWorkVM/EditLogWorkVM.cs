using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectManagementSystem.ViewModels.LogWorkVM
{
    public class EditLogWorkVM : BaseVMId
    {
        [Required(ErrorMessage = "Please enter Task")]
        [Display(Name = "Task")]
        public int TaskId { get; set; }

        [Required(ErrorMessage = "Please enter Work Type")]
        [Display(Name = "Work Type")]
        public string WorkTypeValue { get; set; }

        [Required(ErrorMessage = "Please enter Hours Worked")]
        public int HoursWorked { get; set; }
        public List<SelectListItem> ListTask { get; set; }
        public List<SelectListItem> ListWorkType { get; set; }
    }
}