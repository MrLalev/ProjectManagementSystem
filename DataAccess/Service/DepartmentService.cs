using DataAccess.Entity;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Service
{
    class DepartmentService
    {
        public override BaseRepo<Department> SetRepo()
        {
            return new DepartmentRepo();
        }
    }
}
