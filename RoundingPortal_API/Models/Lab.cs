using RoundingPortal_API.Enum;

namespace RoundingPortal_API.Models
{
    public class Lab
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int MaxSeats { get; set; }
        public LabStatus Status { get; set; }
        public User? PreviousRounder { get; set; }
        public DateTime? LastRoundedDate { get; set; }
        public int Level { get; set; }
        public LabCategory Category { get; set; }
    }
}
