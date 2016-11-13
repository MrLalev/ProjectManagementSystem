using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectManagementSystem.ViewModels.ProjectVM
{
    public class DetailsProjectVM : BaseVMId
    {
        [Display(Name = "Name:")]
        public string Name { get; set; }

        [Display(Name = "Start Date:")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date:")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Team: ")]
        public string Team { get; set; }

        [Display(Name = "Finished: ")]
        public bool Finished { get; set; }
    }
}