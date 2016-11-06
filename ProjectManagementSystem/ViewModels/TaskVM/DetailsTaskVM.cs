using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectManagementSystem.ViewModels.TaskVM
{
    public class DetailsTaskVM:BaseVMId
    {
        [Display(Name = "Title:")]
        public string Title { get; set; }

        [Display(Name = "Content:")]
        public string Content { get; set; }

        [Display(Name = "Status:")]
        public string Status { get; set; }

        [Display(Name = "Done %:")]
        public int PercentageDone { get; set; }

        [Display(Name = "Spend Hours:")]
        public int LogWork { get; set; }

        [Display(Name = "Assignet:")]
        public int AssignetId { get; set; }

        [Display(Name = "Project: ")]
        public int ProjectId { get; set; }

        [Display(Name = "Creator: ")]
        public int CreatorId { get; set; }
    }
}