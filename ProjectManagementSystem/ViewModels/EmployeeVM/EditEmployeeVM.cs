using ProjectManagementSystem.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;


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

    
        [Display(Name = "Position")]
        [Required(ErrorMessage = "Please enter Position")]
        public int PositionId { get; set; }

        [Display(Name = "Team")]
        [Required(ErrorMessage = "Please enter Team")]
        public int TeamId { get; set; }

        [Display(Name = "Manager")]
        public int ManagerId { get; set; }

        [Display(Name = "Admin:")]
        public bool AdminRole { get; set; }


        public List<SelectListItem> ListManagers { get; set; }
        public List<SelectListItem> ListTeams { get; set; }
        public List<SelectListItem> ListPositions { get; set; }
    }
}