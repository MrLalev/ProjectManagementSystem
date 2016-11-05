using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagementSystem.ViewModels
{
    public class BaseVMList<T, F>
    where T : BaseId
    where F : FilterVM<T>
    {
        public List<T> Items { get; set; }
        public F Filter { get; set; }
        public PagerVM Pager { get; set; }
    }
 
}