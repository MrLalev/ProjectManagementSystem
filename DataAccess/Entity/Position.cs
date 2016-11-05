using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class Position:BaseId
    { 
        public string Name { get; set; }
        public decimal Salary { get; set; }
    }
}
