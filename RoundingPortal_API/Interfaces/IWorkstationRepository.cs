using RoundingPortal_API.Models;

namespace RoundingPortal_API.Interfaces
{
    public interface IWorkstationRepository
    {
        public Task<Workstation> GetWorkstationByIdAsync(string id);

        public Task AddWorkstationAsync(Workstation workstation);

        public Task<List<Workstation>> GetAllWorkstationsAsync();

        public Task<Workstation> GetWorkstationByNameAsync(string name);
    }
}
