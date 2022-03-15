using ITHelper.Application.Models.FilterModels.IssueTrackerFilterModels;
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
        Task<IEnumerable<Issue>> FilteredSearch(IssueFilterModel issueFilterModel);
    }
}
