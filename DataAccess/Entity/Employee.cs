using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entity
{
    public class Employee :BaseId
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public int ManagerId { get; set; }
        public int PositionId { get; set; }
        public int TeamId { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public DateTime DateofBirth { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool AdminRole { get; set; }
    }
}
