﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectManagementSystem.ViewModels.TeamVM
{
    public class EditTeamVM : BaseVMId
    {

        [Required(ErrorMessage = "Please enter Team Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter Department")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        public List<SelectListItem> ListDepartments { get; set; }
    }
}