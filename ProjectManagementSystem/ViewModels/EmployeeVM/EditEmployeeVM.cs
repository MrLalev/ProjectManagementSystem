using ProjectManagementSystem.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectManagementSystem.ViewModels.EmployeeVM
{
    public class EditEmployeeVM:BaseVMId
    {

        [Required(ErrorMessage = "Please enter First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter Second Name")]
        public string SecondName { get; set; }

        [Required(ErrorMessage = "Please enter Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please repeat Password")]
        [Display(Name = "Repeat your Password:")]
        [MatchValue("Password")]
        public string RePassword { get; set; }

        [Required(ErrorMessage = "Please enter E-mail")]
        [UniqueEmail("Id")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter adress")]
        public string Adress { get; set; }

        [Required(ErrorMessage = "Please enter Phone number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter date of birth")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Manager")]
        public int ManagerId { get; set; }

        [Required(ErrorMessage = "Please enter position")]
        [Display(Name = "Position")]
        public int PositionId { get; set; }

        [Required(ErrorMessage = "Please enter team")]
        [Display(Name = "Team")]
        public int TeamId { get; set; }

        [Display(Name = "Admin:")]
        public bool AdminRole { get; set; }
    }
}