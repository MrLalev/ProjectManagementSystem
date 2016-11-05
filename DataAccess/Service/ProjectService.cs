using DataAccess.Entity;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Service
{
    public class ProjectService : BaseService<Project>
    {
        public override BaseRepo<Project> SetRepo()
        {
            return new ProjectRepo();
        }
    }
}
