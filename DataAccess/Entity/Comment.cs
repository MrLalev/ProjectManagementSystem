using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class Comment:BaseId
    {
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int CreatorId { get; set; }
    }
}
