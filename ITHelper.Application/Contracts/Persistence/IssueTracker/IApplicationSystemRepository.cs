using ITHelper.Domain.IssueTrackerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Contracts.Persistence.IssueTracker
{
    public interface IApplicationSystemRepository : IGenericRepository<ApplicationSystem>
    {
    }
}
