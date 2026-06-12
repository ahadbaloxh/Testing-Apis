namespace Testing.Api.Models.Domains
{
    public class Walk
    {
        public Guid Id { get; set; }
        public string  Name { get; set; }
        public string Description { get; set; }
        public string LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }
        public Guid DifficultyId { get; set; }
        public Guid RegionId { get; set; }


        //navigate properties
        public Difficulty Difficulty { get; set; }
        public Region Region { get; set; }






    }
}
