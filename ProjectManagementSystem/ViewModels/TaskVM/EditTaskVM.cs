using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectManagementSystem.ViewModels.TaskVM
{
    public class EditTaskVM:BaseVMId
    {
        [Required(ErrorMessage = "Please enter Task Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter Task Content")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Please enter Status")]
        public string Status { get; set; }
        public int PercentageDone { get; set; }
        public int LogWork { get; set; }

        [Required(ErrorMessage = "Please enter Assignet")]
        [Display(Name = "Assignet")]
        public int AssignetId { get; set; }

        [Required(ErrorMessage = "Please enter Project")]
        [Display(Name = "Project")]
        public int ProjectId { get; set; }

        public List<SelectListItem> ListAssignet { get; set; }
        public List<SelectListItem> ListProjects { get; set; }
        public List<SelectListItem> ListPercentage { get; set; }
        public List<SelectListItem> ListStatus { get; set; }
    }
}