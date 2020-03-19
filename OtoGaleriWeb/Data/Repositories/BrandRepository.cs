using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Data.Repositories
{
    public class BrandRepository : BaseRepository<Brand>
    {
        public BrandRepository(GaleriDBEntities dbContext) : base(dbContext)
        {
        }
    }
}
