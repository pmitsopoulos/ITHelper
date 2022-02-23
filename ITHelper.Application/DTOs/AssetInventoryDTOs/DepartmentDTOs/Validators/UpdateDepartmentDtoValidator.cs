using FluentValidation;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.DTOs.AssetInventoryDTOs.DepartmentDTOs.Validators
{
    public class UpdateDepartmentDtoValidator : AbstractValidator<UpdateDepartmentDto>
    {
        private readonly IDepartmentRepository departmentRepository;

        public UpdateDepartmentDtoValidator(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
            Include(new GenericDepartmentDtoValidator(this.departmentRepository));
        }
    }
}
