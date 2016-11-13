using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectManagementSystem.ViewModels.Project_ReportVM
{
    public class DetailsProject_ReportVM:BaseVMId
    {
        [Display(Name = "Title: ")]
        public string Title { get; set; }

        [Display(Name = "Project: ")]
        public string Project { get; set; }

        [Display(Name = "Content: ")]
        public string Content { get; set; }

        [Display(Name = "Creator: ")]
        public string Creator { get; set; }
    }
}