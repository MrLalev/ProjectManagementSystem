using DataAccess.Entity;
using ProjectManagementSystem.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ProjectManagementSystem.ViewModels.CommentVM
{
    public class CommentFilterVM : FilterVM<Comment>
    {
        [FilterByAttribute(DisplayName = "Title:")]
        public string Title { get; set; }

        public override Expression<Func<Comment, bool>> GenerateFilter()
        {
            return (c => (String.IsNullOrEmpty(Title) || c.Title.Contains(Title)));
        }
    }
}