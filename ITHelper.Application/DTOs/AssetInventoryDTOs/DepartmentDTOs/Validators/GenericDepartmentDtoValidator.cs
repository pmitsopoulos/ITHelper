using FluentValidation;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.DTOs.AssetInventoryDTOs.DepartmentDTOs.Validators
{
    public class GenericDepartmentDtoValidator : AbstractValidator<IDepartmentDto>
    {
        private readonly IDepartmentRepository departmentRepository;

        public GenericDepartmentDtoValidator(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
            RuleFor(d => d.Name).NotEmpty().NotNull().WithMessage("The name of the Department is required");
        }
    }
}
