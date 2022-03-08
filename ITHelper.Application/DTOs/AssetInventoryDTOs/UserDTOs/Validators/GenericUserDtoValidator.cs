using FluentValidation;
using ITHelper.Application.Contracts.Persistence.AssetInventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Application.DTOs.AssetInventoryDTOs.UserDTOs.Validators
{
    public class GenericUserDtoValidator  : AbstractValidator<IUserDto>
    {
        private readonly IUserRepository userRepository;

        public GenericUserDtoValidator(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
            RuleFor(u => u.Fullname).NotNull().NotEmpty().WithMessage("The full name of the user is required.");
            RuleFor(u => u.DepartmentId).NotEqual(default(int)).WithMessage("The user needs to be registered on a department");
            RuleFor(u => u.PhoneNumber).NotEmpty().NotNull().WithMessage("The phone number field is required");
            RuleFor(u => u.PhoneNumber).NotEmpty().NotNull().WithMessage("The email field is required");
        }
    }
}
