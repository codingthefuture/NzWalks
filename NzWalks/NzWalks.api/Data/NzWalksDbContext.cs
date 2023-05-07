using Microsoft.EntityFrameworkCore;
using NzWalks.api.Models.Domain;

namespace NzWalks.api.Data
{
    public class NzWalksDbContext: DbContext
    {
        public NzWalksDbContext(DbContextOptions<NzWalksDbContext> options) : base(options) //the constructor. help.
        {
                //connection string in app.settings.json
        }

        public DbSet<Regions> Regions { get; set; } //telling the entity framework to create a table based on region if it doenst exist
        public DbSet<Walk> Walks { get; set; } 
        public DbSet<WalkDifficulty> WalkDifficulty { get; set; } 
    }
}
