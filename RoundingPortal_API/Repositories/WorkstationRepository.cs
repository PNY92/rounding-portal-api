using Microsoft.EntityFrameworkCore;
using RoundingPortal_API.Data;
using RoundingPortal_API.Interfaces;
using RoundingPortal_API.Models;

namespace RoundingPortal_API.Repositories
{
    public class WorkstationRepository : IWorkstationRepository
    {
        private readonly RoundingContext _roundingContext;
        public WorkstationRepository(RoundingContext roundingContext) {
            _roundingContext = roundingContext;
        }

        public async Task AddWorkstationAsync(Workstation workstation)
        {
            await _roundingContext.Workstations.AddAsync(workstation);
            await _roundingContext.SaveChangesAsync();
        }

        public async Task<List<Workstation>> GetAllWorkstationsAsync()
        {
            var workstation = await _roundingContext.Workstations
                .Include(workstation => workstation.Lab)
                .OrderBy(workstation => workstation.Name)
                .ToListAsync<Workstation>();
            return workstation;
        }

        public async Task<Workstation> GetWorkstationByIdAsync(string id)
        {
            return await _roundingContext.Workstations.FindAsync(id);
        }

        public async Task<Workstation> GetWorkstationByNameAsync(string name)
        {
            List<Workstation> workstations = await this.GetAllWorkstationsAsync();
            return workstations.Where(workstation => workstation.Name == name).FirstOrDefault();
        }
    }
}
