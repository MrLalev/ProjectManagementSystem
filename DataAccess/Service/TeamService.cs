using DataAccess.Entity;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Service
{
    public class TeamService : BaseService<Team>
    {
        public override BaseRepo<Team> SetRepo()
        {
            return new TeamRepo();
        }
    }
}
