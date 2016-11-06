using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectManagementSystem.ViewModels.ProjectVM
{
    public class EditProjectVM:BaseVMId
    {
        [Required(ErrorMessage = "Please enter Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter Start Date")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Please enter End Date")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Please enter Team")]
        [Display(Name = "Team")]
        public int TeamId { get; set; }

        [Required(ErrorMessage = "Please enter State")]
        [Display(Name = "Finished")]
        public bool Finished { get; set; }

        public List<SelectListItem> ListTeams { get; set; }
    }
}