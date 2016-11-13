using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectManagementSystem.ViewModels.CommentVM
{
    public class DetailsCommentVM:BaseVMId
    {
        [Display(Name = "Title: ")]
        public string Title { get; set; }

        [Display(Name = "Task: ")]
        public string Task { get; set; }

        [Display(Name = "Content: ")]
        public string Content { get; set; }

        [Display(Name = "Creator: ")]
        public string Creator { get; set; }
    }
}