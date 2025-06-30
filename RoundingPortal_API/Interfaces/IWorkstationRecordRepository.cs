using RoundingPortal_API.Models;

namespace RoundingPortal_API.Interfaces
{
    public interface IWorkstationRecordRepository
    {
        public Task<WorkstationRecord> GetWorkstationRecordByIdAsync(Guid id);

        public Task<List<WorkstationRecord>> GetAllWorkstationRecordsAsync();

        public Task<List<WorkstationRecord>> GetWorkstationRecordsByWorkstationAsync(Guid workstationId);


        public Task<List<WorkstationRecord>> GetAllWorkstationRecordsByLabAsync(Guid labId);

        public Task AddWorkstationRecordAsync(WorkstationRecord workstationRecord);

    }
}
