using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectManagementSystem.ViewModels.EmployeeVM
{
    public class DetailsEmployeeVM:BaseVMId
    {
        [Display(Name = "First Name:")]
        public string FirstName { get; set; }

        [Display(Name = "Second Name:")]
        public string SecondName { get; set; }

        [Display(Name = "Last Name:")]
        public string LastName { get; set; }

        [Display(Name = "E-mail:")]
        public string Email { get; set; }

        [Display(Name = "Adress:")]
        public string Adress { get; set; }

        [Display(Name = "Phone:")]
        public string Phone { get; set; }

        [Display(Name = "Date Of Birth:")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Manager")]
        public int ManagerId { get; set; }

        [Display(Name = "Position")]
        public int PositionId { get; set; }

        [Display(Name = "Team")]
        public int TeamId { get; set; }

        [Display(Name = "Admin:")]
        public bool AdminRole { get; set; }
    }
}