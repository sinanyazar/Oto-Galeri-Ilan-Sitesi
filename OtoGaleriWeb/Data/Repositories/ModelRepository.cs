using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Data.Repositories
{
    public class ModelRepository : BaseRepository<Model>
    {
        public ModelRepository(GaleriDBEntities dbContext) : base(dbContext)
        {
        }
    }
}
