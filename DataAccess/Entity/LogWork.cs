using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class LogWork:BaseId
    {
        public int TaskId { get; set; }
        public int EmployeeId { get; set; }
        public string WorkType { get; set; }
        public int HoursWorked { get; set; }
    }
}
