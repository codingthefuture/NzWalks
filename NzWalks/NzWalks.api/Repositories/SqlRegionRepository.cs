using Microsoft.EntityFrameworkCore;
using NzWalks.api.Data;
using NzWalks.api.Models.Domain;

namespace NzWalks.api.Repositories
{
    public class SqlRegionRepository : IRegionsRepository //implementing the repository
    {
        private readonly NzWalksDbContext nzWalksDbContext;

        //note = press ctrl + . so it implements the interface

        public SqlRegionRepository(NzWalksDbContext nzWalksDbContext) //the constructor, for the name press crl . to create and assign field
        {
            this.nzWalksDbContext = nzWalksDbContext;
        }


        //made the method async
        public async Task<IEnumerable<Regions>> GetAllAsync()
            //now asynchronous due to task
        {
            return await nzWalksDbContext.Regions.ToListAsync();
        }
    }
}
