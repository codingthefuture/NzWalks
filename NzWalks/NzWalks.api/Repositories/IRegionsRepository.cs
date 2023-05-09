using NzWalks.api.Models.Domain;

namespace NzWalks.api.Repositories
{
    public interface IRegionsRepository
    {
        //using task to make it asynchronous - 
        Task<IEnumerable<Regions>> GetAllAsync(); //will get a list of regions - note help

        Task<Regions> GetAsync(Guid id); //search db based on guid id

        Task<Regions> AddAsync(Regions region); //after creating this, ad it to the corresponding repository sqlregionrepository

        Task<Regions> DeleteAync(Guid id);

        Task<Regions> UpdateAsync(Guid id, Regions region);

    }
}
