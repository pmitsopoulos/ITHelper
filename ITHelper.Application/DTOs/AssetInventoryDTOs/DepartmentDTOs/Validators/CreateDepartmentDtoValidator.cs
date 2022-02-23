using FluentValidation;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.DTOs.AssetInventoryDTOs.DepartmentDTOs.Validators
{
    public class CreateDepartmentDtoValidator : AbstractValidator<CreateDepartmentDto>
    {
        private readonly IDepartmentRepository departmentRepository;

        public CreateDepartmentDtoValidator(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
            Include(new GenericDepartmentDtoValidator(this.departmentRepository));
        }
    }
}
