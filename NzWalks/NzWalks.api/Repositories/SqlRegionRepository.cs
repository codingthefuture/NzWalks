﻿using Microsoft.EntityFrameworkCore;
using NzWalks.api.Data;
using NzWalks.api.Models.Domain;

namespace NzWalks.api.Repositories
{
    public class SqlRegionRepository : IRegionsRepository //implementing the repository, ctrl . to implement the interface #1
    {
        private readonly NzWalksDbContext nzWalksDbContext;

        //note = press ctrl + . so it implements the interface

        public SqlRegionRepository(NzWalksDbContext nzWalksDbContext) //the constructor, for the name press crl . to create and assign field
        {
            this.nzWalksDbContext = nzWalksDbContext;
        }

        //implemented interface from ctrl . 
        public async Task<Regions> AddAsync(Regions region)
        {
            region.id = Guid.NewGuid(); //over riding the id to be mine
            await nzWalksDbContext.AddAsync(region); //add to context
            await nzWalksDbContext.SaveChangesAsync(); //save the actual changes
            return region;
        }


        //after deleting then go to the regionscontroller
        public async Task<Regions> DeleteAync(Guid id)
        {
            var region = await nzWalksDbContext.Regions.FirstOrDefaultAsync(x => x.id == id); //check if db has a region with that id

            if(region == null)
            {
                return null;
            }

            //delete the region
            nzWalksDbContext.Regions.Remove(region);
            await nzWalksDbContext.SaveChangesAsync();
            return region;//return the region back just incase client wants to do anything with it
        }


        //made the method async
        public async Task<IEnumerable<Regions>> GetAllAsync()
            //now asynchronous due to task
        {
            return await nzWalksDbContext.Regions.ToListAsync();
        }

        //the autogenerated interfae #1
        public async Task<Regions> GetAsync(Guid id)
        {
            return await nzWalksDbContext.Regions.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<Regions> UpdateAsync(Guid id, Regions region)
        {
            var existingRegion = await nzWalksDbContext.Regions.FirstOrDefaultAsync(x => x.id == id);

            if(existingRegion == null)
            {
                return null;
            }

            existingRegion.Code = region.Code;
            existingRegion.Name = region.Name;
            existingRegion.Area = region.Area;
            existingRegion.Lat = region.Lat;
            existingRegion.Long = region.Long;
            existingRegion.Population = region.Population;

            await nzWalksDbContext.SaveChangesAsync();

            return existingRegion;
            //now head over to regionController for the next step #10-4

        }
    }
}
