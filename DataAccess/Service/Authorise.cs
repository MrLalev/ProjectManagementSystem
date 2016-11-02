using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entity;

namespace DataAccess.Service
{
    public class Authorise
    {
        public Employee LoggedEmployee { get; private set; }

        public void Authenticate(string email, string password)
        {
            //EmployeeRepo employeeRepo = new EmployeeRepo();

            //List<Employee> employees = employeeRepo.GetAll(p => p.Email == email && p.Password == password).ToList();

            //LoggedEmployee = employees.Count > 0 ? employees[0] : null;

        }
    }
}
