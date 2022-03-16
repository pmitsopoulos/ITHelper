using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Contracts.Persistence.AssetInventory
{
    public interface IUnitOfWork : IDisposable , IGenericUnitOfWork
    {
        IVendorRepository VendorRepository { get; } 
        IHardwareRepository HardwareRepository { get; }
     
        IHardwareTypeRepository HardwareTypeRepository { get; }
        IUserRepository UserRepository { get; }
        IDepartmentRepository DepartmentRepository { get; }
        IContactRepository ContactRepository { get; }

    }
}
