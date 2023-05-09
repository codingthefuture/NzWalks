using NzWalks.api.Models.Domain;

namespace NzWalks.api.Repositories
{
    public interface IWalkRepository
    {
       Task<IEnumerable<Walk>> GetAllAsync();
       Task<Walk> GetAsync(Guid id);
       Task<Walk> AddAsync(Walk item);

       Task<Walk> UpdateAsync(Guid id, Walk walk);

       Task<Walk> DeleteAsync(Guid id);
    }
}
