using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ProjectManagementSystem.ViewModels
{
    public abstract class FilterVM<T> : BaseFilter
        where T : BaseId
    {
        public abstract Expression<Func<T, bool>> GenerateFilter();
    }
}