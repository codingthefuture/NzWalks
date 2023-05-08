using NzWalks.api.Models.Domain;

namespace NzWalks.api.Repositories
{
    public interface IRegionsRepository
    {
        //using task to make it asynchronous - 
        Task<IEnumerable<Regions>> GetAll(); //will get a list of regions

    }
}
