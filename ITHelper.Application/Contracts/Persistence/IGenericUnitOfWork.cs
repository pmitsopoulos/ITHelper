using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Contracts.Persistence
{
    public interface IGenericUnitOfWork
    {
        Task Save();
    }
}
