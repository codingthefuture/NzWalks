namespace NzWalks.api.Models.DTO
{
    public class UpdateRegionRequest
    {
        //used to hoose what a client will update
        public String Code { get; set; }
        public String Name { get; set; }
        public double Area { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public long Population { get; set; }
    }
}
