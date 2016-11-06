using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectManagementSystem.ViewModels.PositionVM
{
    public class EditPositionVM:BaseVMId
    {
        [Required(ErrorMessage = "Please enter Position Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter Position Salary")]
        public decimal Salary { get; set; }
    }
}