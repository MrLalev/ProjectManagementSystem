using DataAccess.Entity;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Service
{
    public class PositionService : BaseService<Position>
    {
        public override BaseRepo<Position> SetRepo()
        {
            return new PositionRepo();
        }
    }
}
