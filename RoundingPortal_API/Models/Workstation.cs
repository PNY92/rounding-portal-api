using RoundingPortal_API.Enum;

namespace RoundingPortal_API.Models
{
    public class Workstation
    {
        public Guid Id { get; set; }

        public Lab Lab { get; set; }

        public string Name { get; set; }


    }
}
