using ITHelper.Application.Contracts.Persistence.AssetInventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Persistence.Repositories.AssetInventory
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext applicationDbContext;
        
        private IVendorRepository _vendorRepository;

        private IHardwareRepository _hardwareRepository;

        private IHardwareTypeRepository _hardwareTypeRepository;

        private IUserRepository _userRepository;

        private IDepartmentRepository _departmentRepository;

        private IContactRepository _contactRepository;
        
        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public IVendorRepository VendorRepository => _vendorRepository ??= new VendorRepository(applicationDbContext);
        public IHardwareRepository HardwareRepository => _hardwareRepository ??= new HardwareRepository(applicationDbContext);
        public IHardwareTypeRepository HardwareTypeRepository => _hardwareTypeRepository ??= new HardwareTypeRepository(applicationDbContext);
        public IUserRepository UserRepository => _userRepository ??= new UserRepository(applicationDbContext);
        public IDepartmentRepository DepartmentRepository => _departmentRepository ??= new DepartmentRepository(applicationDbContext);
        public IContactRepository ContactRepository => _contactRepository ??= new ContactRepository(applicationDbContext);

        public void Dispose()
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
