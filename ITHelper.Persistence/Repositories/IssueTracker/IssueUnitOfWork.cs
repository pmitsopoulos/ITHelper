using ITHelper.Application.Contracts.Persistence.IssueTracker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Persistence.Repositories.IssueTracker
{
    public class IssueUnitOfWork : IIssueUnitOfWork
    {
        private readonly ApplicationDbContext applicationDbContext;
        private IIssueRepository _issueRepository;
        private ISystemContactRepository _systemContactRepository;
        private IApplicationSystemRepository _applicationSystemRepository;

        public IssueUnitOfWork(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public IApplicationSystemRepository ApplicationSystemRepository => _applicationSystemRepository ??= new ApplicationSystemRepository(applicationDbContext);

        public IIssueRepository IssuesRepository =>  _issueRepository ??= new IssueRepository(applicationDbContext);

        public ISystemContactRepository SystemContactRepository => _systemContactRepository ??= new SystemContactRepository(applicationDbContext);

        void IDisposable.Dispose()
        {
            applicationDbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await applicationDbContext.SaveChangesAsync();   
        }
    }
}
