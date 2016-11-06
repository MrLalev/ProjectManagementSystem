using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectManagementSystem.ViewModels.Project_ReportVM
{
    public class EditProject_ReportVM:BaseVMId
    {
        [Required(ErrorMessage = "Please enter Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter Project")]
        [Display(Name = "Project")]
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "Please enter Content")]
        public string Content { get; set; }

        public List<SelectListItem> ListProjects { get; set; }
    }
}