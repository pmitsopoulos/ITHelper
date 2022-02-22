using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.Contracts.Persistence.AssetInventory
{
    public interface IUnitOfWork : IDisposable
    {
        IVendorRepository VendorRepository { get; } 
        IHardwareRepository HardwareRepository { get; }
        IHardwareSpecificationRepository hardwareSpecificationRepository { get; }
        IHardwareTypeRepository hardwareTypeRepository { get; }
        IUserRepository UserRepository { get; }
        IDepartmentRepository DepartmentRepository { get; }
        ISiteRepository SiteRepository { get; }
        IContactRepository ContactRepository { get; }
        IAssetRepository AssetRepository { get; }
        Task Save();
    }
}
