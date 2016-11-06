using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectManagementSystem.ViewModels.CommentVM
{
    public class EditCommentVM:BaseVMId
    {
        [Required(ErrorMessage = "Please enter Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter Task")]
        [Display(Name = "Task")]
        public int TaskId { get; set; }

        [Required(ErrorMessage = "Please enter Content")]
        public string Content { get; set; }

        public List<SelectListItem> ListTask { get; set; }
    }
}