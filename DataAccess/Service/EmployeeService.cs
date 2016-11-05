using DataAccess.Entity;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Service
{
    public class EmployeeService:BaseService<Employee>
    {
        public override BaseRepo<Employee> SetRepo()
        {
            return new EmployeeRepo();
        }
    }
}
