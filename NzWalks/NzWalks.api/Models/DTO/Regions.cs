namespace NzWalks.api.Models.DTO
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
    }
}
