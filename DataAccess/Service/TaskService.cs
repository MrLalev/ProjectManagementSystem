using DataAccess.Entity;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Service
{
    public class TaskService : BaseService<Task>
    {
        public override BaseRepo<Task> SetRepo()
        {
            return new TaskRepo();
        }
    }
}
