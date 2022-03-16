using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Contracts.Persistence.IssueTracker
{
    public interface IIssueUnitOfWork : IDisposable, IGenericUnitOfWork
    {
        IApplicationSystemRepository ApplicationSystemRepository { get; }
        IIssueRepository IssuesRepository { get; } 
        ISystemContactRepository SystemContactRepository { get; }
    }
}
