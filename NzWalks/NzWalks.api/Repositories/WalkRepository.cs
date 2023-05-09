using Microsoft.EntityFrameworkCore;
using NzWalks.api.Data;
using NzWalks.api.Models.Domain;

namespace NzWalks.api.Repositories
{
    public class WalkRepository : IWalkRepository //implements the interface then go to program to add the builder.services
    {
        private readonly NzWalksDbContext nzWalksDbContext;

        public WalkRepository(NzWalksDbContext nzWalksDbContext) //construcutor injection
        {
            this.nzWalksDbContext = nzWalksDbContext;
        }

        public async Task<Walk> AddAsync(Walk walk)
        {
            //assign the new id
            walk.Id = Guid.NewGuid();
            await nzWalksDbContext.Walks.AddAsync(walk);
            await nzWalksDbContext.SaveChangesAsync();

            return walk;
            //after adding then go to walks controller
        }

        public async Task<Walk> DeleteAsync(Guid id)
        {
            var existingWalk = await nzWalksDbContext.Walks.FindAsync(id);//id is a primary key, find and store id

            if(existingWalk == null)
            {
                return null;
            }

            nzWalksDbContext.Walks.Remove(existingWalk);
            await nzWalksDbContext.SaveChangesAsync();
            return existingWalk;

        }

        public async Task<IEnumerable<Walk>> GetAllAsync()
        {
            return await nzWalksDbContext.Walks  //return the list for the client
                 .Include(x => x.Region)
                 .Include(x => x.WalkDifficulty)
                 .ToListAsync();
        }

        public Task<Walk> GetAsync(Guid id)
        {
            return nzWalksDbContext.Walks
                .Include(x => x.Region) //gpt note
                .Include(x => x.WalkDifficulty)
                .FirstOrDefaultAsync(x => x.Id == id);

            //green squigglies mean that it can return null, a .net features
        }

        public async Task<Walk> UpdateAsync(Guid id, Walk walk)
        {
            var existingWalk = await nzWalksDbContext.Walks.FindAsync(id);//id is a primary key

            if (existingWalk != null)
            {
                existingWalk.Length = walk.Length;
                existingWalk.Name = walk.Name;
                existingWalk.WalkDifficultyId = walk.WalkDifficultyId;
                existingWalk.RegionId = walk.RegionId;
                nzWalksDbContext.SaveChangesAsync();
                return existingWalk;
            }
            return null; //return null if not found
        }
    }
}
