using Microsoft.EntityFrameworkCore;
using NzWalks.api.Data;
using NzWalks.api.Models.Domain;

namespace NzWalks.api.Repositories
{
    public class WalkDifficultyRepository : IWalkDifficultyRepository
    {
        private readonly NzWalksDbContext nzWalksDbContext;

        public WalkDifficultyRepository(NzWalksDbContext nzWalksDbContext)
        {
            this.nzWalksDbContext = nzWalksDbContext;
        }

        public async Task<WalkDifficulty> AddAsync(WalkDifficulty walkDifficulty)
        {
            walkDifficulty.Id = Guid.NewGuid(); //ive our own id not taking in clients id
            await nzWalksDbContext.WalkDifficulty.AddAsync(walkDifficulty);
            await nzWalksDbContext.SaveChangesAsync();
            return walkDifficulty;
        }

        public async Task<WalkDifficulty> DeleteAsync(Guid id)
        {
            var existingWalkDifficulty = await nzWalksDbContext.WalkDifficulty.FindAsync(id);
            if(existingWalkDifficulty !=  null)
            {
                nzWalksDbContext.WalkDifficulty.Remove(existingWalkDifficulty);
                await nzWalksDbContext.SaveChangesAsync();
                return existingWalkDifficulty;
            }
            return null;

        }

        public async Task<IEnumerable<WalkDifficulty>> GetAllAsync()
        {
            return await nzWalksDbContext.WalkDifficulty.ToListAsync();
        }

        public async Task<WalkDifficulty> GetAsync(Guid id)
        {
            return await nzWalksDbContext.WalkDifficulty.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<WalkDifficulty> UpdateAsync(Guid id, WalkDifficulty walkDifficulty)
        {
            var existingWalkDifficulty = await nzWalksDbContext.WalkDifficulty.FindAsync(id);

            if(existingWalkDifficulty == null)
            {
                return null;
            }

            existingWalkDifficulty.Code = walkDifficulty.Code;
            await nzWalksDbContext.SaveChangesAsync();
            return existingWalkDifficulty;
        }
    }
}
