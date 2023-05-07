namespace NzWalks.api.Models.Domain
{
    public class Regions
    {
        public Guid id { get; set; }
        public String Code { get; set; }
        public String Name { get; set; }
        public double Area { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public long Population { get; set; }

        //navigation property

        //telling entity framework that one region can have multiple walks inside it
        public IEnumerable<Walk> Walks { get; set; }
    }
}
