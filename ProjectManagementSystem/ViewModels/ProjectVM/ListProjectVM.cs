﻿using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagementSystem.ViewModels.ProjectVM
{
    public class ListProjectVM : BaseVMList<Project, ProjectFilterVM>
    {
        public string[] teams;
    }
}