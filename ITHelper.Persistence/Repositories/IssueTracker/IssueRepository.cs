using ITHelper.Application.Contracts.Persistence.IssueTracker;
using ITHelper.Application.Models.FilterModels.IssueTrackerFilterModels;
using ITHelper.Domain.IssueTrackerEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Persistence.Repositories.IssueTracker
{
    public class IssueRepository : GenericRepository<Issue>, IIssueRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public IssueRepository(ApplicationDbContext applicationDbContext) 
            :base(applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<Issue>> FilteredSearch(IssueFilterModel issueFilterModel)
        {
            var result = await applicationDbContext.Issues
                .Where(i => i.Resolved == issueFilterModel.Resolved)
                .Where(i => issueFilterModel.Expired ? i.DueDate < DateTime.Now : i.DueDate > DateTime.Now)
                .Where(i => issueFilterModel.ApplicationSystemId != default ? i.ApplicationSystemId == issueFilterModel.ApplicationSystemId : i.ApplicationSystemId != default)
                .ToListAsync();

            return result;
        }
    }
}
