﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class Department:BaseId
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
