using RoundingPortal_API.Models;

namespace RoundingPortal_API.Interfaces
{
    public interface IIssueRepository
    {
        public Task<Issue> GetIssueByIdAsync(Guid id);

        public Task AddIssueAsync(Issue lab);

        public Task<List<Issue>> GetAllIssuesAsync();

        public Task<Issue> GetIssueByTitleAsync(string title);

    }
}
