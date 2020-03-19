using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Data.Repositories
{
    public class CarRepository : BaseRepository<Car>
    {
        public CarRepository(GaleriDBEntities dbContext) : base(dbContext)
        {
        }
    }
}
