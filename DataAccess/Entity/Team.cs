using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class Team:BaseId
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
    }
}
