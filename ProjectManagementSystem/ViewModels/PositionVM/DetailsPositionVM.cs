using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectManagementSystem.ViewModels.PositionVM
{
    public class DetailsPositionVM:BaseVMId
    {
        [Display(Name = "Position Name:")]
        public string Name { get; set; }

        [Display(Name = "Salary:")]
        public decimal Salary { get; set; }
    }
}