using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class Project_Report:BaseId
    {
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int CreatorId { get; set; }
    }
}
