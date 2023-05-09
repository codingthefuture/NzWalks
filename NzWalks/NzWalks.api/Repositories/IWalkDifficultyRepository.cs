using NzWalks.api.Models.Domain;

namespace NzWalks.api.Repositories
{
    public interface IWalkDifficultyRepository
    {
        //1. add to program.cs for the builder.services

        Task<IEnumerable<WalkDifficulty>> GetAllAsync();
        Task<WalkDifficulty> GetAsync(Guid id); //a single item

        Task<WalkDifficulty> AddAsync(WalkDifficulty walkDifficulty);
        Task<WalkDifficulty> UpdateAsync(Guid id, WalkDifficulty walkDifficulty);

        Task<WalkDifficulty> DeleteAsync(Guid id);

    }
}
