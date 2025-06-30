using RoundingPortal_API.Enum;

namespace RoundingPortal_API.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
