using Microsoft.EntityFrameworkCore;
using RoundingPortal_API.Data;
using RoundingPortal_API.Interfaces;
using RoundingPortal_API.Models;

namespace RoundingPortal_API.Repositories
{
    public class WorkstationRecordRepository : IWorkstationRecordRepository
    {
        private readonly RoundingContext _roundingContext;
        public WorkstationRecordRepository(RoundingContext roundingContext) {
            _roundingContext = roundingContext;
        }

        public async Task AddWorkstationRecordAsync(WorkstationRecord workstationRecord)
        {
            await _roundingContext.WorkstationRecords.AddAsync(workstationRecord);
            await _roundingContext.SaveChangesAsync();
        }

        public async Task<List<WorkstationRecord>> GetAllWorkstationRecordsAsync()
        {
            return await _roundingContext.WorkstationRecords
                .Include(record => record.Workstation)
                .Include(record => record.Rounder)
                .ToListAsync();
        }

  
        public async Task<List<WorkstationRecord>> GetAllWorkstationRecordsByLabAsync(Guid labId)
        {


            return await _roundingContext.WorkstationRecords
                .Include(record => record.Workstation)
                .Include(record => record.Rounder)
                .Where(workstationRecord => workstationRecord.Workstation.Lab.Id == labId)
                .ToListAsync();
        }

        public Task<WorkstationRecord> GetWorkstationRecordByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<WorkstationRecord>> GetWorkstationRecordsByWorkstationAsync(Guid workstationId)
        {
            return await _roundingContext.WorkstationRecords
                .Include(record => record.Workstation)
                .Include(record => record.Rounder)
                .Where(workstationRecord => workstationRecord.Workstation.Id == workstationId)
                .ToListAsync();
        }
    }
}
