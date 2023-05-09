using NzWalks.api.Models.Domain;

namespace NzWalks.api.Models.DTO
{
    public class Walk
    {
        //note - dto data transfer object

        //these were copies from walk domain
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }
        public Guid RegionId { get; set; }
        public Guid WalkDifficultyId { get; set; }

        //Navigation Properties
        public Regions Region { get; set; }
        public WalkDifficulty WalkDifficulty { get; set; }
    }
}
