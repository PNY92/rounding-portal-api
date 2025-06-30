

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using RoundingPortal_API.Data;
using RoundingPortal_API.Interfaces;
using RoundingPortal_API.Models;

namespace RoundingPortal_API.Repositories
{
    public class LabRepository : ILabRepository
    {
        private readonly RoundingContext _roundingContext;
        public LabRepository(RoundingContext roundingContext)
        {
            _roundingContext = roundingContext;   
        }

        public async Task<Lab> GetLabByIdAsync(Guid id)
        {
            return await _roundingContext.Labs.FindAsync(id);
        }

        public async Task AddLabAsync(Lab newLab)
        {
            await _roundingContext.Labs.AddAsync(newLab);
            await _roundingContext.SaveChangesAsync();
        }

        public async Task<List<Lab>> GetAllLabsAsync()
        {
            return await _roundingContext.Labs.ToListAsync();
        }

        public async Task<Lab> GetLabByNameAsync(string name)
        {
            List<Lab> labs = await GetAllLabsAsync();
            Lab lab = labs.Where(e => e.Name == name).FirstOrDefault();
            return lab;
        }
    }
}
