using ITHelper.Application.Contracts.Persistence.IssueTracker;
using ITHelper.Domain.IssueTrackerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Persistence.Repositories.IssueTracker
{
    public class SystemContactRepository : GenericRepository<SystemContact>, ISystemContactRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public SystemContactRepository(ApplicationDbContext applicationDbContext)
            :base(applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
    }
}
