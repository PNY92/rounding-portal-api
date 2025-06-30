

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using RoundingPortal_API.Data;
using RoundingPortal_API.Interfaces;
using RoundingPortal_API.Models;

namespace RoundingPortal_API.Repositories
{
    public class IssueRepository : IIssueRepository
    {
        private readonly RoundingContext _roundingContext;
        public IssueRepository(RoundingContext roundingContext)
        {
            _roundingContext = roundingContext;   
        }

        public async Task<Issue> GetIssueByIdAsync(Guid id)
        {
            return await _roundingContext.Issues
                .Include(issue => issue.Reporter)
                .Include(issue => issue.Lab)
                .Include(issue => issue.Workstation)
                .FirstOrDefaultAsync();

        }

        public async Task AddIssueAsync(Issue newIssue)
        {
            await _roundingContext.Issues.AddAsync(newIssue);
            await _roundingContext.SaveChangesAsync();
        }

        public async Task<List<Issue>> GetAllIssuesAsync()
        {
            return await _roundingContext.Issues
                .Include(issue => issue.Reporter)
                .Include(issue => issue.Workstation)
                .Include(issue => issue.Lab)
                .ToListAsync<Issue>(); ;
        }

        public async Task<Issue> GetIssueByTitleAsync(string title)
        {
            List<Issue> issues = await GetAllIssuesAsync();
            Issue issue = issues.Where(e => e.Title == title).FirstOrDefault();
            return issue;
        }
    }
}
