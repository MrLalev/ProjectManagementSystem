using DataAccess.Entity;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Service
{
    public class CommentService : BaseService<Comment>
    {
        public override BaseRepo<Comment> SetRepo()
        {
            return new CommentRepo();
        }
    }
}
