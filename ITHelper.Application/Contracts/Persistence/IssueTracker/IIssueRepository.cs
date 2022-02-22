using ITHelper.Domain.IssueTrackerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Contracts.Persistence.IssueTracker
{
    public interface IIssueRepository : IGenericRepository<Issue>
    {
        Task<IEnumerable<Issue>> GetIssuesByApplicationSystem(int systemId);
        Task<IEnumerable<Issue>> GetIssuesByResolution(bool IsResolved);
        Task<IEnumerable<Issue>> GetExpiredAndPendingIssues();
    }
}
