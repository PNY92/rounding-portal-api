using RoundingPortal_API.Models;

namespace RoundingPortal_API.Interfaces
{
    public interface ILabRepository
    {
        public Task<Lab> GetLabByIdAsync(Guid id);

        public Task AddLabAsync(Lab lab);

        public Task<List<Lab>> GetAllLabsAsync();

        public Task<Lab> GetLabByNameAsync(string name);

    }
}
