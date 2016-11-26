using ProjectManagementSystem.ViewModels.CommentVM;
using ProjectManagementSystem.ViewModels.LogWorkVM;
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
        public string Assignet { get; set; }

        [Display(Name = "Project: ")]
        public string Project { get; set; }

        [Display(Name = "Creator: ")]
        public string Creator { get; set; }

        public ListCommentVM CommentsVM { get; set; }
        public ListLogWorkVM LogWorkVM { get; set; }
    }
}