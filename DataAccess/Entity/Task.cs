using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class Task:BaseId
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int AssignetId { get; set; }
        public int ProjectId { get; set; }
        public double LogWork { get; set; }
        public string Status { get; set; }
        public int PercentageDone { get; set; }
        public int CreatorId { get; set; }

    }
}
