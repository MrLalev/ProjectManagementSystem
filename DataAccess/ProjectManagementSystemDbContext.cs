using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    class ProjectManagementSystemDbContext<T> : DbContext where T : class
    {
        public ProjectManagementSystemDbContext()
            : base("name=ProjectManagementSystem.AppDbContext")
        {
        }

        public DbSet<T> Items { get; set; }
    }
}